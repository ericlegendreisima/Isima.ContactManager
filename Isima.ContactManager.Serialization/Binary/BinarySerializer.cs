using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Serialization.Binary
{
    public class BinarySerializer : IDatabaseSerializer
    {
        public BinarySerializer()
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
                BinaryFormatter formatter = new BinaryFormatter();
                return (Data.Database)formatter.Deserialize(file);
            }
        }

        public void Save(string fileName, Data.Database data)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            using (System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, data);
            }
        }
    }
}
