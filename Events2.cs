using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapApplication
{
    class Events2   //For Photo, Video and Tracklog type events
    {
        string eventid;
        string eventType;
        string latitude;
        string longitude;
        string starttimestamp;
        string endtimestamp;
        string filepath;

        public string getEventID()
        {
            return eventid;
        }

        public string getEventType()
        {
            return eventType;
        }

        public string getLatitude()
        {
            return latitude;
        }
        public string getLongitude()
        {
            return longitude;
        }

        public string getStartTimeStamp()
        {
            return starttimestamp;
        }

        public string getEndTimeStamp()
        {
            return endtimestamp;
        }

        public string getFilePath()
        {
            return filepath;
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

        public void setLatitude(string latitude)
        {
            this.latitude = latitude;
        }

        public void setLongitude(string longitude)
        {
            this.longitude = longitude;
        }

        public void setStartTimeStamp(string starttimestamp)
        {
            this.starttimestamp = starttimestamp;
        }

        public void setEndTimeStamp(string endtimestamp)
        {
            this.endtimestamp = endtimestamp;
        }

        public void setFilePath(string filepath)
        {
            this.filepath = filepath;
        }

    }
}
