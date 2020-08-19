using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MapApplication
{   
    //Takes user input to add new Facebook and Twitter events 
    public partial class Twitter_FB_Form : Form
    {
        string eve_type;
        Dictionary<string, Events1> Dic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> Dic2 = new Dictionary<string, Events2>();
        double X, Y; //lat and long

        bool flag = false; //Will become true when new event gets added to dictionary;

        public Twitter_FB_Form()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string date = Convert.ToString(dateTimePicker1.Value);
            
            this.Hide();
            var eventCounter = Dic1.Count + Dic2.Count + 2;


            //Write to xml file
            WriteToXML(text, date, eventCounter + 1, eve_type, X, Y);

            //Set event information into Events1 class
            Events1 obj = new Events1();
            obj.setText(text);
            obj.setDateTimeStamp(date);
            obj.setEventID(("ID" + (eventCounter+1)));
            obj.setEventType(eve_type);
            obj.setLatitude(Convert.ToString(X));
            obj.setLongitude(Convert.ToString(Y));

            Dic1.Add(("ID" + (eventCounter+1)), obj);

            ChoiceForm f2 = new ChoiceForm();

            //Set values into dictionary
            Database db = new Database();
            db.setDictionaries(Dic1, Dic2);

            f2.setTwitterFBFlag(true);
        }

        private void Twitter_FB_Form_Load(object sender, EventArgs e)
        {

        }

        public void setEventType(string eve)
        {
            this.eve_type = eve;
        }

        internal void setDictionary(Dictionary<string, Events1> Dic1, Dictionary<string, Events2> Dic2)
        {
            this.Dic1 = Dic1;
            this.Dic2 = Dic2;
        }

        public void setLatLng(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public bool getFlag()
        {
            return flag;
        }

        //Source: https://web.csulb.edu/~pnguyen/cecs475/pdf/linqtoxmlnew.pdf
        //Writing to XML file
        private void WriteToXML(string text, string date, int eventCounter , string eve_type, double X, double Y)
        {
            XNamespace empNM = "urn:lst-emp:emp";
            XDocument xDoc = new XDocument(
            new XDeclaration("1.0", "UTF-16", null),
            new XElement("Event",
            new XElement("eventid", ("ID" + (eventCounter))),
            new XElement(eve_type,
            new XElement("text", text),
            new XElement("location",
            new XElement("lat", X),
            new XElement("lng", Y)
            ))));
            StringWriter sw = new StringWriter();
            XmlWriter xWrite = XmlWriter.Create(sw);


            xDoc.Save(xWrite);
            xWrite.Close();
            // Save to Disk
            xDoc.Save("..\\..\\..\\Data\\NewEvent.xml");
            //Console.WriteLine("Saved");
        }
    }
}
