using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace OGS_FinalProgram_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //IncidentReporting();
           username();
            //MainMenu();
            // URL();
          // attendance();



            static void username()
            {
                string username = "";
                string password = "";

                Console.WriteLine("\nHello and Welcome to The Yard!");
                Console.WriteLine("Please enter a username");
                username = Console.ReadLine();
                Console.WriteLine("Please enter a password");
                password = Console.ReadLine();

                if (username == "admin" && password == "pw")    //== means answer given by user matches the answer stored in the condition
                {
                    Console.WriteLine("You have entered the correct credentials");
                    Console.WriteLine("Welcome!!");
                }
                else 
                {
                    Console.WriteLine("Invalid credentials");//not coming up on console //needs to exit if invalid details
                }


                //Console.Clear(); // Built in method  that clears text from the console
               
                //need to implment an exit function
            }
        } 
        static void MainMenu()
        {

            Console.WriteLine("\n=======Menu Option========");
            Console.WriteLine("1: Attendance Monitoring");
            Console.WriteLine("2: Attendee Registration");
            Console.WriteLine("3: Incident Reporting");
            Console.WriteLine("4: Entry Cost Calculator");
            Console.WriteLine("5: URL Link");
            Console.WriteLine("6: Exit");

            Console.WriteLine("Please choose an option from the menu above");
            string selectOption = Console.ReadLine();           //allows user to enter an option and brings up the appropriate application

            if (selectOption == "1")
            {
                Console.WriteLine("You have chosen to monitor attendance");
                attendance();
            }
            else if (selectOption == "2")
            {
                Console.WriteLine("You have chosen to register attendees");
            }
            else if (selectOption == "3")
            {
                Console.WriteLine("You have chosen to report an incident");
            }
            else if (selectOption == "4")
            {
                Console.WriteLine("You have chosen to calculate entry cost");
            }
            else if (selectOption == "5")
            {
                Console.WriteLine("You have chosen to vist a URL link");
                //URL();
            }
            else
            {
                //Environment.ExitCode();
            }

        }

        static void attendance()
        {
            //record no of people, user needs to enter a figure
            //needs to have two parts; part a for adding people, part b for removing people

            Console.WriteLine("Press a to add the number of attendees or b to remove attendees");
            string choice =Console.ReadLine();


            float totalcapacity = 0f;       //float is used as % returns a decimal
          //  float removedguests = 0;
            float maxcapacity = 125f;       //maximum number of guests allowed in the building
            int currentcapacity = 0;
            float percentage = 0f;

            
            while (choice == "a" && percentage < 1)
            {

                Console.WriteLine("Enter the number of attendees");
                currentcapacity = int.Parse(Console.ReadLine());
                totalcapacity = totalcapacity + currentcapacity;
                percentage = totalcapacity / maxcapacity;

                if (percentage < 1)
                {
                    Console.WriteLine($"The Yard is at {percentage * 100}% capacity");
                    Console.WriteLine("press a to add more attendees or anything else to exit");
                    choice = Console.ReadLine();
                }
                else
                    Console.WriteLine("Sorry, we are full.");
                  

            }
            // else if (choice == 2)
            
            //while (choice == "b" && percentage > 1)
            //{
            //    Console.WriteLine("Enter the number of attendees leaving the premises");
            //    removedguests = int.Parse(Console.ReadLine());
            //    // totalcapacity = totalcapacity + currentcapacity;
            //    //percentage = totalcapacity / maxcapacity;
            //    maxcapacity = totalcapacity - removedguests;
            //    percentage = removedguests / maxcapacity;
            //}

            
            //    if (percentage > 1)
            //    {
            //        Console.WriteLine($"The Yard is at {percentage * 100}% capacity");
            //        // Console.WriteLine("press 1 to add more attendees or anything else to exit");
            //        //choice = int.Parse(Console.ReadLine());
            //    }




                //need calculations to add and subtract attendants
                //display capacity in % everytime a value is entered
            }
            static void URL()
            {
                Console.WriteLine("Press a. to access The Yard`s main website");
                Console.WriteLine("Press b. to access The Yard`s twitter page");
                Console.WriteLine("Press c. to search for something on google");
                Console.WriteLine("Press d. to go back to the main menu");

                string input = Console.ReadLine();
                if (input == "a")
                {
                    Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://theyardmcr.com/");   //allows user to access the website of The Yard
                }
                else if (input == "b")
                {
                    Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://twitter.com/theyard_mcr");     //venue twitter page
                }
                else if (input == "c")
                { //need a google url; searches for what user enters. 
                    Console.WriteLine("Enter a word you would like to search on Google");
                    string word = Console.ReadLine();
                    Console.WriteLine();
                    Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", $"https://www.google.com/search?q={word}"); //program exits after search
                }
                else if (input == "d")
                {
                    MainMenu();//not coming up after google search
                }


                
            }
        static void IncidentReporting()
        {
            var names = new List<string> { "" };
            
            Console.WriteLine("Please enter the name of staff member writing the report");
                string name = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter("../../../IncidentReport.txt", true))
            {
              

                //                Automatically store the time and date of the incident
               
                //• The name of the staff member reporting the incident
                //• Allows the user to enter a short message 
                
                //string[] names = new string[125];   //does it have to have a no in the []?
               
               

               
                //for (int i = 0; i < 125; i++)
                //{
                //    names[i] = Console.ReadLine();
                //}
                //StreamWriter sw = new StreamWriter(@"IncidentReport.txt");

                //for (int i = 0; i < 125; i++)
                //{
                //    sw.WriteLine(names[i]);
                //}
                //sw.Close();
            }

        }
        }
    }
