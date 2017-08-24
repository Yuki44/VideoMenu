using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VideoMenuBLL;
using VideoMenuEntity;
using static System.Console;

namespace VideoMenuUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();


        static void Main(string[] args)
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
                        while (AddVideos())
                        {
                            WriteLine("Adding a new video...\n");
                        }
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    case 5:
                        EditVideo();
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
            foreach (var video in bllFacade.GetVideoService().GetAll())
            {
                WriteLine($"{(video.Id)}: {video.Title}");
            }
            WriteLine("\n");
        }

        #endregion

        #region Find Video

        private static Video FindVideoById()
        {
            WriteLine("Insert Video number: ");
            int id;
            while (!int.TryParse(ReadLine(), out id))
            {
                WriteLine("Please insert a number");
            }


            return bllFacade.GetVideoService().Get(id);
        }

        #endregion //Find Video

        #region Add Videos

        private static bool AddVideos()
        {
            Write("Video Title: ");
            var title = ReadLine();

            if (!string.IsNullOrEmpty(title))
            {
                // Call BLL Facade to add video
                bllFacade.GetVideoService().Create(new Video()
                {
                    Title = title
                });

                Write("\nDo you want to Add another video? [Y], or press any key...");
                /// <summary>Another possibility</summary>
                //var input = ReadLine().ToLower();
                //if (input == "y")
                //{
                //    return true;
                //}
                //else if (input == "n")
                //{

                //    return false;
                //}
                ///
                return ReadLine().ToLower() == "y";
            }

            return true;
        }
        #endregion //Add Videos


        #region Delete Videos


        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            bllFacade.GetVideoService().Delete(videoFound.Id);
        }


        #endregion //Delete Videos

        #region Edit Video

        private static void EditVideo()
        {
            var video = FindVideoById();

            Write("\nVideo Title: ");
            video.Title = ReadLine();
        }

        #endregion //Edit Video
    }
}

