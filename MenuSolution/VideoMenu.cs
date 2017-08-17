using System;
using System.Linq.Expressions;
using static System.Console;


namespace MenuSolution
{
    internal class VideoMenu
    {
        private static void Main()
        {
            string[] menuItems =
            {
                "Home",
                "Video List",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };
            // Show Menu
            WriteLine("What are we watching today?");
            var selection = ShowMenu(menuItems);
            
            while(selection != 6)
            {
                
            switch (selection)
            {
                case 1:
                    WriteLine("Home");
                    WriteLine("All available options:");
                    ShowMenu(menuItems);
                    break;
                case 2:
                    WriteLine("Video List");
                    break;
                case 3:
                    WriteLine("Add Video");
                    break;
                case 4:
                    WriteLine("Delete Video");
                    break;
                case 5:
                    WriteLine("Edit Video");
                    break;
               default:
                    break;
                    
            }
                WriteLine("----------------------");
                 selection = ShowMenu(menuItems);
                WriteLine("----------------------");
        }
            
            WriteLine("See you soon!\n");
            WriteLine("----------------------");
            WriteLine("Press any key...\n");
            ReadKey();
            Environment.Exit(0);

      
        }

        //MARK: Private methods

        private static int ShowMenu(string[] menuItems)
        {
           
           
            WriteLine("");

            for (var i = 0; i < menuItems.Length; i++)
            {
                WriteLine($"{(i + 1)}: {menuItems[i]}");
            }
            
            WriteLine("");
            Write("Choose one: ");
            

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection <1 || selection >6)
            {
                WriteLine("\nYou need to select a number between 1 and 5!");
                Write("Choose one: ");
            }
            WriteLine("\nSelected: " + selection);
            WriteLine("----------------------");
            
            return selection;
        }
    }
}