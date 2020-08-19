using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapApplication
{
    public partial class EventsInfo2 : Form
    {
        Dictionary<string, Events1> Dic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> Dic2 = new Dictionary<string, Events2>();

        string myKey;

        public EventsInfo2()
        {
            InitializeComponent();
        }

        private void EventsInfo2_Load(object sender, EventArgs e)
        {
            ShowEventInfo();
        }

        internal void setDictionary(Dictionary<string, Events1> Dic1, Dictionary<string, Events2> Dic2)
        {
            this.Dic1 = Dic1;
            this.Dic2 = Dic2;
        }

        public void setKey(string mykey)
        {
            this.myKey = mykey;
        }

        private void ShowEventInfo()
        {
            var eventid = Dic2[myKey].getEventID();
            var eventtype = Dic2[myKey].getEventType();
            var lat = Dic2[myKey].getLatitude();
            var lng = Dic2[myKey].getLongitude();
            var filepath = Dic2[myKey].getFilePath();
            var startdate = Dic2[myKey].getStartTimeStamp();
            var enddate = Dic2[myKey].getEndTimeStamp();

            label1.Text = "Event ID: " + eventid + "\nEvent type: " + eventtype + "\nLatitude: " + lat + "\nLongitude: " + lng + "\nFile path: " + filepath + "\nStart Date timestamp: " + startdate + "\nEnd Date timestamp: " + enddate;

            if(eventtype.Equals("photo"))
            {
                media.Hide();
                Image photo = Image.FromFile(filepath);
                Bitmap resized = new Bitmap(photo, new Size(130, 90)); //Resizing the image
                pictureBox1.Image = new Bitmap(resized);
            }
            else if(eventtype.Equals("video"))
            {
                pictureBox1.Hide();
                media.Show();
                media.URL = filepath;
                media.Ctlcontrols.play();
            }
            else if(eventtype.Equals("tracklog"))
            {
                pictureBox1.Hide();
                media.Hide();
                GPXManager gp = new GPXManager();
                var point = gp.LoadGPXTracks(filepath);
                Form1 f1 = new Form1();
                f1.TrackList(point);
            }
        }

        
        private void Media_Enter(object sender, EventArgs e)
        {

        }

    }
}
