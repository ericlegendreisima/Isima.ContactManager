using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Data
{
    [Serializable]
    public class Database
    {
        private Folder root = null;

        public Database()
        {
            root = new Folder { Name = "Root" };
        }

        public Folder Root
        {
            get { return root; }
            set { root = value; }
        }

        static public Database CreateDefault()
        {
            return new Database();
        }

        public override string ToString()
        {
            string result = null;
            
            if (root != null)
                result = root.ToString();
            
            return result;
        }
    }
}
