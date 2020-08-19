using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMaps.LocationServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using System.Xml.XPath;



namespace MapApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
       
            //Load events
            LoadEventsFromFile();

            //To show events from Dic1
            ShowEvents_Dic1();

            //To show events from Dic2
            ShowEvents_Dic2();

        }

        public void OnCLick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Source: https://stackoverflow.com/questions/18874868/how-to-return-lat-long-with-mousemove-in-gmap-net
                double X = map.FromLocalToLatLng(e.X, e.Y).Lat; //To retrieve coordinates from mouse click
                double Y = map.FromLocalToLatLng(e.X, e.Y).Lng;

                ChoiceForm f3 = new ChoiceForm(); // Instantiate a Form3 object.
                f3.Location = new Point(300, 200);
                f3.Show(); // Show Form3

                f3.setLatLng(X, Y);

                f3.setDictionary(Dic1, Dic2); //Passing dictionaries to Choice form
            }

        }

        
        private const string filePath = "..\\..\\..\\Data\\Data.xml";
        private XmlDocument document;
        private XDocument xDocument;

        Events1 obj1 = new Events1();
        Events2 obj2 = new Events2();

        //Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.8


        Dictionary<string, Events1> Dic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> Dic2 = new Dictionary<string, Events2>();

        //Loading events from XML file into Dictionaries
        public void LoadEventsFromFile()
        {

            document = new XmlDocument();
            document.Load(filePath);

            //Source:  https://docs.microsoft.com/en-us/dotnet/api/system.xml.linq.xdocument.parse?view=netframework-4.8
            xDocument = XDocument.Parse(document.InnerXml);

            bool app = false;
            bool flagTime1 = true;
            bool flag1 = false;
            bool flag2 = false;
            string eventid = "";
            int eventCounter = 0;

            //Use of LINQ to XML
            foreach (XElement sr in xDocument.Descendants())
            {
                string key = sr.Name.LocalName;

                if (key.Equals("eventid"))
                {
                    if(eventCounter > 0)
                    {
                        app = true;
                    }

                    if(flag1 == true)
                    {
                        Dic1.Add(("ID" + eventCounter), obj1);

                    }
                    else if(flag2 == true)
                    {

                        Dic2.Add(("ID" + eventCounter), obj2);
                    }

                    flag1 = false;
                    flag2 = false;

                    eventid = sr.Value;
                }


                /**** For tweet, fb events *****/
                if (key.Equals("tweet") || key.Equals("facebook-status-update"))
                {
                    
                    eventCounter++;

                   if (app == true)
                   {
                        obj1 = new Events1();
                        obj1.setEventType(key);
                    }
                    app = false;
                    flag1 = true;
                }

                /*** For photo, video, tracklog events ***/
                if(key.Equals("photo") || key.Equals("video") || key.Equals("tracklog"))
                {
                    
                    eventCounter++;

                  if (app == true)
                    {
                        obj2 = new Events2();
                        obj2.setEventType(key);
                    }

                    app = false;
                    flag2 = true;

                }


                if (flag1 == true)
                {
                    obj1.setEventID(eventid);
                    SetEvents1(key, sr);
                }


               if(flag2 == true)
                {
                    obj2.setEventID(eventid);
                    SetEvents2(key, sr, flagTime1);
                    flagTime1 = true;
                }
            }

            /***** Adding last event into dictionary*******/
            if (flag1 == true)
            {
                Dic1.Add(("ID" + eventCounter), obj1);

            }
            else if (flag2 == true)
            {

                Dic2.Add(("ID" + eventCounter), obj2);
            }
            
        }

        //Set values in Events1 class
        public void SetEvents1(string key, XElement sr)
        {
            if (key.Equals("eventid"))
            {
                obj1.setEventID(sr.Value);
            }

            else if (key.Equals("text"))
            {
                obj1.setText(sr.Value);
            }

            else if (key.Equals("lat"))
            {
                obj1.setLatitude(sr.Value);
            }

            else if (key.Equals("long"))
            {
                obj1.setLongitude(sr.Value);
            }
            else if (key.Equals("datetimestamp"))
            {
                obj1.setDateTimeStamp(sr.Value);
            }
        }

        //Set values in Events2 class
        public void SetEvents2(string key, XElement sr, bool flagTime1)
        {

            if (key.Equals("eventid"))
            {
                obj2.setEventID(sr.Value);
            }

            else if (key.Equals("filepath"))
            {
                obj2.setFilePath(sr.Value);
            }

            else if (key.Equals("lat"))
            {
                obj2.setLatitude(sr.Value);
            }

            else if (key.Equals("long"))
            {
                obj2.setLongitude(sr.Value);

            }
            else if (key.Equals("datetimestamp") && flagTime1 == true)
            {
                obj2.setStartTimeStamp(sr.Value);
                obj2.setEndTimeStamp(sr.Value);
                flagTime1 = false;
            }

        }

        //Showing events from Dic1
        public void ShowEvents_Dic1()
        {
            double lat = 0, lng = 0;
            string eveid = "", evetype = "";
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarker marker;

            foreach (KeyValuePair<string, Events1> kvp in Dic1)
            {

                eveid = kvp.Key;
                evetype = kvp.Value.getEventType();
                lat = Convert.ToDouble(kvp.Value.getLatitude());
                lng = Convert.ToDouble(kvp.Value.getLongitude());
                marker = new GMarkerGoogle(point, GMarkerGoogleType.pink_pushpin);

                //Source: https://www.youtube.com/watch?v=TxSJJfaAzKg&t=211s
                //Caliing make map function
                MakeMap(lat, lng);
                point = new PointLatLng(lat, lng);

                //Create a overlay
                GMapOverlay markers = new GMapOverlay("markers");

                //Add all available markers to that overlay
                markers.Markers.Add(marker);

                //Cover map
                map.Overlays.Add(markers);
            }
        }

        //Showing events from Dic2
        public void ShowEvents_Dic2()
        {
            double lat = 0, lng = 0;
            string eveid = "", evetype = "";
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarker marker;
            
            foreach (KeyValuePair<string, Events2> kvp in Dic2)
            {

                eveid = kvp.Key;
                evetype= kvp.Value.getEventType();
                lat = Convert.ToDouble(kvp.Value.getLatitude());
                lng = Convert.ToDouble(kvp.Value.getLongitude());

                {
                    marker = new GMarkerGoogle(point, GMarkerGoogleType.orange_dot);
                }
                
                //Calling make map function
                MakeMap(lat, lng);

                point = new PointLatLng(lat, lng);
                //Create a overlay
                GMapOverlay markers = new GMapOverlay("markers");

                //Add all available markers to that overlay
                markers.Markers.Add(marker);

                //Cover map
                map.Overlays.Add(markers);
            }
            
           
        }

        //Source: https://www.youtube.com/watch?v=TxSJJfaAzKg&t=211s
        //Creates a map using GMap 
        public void MakeMap(double lat, double lng)
        {
            map.DragButton = MouseButtons.Right;

            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            map.Position = new GMap.NET.PointLatLng(lat, lng);
            map.MinZoom = 4;
            map.MaxZoom = 100;
            map.Zoom = 10;

        }

        //Button trigger confirmation when a new event is added
        private void Event_Added_Button_Click(object sender, EventArgs e)
        {
            ShowEvents_Dic1();
            ShowEvents_Dic2();
             
            this.Refresh();
        }

        //Takes a list of coordinates fro GPX file to plot the route
        public void TrackList(List<PointLatLng> tracks)
        {
            double lat1 = tracks.ElementAt(0).Lat;
            double lng1 = tracks.ElementAt(0).Lng;
            double lat2 = tracks.ElementAt(1).Lat;
            double lng2 = tracks.ElementAt(1).Lng;

            PlotTrack(lat1, lng1, lat2, lng2);
        }


        //Source: http://www.independent-software.com/gmap-net-tutorial-maps-markers-and-polygons.html
        //Draws a line to represent tracklog
        private void PlotTrack(double lat1, double lng1, double lat2, double lng2)
        {
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(lat1, lng1));
            points.Add(new PointLatLng(lat2, lng2));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Tomato));
            polygon.Stroke = new Pen(Color.Red, 4);
            polyOverlay.Polygons.Add(polygon);
            map.Position = points.ElementAt(0);
            map.MinZoom = 1;
            map.MaxZoom = 100;
            map.Zoom = 10;
            map.Overlays.Add(polyOverlay);

            this.Show();
        }


        private void Map_Load(object sender, EventArgs e)
        {

        }

    }
}
