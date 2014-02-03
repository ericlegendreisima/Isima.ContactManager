using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isima.ContactManager.Data;

namespace Isima.ContactManager.Serialization.Xml
{
    public class DatabaseXmlSerializer : IDatabaseSerializer
    {
        public DatabaseXmlSerializer()
        {
        }

        public Data.Database Load(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            if (!System.IO.File.Exists(fileName))
                throw new ArgumentOutOfRangeException("fileName");

            using (System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Database));
                return (Database)serializer.Deserialize(file);
            }
        }

        public void Save(string fileName, Data.Database data)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            using (System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Database));
                serializer.Serialize(file, data);
            }
        }
    }
}
