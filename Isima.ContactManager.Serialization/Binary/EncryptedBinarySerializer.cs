using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Serialization.Binary
{
    public class EncryptedBinarySerializer : IDatabaseSerializer
    {
        private string key = null;

        public EncryptedBinarySerializer(string password)
        {
            this.key = password;
        }

        public Data.Database Load(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            if (!System.IO.File.Exists(fileName))
                throw new ArgumentOutOfRangeException("fileName");

            using (System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                using (SymmetricAlgorithm algorithm = SymmetricAlgorithmFactory.Create(this.key))
                {
                    using (CryptoStream encryptedFile = new CryptoStream(file, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return (Data.Database)formatter.Deserialize(encryptedFile);
                    }
                }
            }
        }

        public void Save(string fileName, Data.Database data)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            using (System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                using (SymmetricAlgorithm algorithm = SymmetricAlgorithmFactory.Create(this.key))
                {
                    using (CryptoStream encryptedFile = new CryptoStream(file, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(encryptedFile, data);
                    }
                }
            }
        }
    }
}
