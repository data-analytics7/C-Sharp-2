using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapApplication
{
    //Dictionary class
    class Database
    {
        Dictionary<string, Events1> DataDic1 = new Dictionary<string, Events1>();
        Dictionary<string, Events2> DataDic2 = new Dictionary<string, Events2>();

        public void setDictionaries(Dictionary<string, Events1> Dic1, Dictionary<string, Events2> Dic2)
        {
            this.DataDic1 = Dic1;
            this.DataDic2 = Dic2;
        }

        public Dictionary<string, Events1> getDataDictionary1()
        {
            return DataDic1;
        }

        public Dictionary<string, Events2> getDataDictionary2()
        {
            return DataDic2;
        }

    }
}
