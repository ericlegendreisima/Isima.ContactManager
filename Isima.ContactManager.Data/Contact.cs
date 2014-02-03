using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Data
{
    [Serializable]
    public class Contact : Node
    {
        private string firstName = null;
        private string email = null;
        private string company = null;
        private LinkType link = LinkType.Network;

        [System.Xml.Serialization.XmlAttribute]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [System.Xml.Serialization.XmlAttribute]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [System.Xml.Serialization.XmlAttribute]
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        [System.Xml.Serialization.XmlAttribute]
        public LinkType Link
        {
            get { return link; }
            set { link = value; }
        }

        public override void Write(StringBuilder builder, int depth)
        {
            builder.AppendFormat("{0}| [C] {1}, {2} ({3}), Email:{4}, Link:{5}", new string(' ', depth), this.Name, this.FirstName, this.Company, this.Email, this.Link);
            builder.AppendLine();
        }
    }
}
