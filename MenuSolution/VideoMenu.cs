using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Console;


namespace MenuSolution
{
    internal class VideoMenu
    {
        #region Properties

        static List<Video> videos = new List<Video>();

        #endregion

        private static void Main()
        {
            Video v = new Video();

            #region menuItems


            string[] menuItems =
            {
                "Home",
                "Video List",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };
            #endregion

            #region Menu Switch

            // Show Menu
            WriteLine("What are we watching today?");
            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {

                switch (selection)
                {
                    case 1:
                        WriteLine("Home");
                        WriteLine("All available options:");
                        ShowMenu(menuItems);
                        break;
                    case 2:
                        ListVideos();
                        break;
                    case 3:
                        WriteLine("Add Video");
                        while (AddVideos() == true)
                        {
                            AddVideos();
                        }
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


        #endregion

        #region Display all menu items and read user input

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
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
            {
                WriteLine("\nYou need to select a number between 1 and 5!");
                Write("Choose one: ");
            }
            WriteLine("\nSelected: " + selection);
            WriteLine("----------------------");

            return selection;
        }
        #endregion

        #region List Videos

        private static void ListVideos()
        {
            WriteLine("\nList of Videos:\n");
            foreach (var video in videos)
            {
                WriteLine($"{(videos.Count)}: {video.Title}");
            }
            WriteLine("\n");
        }

        #endregion


        #region Add Videos

        private static Boolean AddVideos()
        {
            Write("Video Title: ");
            var title = ReadLine();

            if (!string.IsNullOrEmpty(title))
            {
                videos.Add(new Video()
                {
                    Title = title
                });

                Write("\nDo you want to add another video? [Y/N]");
                if (ReadLine() == "y")
                {
                    return true;
                }

                if (ReadLine() == "n")
                {
                    return false;
                }

            }

            return true;
        }

        #endregion //Add Videos


    }
}