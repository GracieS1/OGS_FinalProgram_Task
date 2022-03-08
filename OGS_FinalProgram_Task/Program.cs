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

            //username();
            //MainMenu();
            //OpenVenue();
            IncidentReporting();
            Console.ReadLine();
            // URL();




            
        }

        static void username()
        {
            string username = "";
            string password = "";
            Console.ForegroundColor = ConsoleColor.Blue;

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
                IncorrectInputWarning();
                Console.WriteLine("You have one more attempt");
                // username();   need to call username again but coming with errors
                Console.WriteLine("You will now be logged out of the system");
                System.Environment.Exit(0);
                //not coming up on console //needs to exit if invalid details
            }
            Console.Clear(); // Built in method  that clears text from the console
        }

        static void MainMenu()
        {

            Console.WriteLine("\n=======Menu Option========");
            Console.WriteLine("1: Attendance Monitoring");
            // Console.WriteLine("2: Attendee Registration");
            Console.WriteLine("3: Incident Reporting");
            // Console.WriteLine("4: Entry Cost Calculator");
            Console.WriteLine("5: URL Link");
            Console.WriteLine("6: Exit");

            Console.WriteLine("Please choose an option from the menu above");
            string selectOption = Console.ReadLine();           //allows user to enter an option and brings up the appropriate application

            if (selectOption == "1")
            {
                Console.WriteLine("You have chosen to monitor attendance");
                Console.Clear();
                OpenVenue();
                Console.Clear();

            }
            else if (selectOption == "2")
            {
                Console.WriteLine("You have chosen to register attendees");//not doing, need to remove
            }
            else if (selectOption == "3")
            {
                Console.WriteLine("You have chosen to report an incident");
                IncidentReporting();
                Console.Clear();
                MainMenu();
            }
            else if (selectOption == "4")
            {
                Console.WriteLine("You have chosen to calculate entry cost");//not doing, need to remove
            }
            else if (selectOption == "5")
            {
                Console.WriteLine("You have chosen to vist a URL link");
                URL();
                MainMenu();
            }
            else
            {
                System.Environment.Exit(0);
            }

        }

        static void IncidentReporting()
        {//need date and time
            Console.ForegroundColor = ConsoleColor.Magenta;
            //int hourOfDay = System.DateTime.Now.Hour; //Gets the current hour of day 
            //use utc now




            using StreamWriter streamWriter = new(@"C:\Users\grace\source\repos\OGS_FinalProgram_Task\OGS_FinalProgram_Task\IncidentReport.txt", append: true);
            Console.WriteLine("\n========Incident Reporting Menu============");
            Console.WriteLine("Please enter the name of staff member writing the report and press enter. OR 'q' or 'quit' to exit");

            var input = Console.ReadLine();

            var trimmedInput = input.ToLowerInvariant().Trim(); //to lowervariant allows any uppercase letters to be converted to lower case

            if (trimmedInput == "q" || trimmedInput == "quit")  //trim eliminates any empty spaces the user might have inputted on the console
            {
                return;
            }

            streamWriter.WriteLine(input);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();

        }


        static void OpenVenue()         //helps to reduce errors entered from users on the console
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var attendeeCounter = new AttendeeCounter();

            while (true)
            {
                attendeeCounter.PrintInstruction();

                var input = Console.ReadLine();

                var trimmedInput = input.ToLowerInvariant().Trim();

                if (attendeeCounter.IsStringInputValid(input))
                {
                    if (trimmedInput == "a" || trimmedInput == "add")
                    {
                        Console.WriteLine("Please enter the amount of attendees you wish to add");

                        var addInput = Console.ReadLine();

                        var trimmedAddInput = addInput.Trim();

                        if (attendeeCounter.IsIntInputValid(trimmedAddInput))
                        {
                            attendeeCounter.AddAttendees(Int32.Parse(trimmedAddInput));
                            continue;
                        }
                        else
                        {
                            IncorrectInputWarning();
                            continue;
                        }

                    }

                    if (trimmedInput == "r" || trimmedInput == "remove")
                    {
                        Console.WriteLine("Please enter the amount of attendees you wish to remove");

                        var addInput = Console.ReadLine();

                        var trimmedAddInput = addInput.Trim();

                        if (attendeeCounter.IsIntInputValid(trimmedAddInput))
                        {
                            attendeeCounter.RemoveAttendees(Int32.Parse(trimmedAddInput));
                            continue;
                        }
                        else
                        {
                            IncorrectInputWarning();
                            continue;
                        }
                    }

                    if (trimmedInput == "q" || trimmedInput == "quit")
                    {
                        break;
                    }
                }
                else
                {
                    IncorrectInputWarning();
                    continue;
                }
            }

        }


        static void IncorrectInputWarning()     //alerts the user they have entered the wrong info and gives them a chance to re-enter the correct text or letter
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Beep();
            Console.WriteLine("Incorrect Input, press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static void URL()   //URL function starts here
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n=====URL Menu======");
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
            { // searches for what user enters. 
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



        public class AttendeeCounter    //attendance monitoring starts from here
        {
            private float TotalAttendees { get; set; }  //called from yardlocation

            private const int MaximumCapacity = 125;

            public void AddAttendees(int attendeeNumbers) //calculations for adding attendees
            {
                if (TotalAttendees + attendeeNumbers <= MaximumCapacity)
                {
                    TotalAttendees += attendeeNumbers;
                    PrintAttendeePercentage();
                    return; //performs the calculation over again as long as maximumcapacity is less/equal to 125
                }

                Console.WriteLine("You cannot exceed the maximum Attendees capacity of 125");
            }

            public void RemoveAttendees(int attendeeNumbers)    //calculations for removing attendees
            {
                if (TotalAttendees - attendeeNumbers >= 0)
                {
                    TotalAttendees -= attendeeNumbers;
                    PrintAttendeePercentage();
                    return;
                }

                Console.WriteLine("You cannot remove more Attendees than present");     //prevents number from entering negative
            }

            public void PrintAttendeePercentage()   //gives capacity in %
            {
                float attendeePercentage = (TotalAttendees / MaximumCapacity) * 100;

                Console.WriteLine($"Venue Capacity is at {attendeePercentage}%");
            }

            public void PrintInstruction()  //instructions for attendee menu
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n==========What would you like to do?===========");
                Console.WriteLine("Please enter 'a' or 'add' to add attendees to the venue");
                Console.WriteLine("Please enter 'r' or 'remove' to remove specified number of Attendees, followed by the amount.");
                Console.WriteLine("Please press 'q' or 'quit' to exit.");
                Console.WriteLine();
            }

            public bool IsStringInputValid(string input)        //validation commands
            {
                var validInput = new List<string> { "a", "add", "r", "remove", "q", "quit" };

                return validInput.Contains(input);
            }

            public bool IsIntInputValid(string input)
            {
                return Int32.TryParse(input, out _);    //prevents program from closing if user enters wrong input

            }
        }

    }
}


