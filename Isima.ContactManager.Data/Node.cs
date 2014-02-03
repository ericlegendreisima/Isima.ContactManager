using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Data
{
    [Serializable]
    public class Node
    {
        private string name = null;
        private DateTime creation = DateTime.Now;
        private Nullable<DateTime> modification = null;

        public Node()
        {
        }

        [System.Xml.Serialization.XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Creation
        {
            get { return creation; }
            set { creation = value; }
        }

        public Nullable<DateTime> Modification
        {
            get { return modification; }
            set { modification = value; }
        }

        public virtual void Write(StringBuilder builder, int depth)
        {
            builder.AppendFormat("{0}| Noeud {1} (création {2:D}, modification {3:D})", new string(' ', depth), this.name, this.creation, this.modification);
            builder.AppendLine();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Write(builder, 0);
            return builder.ToString();
        }

    }
}
