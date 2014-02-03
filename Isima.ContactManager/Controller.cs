using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isima.ContactManager.Data;
using Isima.ContactManager.Serialization;

namespace Isima.ContactManager
{
    internal class Controller
    {
        private const string defaultFileName = "ContactManager.db";
        private static string defaultPassword = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;

        static private Database contactDb = null;
        static private Folder currentFolder = null;

        static private Folder CurrentFolder
        {
            get
            {
                if (currentFolder == null)
                    currentFolder = contactDb.Root;
                return currentFolder;
            }
        }

        static private string DefaultFilePath
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), defaultFileName);
            }
        }

        static private string GetFileName(string[] commandItems)
        {
            string fileName = null;
            if (commandItems.Length > 1)
            {
                fileName = commandItems[1];
            }
            else
            {
                fileName = DefaultFilePath;
            }
            return fileName;
        }

        static internal void InitializeDefaultDatabase()
        {
            contactDb = Database.CreateDefault();
        }

        static internal void LoadDatabase(string[] commandItems)
        {
            LoadDatabase(GetFileName(commandItems));
        }

        static internal void LoadDatabase(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Fichier inexistant.");
            }
            else
            {
                Console.WriteLine("Lecture du fichier '{0}'...", fileName);

                IDatabaseSerializer serializer = DatabaseSerializerFactory.Create(defaultPassword);
                contactDb = serializer.Load(fileName);

                currentFolder = null;

                Console.WriteLine("Fichier '{0}' lu.", fileName);
            }
        }

        static internal void SaveDatabase(string[] commandItems)
        {
            string fileName = GetFileName(commandItems);

            Console.WriteLine("Enregistrement du fichier '{0}'...", fileName);

            IDatabaseSerializer serializer = DatabaseSerializerFactory.Create(defaultPassword);
            serializer.Save(fileName, contactDb);

            Console.WriteLine("Fichier '{0}' enregistré.", fileName);
        }

        static internal void DisplayDatabase()
        {
            Console.WriteLine(contactDb.ToString());
        }

        internal static void AddFolder(string[] commandItems)
        {
            if (commandItems.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Le nom du dossier n'a pas été précisé. Opération annulée.");
            }
            else
            {
                Folder newFolder = new Folder 
                { 
                    Name = commandItems[1], 
                    Creation = DateTime.Now 
                };
                CurrentFolder.SubFolders.Add(newFolder);

                Console.WriteLine("Dossier '{0}' ajouté sous {1} en position {2}.", newFolder.Name, currentFolder.Name, currentFolder.SubFolders.Count);

                currentFolder = newFolder;
            }
        }

        internal static void AddContact(string[] commandItems)
        {
            if (commandItems.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Nombre de paramètres insuffisants. Opération annulée.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Usage: AjouterContact Nom Prénom Société Courriel {0}", string.Join("|", Enum.GetValues(typeof(LinkType))));
            }
            else
            {
                Contact newContact = new Contact 
                { 
                    Name = commandItems[1], 
                    Creation = DateTime.Now,
                    FirstName = commandItems[2],
                    Company = commandItems[3],
                    Email = commandItems[4],
                    Link = (LinkType)Enum.Parse(typeof(LinkType), commandItems[5]),
                };
                CurrentFolder.Contacts.Add(newContact);

                Console.WriteLine("Contact '{0}' ajouté sous {1} en position {2}.", newContact.Name, CurrentFolder.Name, CurrentFolder.Contacts.Count);
            }
        }
    }
}
