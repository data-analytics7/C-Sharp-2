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
    public partial class EventInfo1 : Form
    {
        Dictionary<string, Events1> Dic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> Dic2 = new Dictionary<string, Events2>();

        string myKey;

        public EventInfo1()
        {
            InitializeComponent();
        }

        private void EventInfo_Load(object sender, EventArgs e)
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
            //MessageBox.Show(Dic1.Count + " " + Dic2.Count);
            var eventid = Dic1[myKey].getEventID();
            var eventtype = Dic1[myKey].getEventType();
            var lat = Dic1[myKey].getLatitude();
            var lng = Dic1[myKey].getLongitude();
            var text = Dic1[myKey].getText();
            var date = Dic1[myKey].getDateTimeStamp();

            label1.Text = "Event ID: " +eventid + "\nEvent type: " + eventtype + "\nLatitude: " + lat + "\nLongitude: "+lng + "\nText: " + text + "\nDate timestamp: " + date;

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
