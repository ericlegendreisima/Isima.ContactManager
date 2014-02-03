using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Data
{
    [Serializable]
    public class Folder : Node
    {
        private List<Folder> subFolders = new List<Folder>();
        private List<Contact> contacts = new List<Contact>();

        public Folder()
            : base()
        {
        }

        public List<Folder> SubFolders
        {
            get { return subFolders; }
            set { subFolders = value; }
        }

        public List<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        public override void Write(System.Text.StringBuilder builder, int depth)
        {
            builder.AppendFormat("{0}[D] {1} (création {2})", new string(' ', depth), this.Name, this.Creation);
            builder.AppendLine();
            foreach (Contact contact in this.contacts)
            {
                contact.Write(builder, depth);
            }
            foreach (Folder subFolder in this.subFolders)
            {
                subFolder.Write(builder, depth + 1);
            }
        }
    }
}
