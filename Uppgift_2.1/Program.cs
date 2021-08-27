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
            /* Random random = new Random();
             int ran = random.Next(1, 5);

             list.Add(new Ball((float)13.5, new Color(5, 255, 120, 120)));

             for (int i = 0; i < ran; i++)
             {
                 list.Add(new Ball(random.Next(32), new Color(random.Next(255), random.Next(255), random.Next(255))));
             }

             foreach (Ball ball in list)
             {
                 ran = random.Next(1, 11);
                 for (int i = 0; i < ran; i++)
                 {
                     ball.Throw();
                 }
                 Console.WriteLine("Ball " + (list.IndexOf(ball) + 1) + " Thrown " + ball.ThrowAmount() + " times");
             }*/
            mainMenu();
            Console.ReadLine();
        }
        //_______________________________________________________________________________________________________
        void mainMenu()
        {
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
                    mainMenu();
                    break;
                case "2":
                case "m":
                case "modify":
                    modify(); // /!\ not done  ;;;;;;;; change temp index to Ball temp
                    mainMenu();
                    break;
                case "3":
                case "s":
                case "show":
                    listAll();
                    Console.Write("\nPress 'Enter' to continue");
                    Console.ReadLine();
                    mainMenu();
                    break;
                case "4":
                case "t":
                case "throw":
                    mainMenu();
                    break;
                case "5":
                case "q":
                case "quit":

                    break;
                default:
                    unknownCmd();
                    mainMenu();
                    break;
            }
        }
        //_______________________________________________________________________________________________________
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
                    if (int.Parse(temp) > 255)
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
            while (true)
            {
                try
                {
                    Console.Write(message);
                    return float.Parse(Console.ReadLine());
                }
                catch
                {

                    tryAgain();
                }
            }
        }


        //_______________________________________________________________________________________________________

        void modify()
        {


            Console.Clear();
            Console.WriteLine(" Modify Ball\n" +
                "-----------------\n" +
                "1. Change Radius\n" +
                "2. Change Color\n"+
                "3. Delete ball\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "r":
                case "radius":
                    radius();
                    mainMenu();
                    break;
                case "2":
                case "c":
                case "color":
                    color();
                    break;
                case "3":
                case "d":
                case "delete":
                    delete();
                    break;
                default:
                    unknownCmd();
                    modify();
                    break;
            }
        }
        void radius()
        {
            int index = int.MaxValue;
            Console.Clear();
            pickBall(ref index);
            if (index == int.MaxValue)
            {
                radius();
            }

            Console.Clear();
            Console.WriteLine(" Modify Radius\n" +
                "-----------------\n" +
                "1. Manually Change Radius\n" +
                "2. Shrink (Set radius to 0)\n");

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
                default:
                    unknownCmd();
                    radius();
                    break;
            }
        }
        void manualRadius(int index)
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.Write("Set new radius to: ");
                    list[index].radius = float.Parse(Console.ReadLine());
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
        void color()
        {
            int index = int.MaxValue;
            Console.Clear();
            pickBall(ref index);
            if (index == int.MaxValue)
            {
                color();
            }


            Console.Clear();
            Console.WriteLine(" Change Color\n" +
                "-----------------\n" +
                "1. Change Red\n" +
                "1. Change Green\n" +
                "1. Change Blue\n" +
                "2. Change Alpha\n");

            Console.Write("Input: ");
            string answer = Console.ReadLine().ToLower().Trim();
            switch (answer)
            {

                case "1":
                case "r":
                case "red":
                    list[index].color.Red = rgba(index);
                    Console.WriteLine("Success!");
                    Console.ReadLine();
                    mainMenu();
                    break;
                case "2":
                case "g":
                case "green":
                    list[index].color.Green = rgba(index);
                    Console.WriteLine("Success!");
                    Console.ReadLine();
                    mainMenu();
                    break;
                case "3":
                case "b":
                case "blue":
                    list[index].color.Blue = rgba(index);
                    Console.WriteLine("Success!");
                    Console.ReadLine();
                    mainMenu();
                    break;
                case "4":
                case "a":
                case "alpha":
                    list[index].color.Alpha = rgba(index);
                    Console.WriteLine("Success!");
                    Console.ReadLine();
                    break;
                default:
                    unknownCmd();
                    modify();
                    break;
            }
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
                    if (int.Parse(temp) > 255)
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
            int index = int.MaxValue;
            Console.Clear();
            pickBall(ref index);
            if (index == int.MaxValue)
            {
                delete();
            }

            list.Remove(list[index]);
            Console.WriteLine($"\n Ball #{index} deleted successfully");
        }
        //_______________________________________________________________________________________________________
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
                mainMenu();
            }
        }

        void type(Ball ball)
        {
            Console.WriteLine("\n-----------------" +
                              "\n[Ball # " + list.IndexOf(ball) +
                              "]\n\nRadius: " + ball.radius +
                              "\nThrows: " + ball.ThrowAmount() +
                              "\n\nColor (RGBa)" +
                              "\n  Red:   " + ball.color.Red +
                              "\n  Green: " + ball.color.Green +
                              "\n  Blue:  " + ball.color.Blue +
                              "\n  Alpha: " + ball.color.Alpha +
                              "\n-----------------");
        }
        //_______________________________________________________________________________________________________
        void pickBall(ref int index)
        {
            Console.Clear();
            listAll();
            Console.Write("\nWhich Ball do you want to edit? #");
            try
            {
                index = int.Parse(Console.ReadLine());
                if (index >= list.Count)
                {
                    Console.WriteLine("\n/!\\ Could not find the ball /!\\");
                    Console.ReadLine();
                    pickBall(ref index);
                }
            }
            catch
            {
                unknownCmd();
            }
            
        }
        //_______________________________________________________________________________________________________
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
