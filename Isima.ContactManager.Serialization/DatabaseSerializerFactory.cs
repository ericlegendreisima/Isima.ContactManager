using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Serialization
{
    public class DatabaseSerializerFactory
    {
        static public IDatabaseSerializer Create(string password)
        {
            // return new Isima.ContactManager.Serialization.Binary.BinarySerializer();
            // return new Isima.ContactManager.Serialization.Xml.DatabaseXmlSerializer();
            return new Isima.ContactManager.Serialization.Binary.EncryptedBinarySerializer(password);
        }
    }
}
