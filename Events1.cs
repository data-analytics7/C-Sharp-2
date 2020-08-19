using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapApplication
{
    class Events1    //For Tweet and FB type event
    {
        string eventid;
        string eventType;
        string text;
        string latitude;
        string longitude;
        string datetimestamp;

        public string getEventID()
        {
            return eventid;
        }
        public string getEventType()
        {
            return eventType;
        }
        public string getText()
        {
            return text;
        }
        public string getLatitude()
        {
            return latitude;
        }
        public string getLongitude()
        {
            return longitude;
        }

        public string getDateTimeStamp()
        {
            return datetimestamp;
        }
      

        /****Setters*****/
        public void setEventID(string eventid)
        {
            this.eventid = eventid;
        }

        public void setEventType(string eventType)
        {
            this.eventType = eventType;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        public void setLatitude (string latitude)
        {
            this.latitude = latitude;
        }

        public void setLongitude(string longitude)
        {
            this.longitude = longitude;
        }

        public void setDateTimeStamp(string datetimestamp)
        {
            this.datetimestamp = datetimestamp;
        }

       
    }
}
