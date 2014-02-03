using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 1)
            {
                Controller.InitializeDefaultDatabase();
            }
            else
            {
                string fileName = args[0];
                Controller.LoadDatabase(fileName);
            }
            RunConsole();
        }

        static private void RunConsole()
        {
            const string Invite = ">";
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Invite);
                string commandLine = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;
                string[] commandItems = commandLine.Split(' ');
                try
                {
                    if (commandItems != null && commandItems.Length > 0)
                    {
                        switch (commandItems[0].ToLower())
                        {
                            case "sortir":
                            case "bye":
                                Console.WriteLine("Fin du programme.");
                                exit = true;
                                break;
                            case "afficher":
                                Controller.DisplayDatabase();
                                break;
                            case "charger":
                                Controller.LoadDatabase(commandItems);
                                break;
                            case "enregistrer":
                                Controller.SaveDatabase(commandItems);
                                break;
                            case "ajouterdossier":
                                Controller.AddFolder(commandItems);
                                break;
                            case "ajoutercontact":
                                Controller.AddContact(commandItems);
                                break;
                            default:
                                Console.WriteLine("Instruction inconnue.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
