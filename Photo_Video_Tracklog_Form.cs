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
    public partial class Photo_Video_Tracklog_Form : Form
    {
        string eve_type;
        Dictionary<string, Events1> Dic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> Dic2 = new Dictionary<string, Events2>();
        double X, Y; //lat and long

        bool flag = false; //Will become true when new event gets added to dictionary;

        public Photo_Video_Tracklog_Form()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = dialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured");
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string date = Convert.ToString(dateTimePicker1.Value);
            string filepath = textBox1.Text;

            var eventCounter = Dic1.Count + Dic2.Count + 2;

            //Write to xml file
            WriteToXML(filepath, date, eventCounter + 1, eve_type);

            //Set event information into Events2 class
            Events2 obj = new Events2();
            obj.setStartTimeStamp(date);
            obj.setEndTimeStamp(date);
            obj.setEventID(("ID" + (eventCounter + 1)));
            obj.setEventType(eve_type);
            obj.setLatitude(Convert.ToString(X));
            obj.setLongitude(Convert.ToString(Y));

            Dic2.Add(("ID" + (eventCounter+1)), obj);

            ChoiceForm f2 = new ChoiceForm();

            //Set values into dictionary
            Database db = new Database();
            db.setDictionaries(Dic1, Dic2);

            f2.setPhotoVideoTracklogFlag(true);

            this.Hide();
        }

        private void Photo_Video_Tracklog_Form_Load(object sender, EventArgs e)
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
        //Writing to xml file
        private void WriteToXML(string filepath, string date, int eventCounter, string eve_type)
        {
            XNamespace empNM = "urn:lst-emp:emp";
            XDocument xDoc = new XDocument(
            new XDeclaration("1.0", "UTF-16", null),
            new XElement("Event",
            new XElement("eventid", ("ID" + (eventCounter))),
            new XElement(eve_type,
            new XElement("filepath", filepath),
            new XElement("start-time",
            new XElement("datetimestamp", date)),
            new XElement("end-time",
            new XElement("datetimestamp", date))
            )));
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
