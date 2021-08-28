using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2._1
{
    class Program
    {
        List<Ball> list = new List<Ball>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            bool quit = false;
            while (quit == false)
            {
                quit = mainMenu();
            }
            Console.Clear();
            Console.WriteLine("Program is closing...");
            Console.ReadLine();
        }
      
        bool mainMenu()
        {
            bool exit = false;

            Console.Clear();
            Console.WriteLine(" Ball Thrower\n" +
                "-----------------\n" +
                "1. Create Ball\n" +
                "2. Modify Ball\n" +
                "3. Show Ball(s)\n" +
                "4. Throw Ball\n" +
                "5. Quit\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "c":
                case "create":
                    create();
                    break;
                case "2":
                case "m":
                case "modify":
                    while (exit == false)
                    {
                        exit = modify();
                    }
                    break;
                case "3":
                case "s":
                case "show":
                    listAll();
                    if (list.Count != 0)
                    {
                        Console.Write("\nPress 'Enter' to continue");
                        Console.ReadLine();
                    }
                    break;
                case "4":
                case "t":
                case "throw":
                    while (exit == false)
                    {
                        exit = throwBall();
                    }
                    break;
                case "5":
                case "q":
                case "quit":
                    return true;
                default:
                    unknownCmd();
                    break;
            }
            return false;
        }
       
        void create()
        {
            float ra;
            int[] rgba = new int[4];
            string[] message = new string[] { "Radius: ", "Red: ", "Green: ", "Blue: ", "Alpha: " };

            Console.Clear();
            Console.WriteLine(" Create a ball:\n----------------------");
            ra = giveValueFloat(message[0]);

            Console.WriteLine("\nColor (RGBa) [Max is 255]");
            for (int i = 0; i < rgba.Length; i++)
            {
                rgba[i] = giveValueInt(message[i + 1]);
            }

            if (rgba[3] == int.MaxValue)
            {
                list.Add(new Ball(ra, new Color(rgba[0], rgba[1], rgba[2])));
            }
            else
            {
                list.Add(new Ball(ra, new Color(rgba[0], rgba[1], rgba[2], rgba[3])));
            }
            Console.WriteLine("\nBall created successfully!");
            Console.ReadLine();
        }
        int giveValueInt(string message)
        {
            string temp = " ";
            while (true)
            {
                try
                {
                    Console.Write(message + "\t");
                    temp = Console.ReadLine();
                    if (int.Parse(temp) > 255 || int.Parse(temp) < 0)
                    {
                        temp = " ";
                    }
                    return int.Parse(temp);
                }
                catch
                {
                    if (temp == "" && message == "Alpha: ")
                    {
                        Console.WriteLine("\n(Alpha value is set to 255)");
                        return int.MaxValue;
                    }
                    tryAgain();
                }
            }
        }
        float giveValueFloat(string message)
        {
            string temp;
            while (true)
            {
                try
                {
                    Console.Write(message);
                    temp = Console.ReadLine();
                    if (float.Parse(temp) < 0)
                    {
                        temp = " ";
                    }
                    return float.Parse(temp);
                }
                catch
                {
                    tryAgain();
                }
            }
        }
      

        bool modify()
        {
            bool back = false;
            Console.Clear();
            Console.WriteLine(" Modify Ball\n" +
                "-----------------\n" +
                "1. Change Radius\n" +
                "2. Change Color\n" +
                "3. Delete ball\n" +
                "4. Go back\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "r":
                case "radius":
                    Console.Clear();
                    if (list.Count == 0)
                    {
                        ballCheck();
                    }
                    else
                    {
                        int index = pickBall();
                        while (back == false)
                        {
                            back = radius(index);
                        }
                    }
                    break;
                case "2":
                case "c":
                case "color":
                    Console.Clear();
                    if (list.Count == 0)
                    {
                        ballCheck();
                    }
                    else
                    {
                        int index = pickBall();
                        while (back == false)
                        {
                            back = color(index);
                        }
                    }
                    break;
                case "3":
                case "d":
                case "delete":
                    delete();
                    break;
                case "4":
                case "b":
                case "back":
                    return true;
                default:
                    unknownCmd();
                    break;
            }
            return false;
        }
        bool radius(int index)
        {
            Console.Clear();

            Console.WriteLine(" Modify Radius\n" +
                "-----------------\n" +
                "1. Manually Change Radius\n" +
                "2. Shrink (Set radius to 0)\n" +
                "3. Go back\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "m":
                case "manually":
                    manualRadius(index);
                    break;
                case "2":
                case "s":
                case "shrink":
                    list[index].Shrink();
                    break;
                case "3":
                case "b":
                case "back":
                    return true;
                default:
                    unknownCmd();
                    break;
            }
            return false;
        }
        void manualRadius(int index)
        {
            string temp;
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.Write("Set new radius to: ");
                    temp = Console.ReadLine();
                    if (float.Parse(temp) < 0)
                    {
                        temp = " ";
                    }


                    list[index].radius = float.Parse(temp);
                    Console.WriteLine("Success!");
                    Console.ReadLine();
                    break;
                }
                catch
                {
                    tryAgain();
                }
            }
        }
        bool color(int index)
        {
            Console.Clear();
            Console.WriteLine(" Change Color\n" +
                "-----------------\n" +
                "1. Change Red\n" +
                "2. Change Green\n" +
                "3. Change Blue\n" +
                "4. Change Alpha\n" +
                "5. Go back\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "r":
                case "red":
                    list[index].color.Red = rgba(index);
                    break;
                case "2":
                case "g":
                case "green":
                    list[index].color.Green = rgba(index);
                    break;
                case "3":
                case "b":
                case "blue":
                    list[index].color.Blue = rgba(index);
                    break;
                case "4":
                case "a":
                case "alpha":
                    list[index].color.Alpha = rgba(index);
                    break;
                case "5":
                case "ba":
                case "back":
                    return true;
                default:
                    unknownCmd();
                    return false;
            }
            Console.WriteLine("Success!");
            Console.ReadLine();
            return false;
        }
        int rgba(int index)
        {
            string temp;
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.Write("Set new color value to: ");
                    temp = Console.ReadLine();
                    if (int.Parse(temp) > 255 || int.Parse(temp) < 0)
                    {
                        temp = " ";
                    }
                    return int.Parse(temp);
                }
                catch
                {
                    tryAgain();
                }
            }
        }
        void delete()
        {
            Console.Clear();
            if (list.Count != 0)
            {
                int index = pickBall();
                Console.Clear();
                list.Remove(list[index]);
                Console.WriteLine($"\n Ball #{index} deleted successfully");
            }
            else
            {
                Console.WriteLine("/!\\ You have no balls /!\\");
                Console.ReadLine();
            }


        }


        bool throwBall()
        {
            Console.Clear();
            Console.WriteLine(" Throw\n" +
                "-----------------\n" +
                "1. Throw one\n" +
                "2. Throw all\n" +
                "3. Go back\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "o":
                case "one":
                    oneThrow();
                    break;
                case "2":
                case "a":
                case "all":
                    allThrow();
                    break;
                case "3":
                case "b":
                case "back":
                    return true;
                default:
                    unknownCmd();
                    break;

            }
            return false;
        }
        void oneThrow()
        {
            Console.Clear();
            if (list.Count != 0)
            {
                int i = pickBall();
                Console.Clear();
                list[i].Throw();
                Console.WriteLine("Finished!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("/!\\ You have no balls /!\\");
                Console.ReadLine();
            }
        }

        void allThrow()
        {
            Console.Clear();
            if (list.Count != 0)
            {
                foreach (Ball ball in list)
                {
                    ball.Throw();
                }
                if (list.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("/!\\ You have no balls /!\\");
                }
                else
                {
                    Console.WriteLine("Finished!");
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("/!\\ You have no balls /!\\");
                Console.ReadLine();
            }
        }

        
        void listAll()
        {
            Console.Clear();
            foreach (Ball ball in list)
            {
                type(ball);
            }
            if (list.Count == 0)
            {
                Console.WriteLine("/!\\ You have no balls /!\\");
                Console.ReadLine();
            }
        }
        void type(Ball ball)
        {
            Console.WriteLine("-----------------" +
                              "\n[Ball #" + list.IndexOf(ball) +
                              "]\n\nRadius: " + ball.radius +
                              "\nThrows: " + ball.ThrowAmount() +
                              "\n\nColor (RGBa)" +
                              "\n  Red:   " + ball.color.Red +
                              "\n  Green: " + ball.color.Green +
                              "\n  Blue:  " + ball.color.Blue +
                              "\n  Alpha: " + ball.color.Alpha +
                              "\n-----------------\n");
        }
  
        int pickBall()
        {
            int index;


            while (true)
            {
                Console.Clear();
                listAll();
                Console.Write("\nWhich Ball do you want to edit? #");
                try
                {

                    index = int.Parse(Console.ReadLine());
                    if (index >= list.Count || index < 0)
                    {
                        Console.WriteLine("\n/!\\ Could not find the ball /!\\");
                        Console.ReadLine();
                    }
                    else
                    {
                        return index;
                    }
                }
                catch
                {
                    unknownCmd();
                }
            }
        }

        bool ballCheck()
        {
            Console.WriteLine("/!\\ You have no balls /!\\");
            Console.ReadLine();
            return true;
        }
 
        void unknownCmd()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition((Console.BufferWidth - 15) / 2, 12);
            Console.WriteLine("UNKNOWN COMMAND\n");
            Console.SetCursorPosition((Console.BufferWidth - 25) / 2, 13);
            Console.Write("Press 'Enter' to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        void tryAgain()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            Console.Write("/!\\ Try again /!\\");
            Console.ReadLine();

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
