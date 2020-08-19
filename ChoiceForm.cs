using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapApplication
{
    //Class to handle different user choices, and present forms accordingly
    public partial class ChoiceForm : Form
    {
        double X, Y;
        int eventCounter = 33; //for twiiter & Photo forms
        Dictionary<string, Events1> Dic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> Dic2 = new Dictionary<string, Events2>();

        bool TwitterFB_flag = false;
        bool PhotoVideoTracklog_flag = false;
        

        Form1 f1 = new Form1();
        public ChoiceForm()
        {
            InitializeComponent();
        }

        private void ChoiceForm_Load(object sender, EventArgs e)
        {

        }

        private void AddEvent_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, 1, button1.Height);
        }

        private void InspectEvent_Click(object sender, EventArgs e)
        {
            //To retrieve nearest event information
            FindNearestEvent();

            if (Dic1.ContainsKey(myKey) == true)
            {
                EventInfo1 f5 = new EventInfo1();
                f5.setDictionary(Dic1, Dic2);
                f5.setKey(myKey);
                f5.Show();
            }
            else
            {
                EventsInfo2 f5 = new EventsInfo2();
                f5.setDictionary(Dic1, Dic2);
                f5.setKey(myKey);
                f5.Show();
            }
            this.Hide();
        }


        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        string btnClicked;
        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            btnClicked = item.ToString();

            this.Hide();
        }

        private void TweetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Twitter_FB_Form f4 = new Twitter_FB_Form();
            f4.setEventType(btnClicked);
            f4.setLatLng(X, Y);
            f4.setDictionary(Dic1, Dic2); //Passing dictionaries to Twitter_FB_Form
            f4.Show();
            this.Hide();
        }

        private void FacebookstatusupdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Twitter_FB_Form f4 = new Twitter_FB_Form();
            f4.setEventType(btnClicked);
            f4.setLatLng(X, Y);
            f4.setDictionary(Dic1, Dic2); //Passing dictionaries to Twitter_FB_Form
            f4.Show();
            this.Hide();
        }

        private void PhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Photo_Video_Tracklog_Form f5 = new Photo_Video_Tracklog_Form();
            f5.setEventType(btnClicked);    
            f5.setLatLng(X, Y);
            f5.setDictionary(Dic1, Dic2); //Passing dictionaries to Photo_Video_tracklog form
            f5.Show();
            this.Hide();
        }

        private void VideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Photo_Video_Tracklog_Form f5 = new Photo_Video_Tracklog_Form();
            f5.setEventType(btnClicked);
            f5.setLatLng(X, Y);
            f5.setDictionary(Dic1, Dic2); //Passing dictionaries to Photo_Video_tracklog form
            f5.Show();
            this.Hide();
        }

        private void TracklogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Photo_Video_Tracklog_Form f5 = new Photo_Video_Tracklog_Form();
            f5.setEventType(btnClicked);
            f5.setLatLng(X, Y);
            f5.setDictionary(Dic1, Dic2); //Passing dictionaries to Photo_Video_tracklog form
            f5.Show();
            this.Hide();
        }

        public void setLatLng(double lat, double lng)
        {
            this.X = lat;
            this.Y = lng;
        }

        internal void setDictionary(Dictionary<string, Events1> Dic1, Dictionary<string, Events2> Dic2)
        {
            this.Dic1 = Dic1;
            this.Dic2 = Dic2;
        }

        string myKey;
        internal void FindNearestEvent()
        {
            Dictionary<string, double> DistanceDic = new Dictionary<string, double>();
            string eveid, evetype= " ";
            double lat, lng;
            var eCoord = new GeoCoordinate(X, Y);   //X Y coming from mouse click

            foreach (KeyValuePair<string, Events1> kvp in Dic1)
            {
                double dist;
                eveid = kvp.Key;
                evetype = kvp.Value.getEventType();
                lat = (Convert.ToDouble(kvp.Value.getLatitude()));
                lng = (Convert.ToDouble(kvp.Value.getLongitude()));

                dist = Math.Sqrt(((X - lat) * (X - lat)) + ((Y - lng) * (Y - lng)));    //distance to all the events in Dic1
                DistanceDic.Add(eveid, dist);

            }

            foreach (KeyValuePair<string, Events2> kvp in Dic2)
            {
                double dist;
                eveid = kvp.Key;
                evetype = kvp.Value.getEventType();
                lat = (Convert.ToDouble(kvp.Value.getLatitude()));
                lng = (Convert.ToDouble(kvp.Value.getLongitude()));

                dist = Math.Sqrt(((X - lat) * (X - lat)) + ((Y - lng) * (Y - lng)));    //distance to all the events in Dic2
                DistanceDic.Add(eveid, dist);

            }

            //Finding minimum of all the distance values in the dictionary
            var min = Convert.ToDouble(DistanceDic.Values.First());
            foreach (KeyValuePair<string, double> kvp in DistanceDic)
            {
                if (Convert.ToDouble(kvp.Value) < min) min = Convert.ToDouble(kvp.Value);
            }

            myKey = DistanceDic.FirstOrDefault(x => x.Value.Equals(min)).Key;

           // Console.WriteLine("least distance: {0} Key: {1} Event type: {2}", min, myKey, evetype);
        }

        public void setEventCounter(int e)
        {
            this.eventCounter = e;
        }


        public void setTwitterFBFlag(bool f)
        {
            this.TwitterFB_flag = f;
        }

        public void setPhotoVideoTracklogFlag(bool f)
        {
            this.PhotoVideoTracklog_flag = f;
        }

        public bool getTwitterFBFlag()
        {
            return TwitterFB_flag;
        }
        public bool getPhotoVideoTracklogFlag()
        {
            return PhotoVideoTracklog_flag;
        }
    }
}