using System;

class Program
{
    static void Main(string[] args)
    {
        Quadrant quadrant = new Quadrant();
       

        while(true) {

            Console.WriteLine("\n" + "Press the numbers/words below to execute your desired actions:" + "\n");
            Console.WriteLine("Your current quadrant is: " + quadrant.GetCurrentQuadrant() + "\n");
            Console.WriteLine("0 - View Current Quadrant State");
            Console.WriteLine("1 - Initialize First Quadrant");
            Console.WriteLine("2 - Change Quadrant");
            Console.WriteLine("3 - Exit");
            Console.WriteLine("X - Reflect on X-Axis");
            Console.WriteLine("Y - Reflect on Y-Axis");

            string choice = Console.ReadLine();

            switch (choice) {
                case "0":

                    Console.WriteLine("Viewing current quadrant state...");
                    quadrant.PrintQuadrants();
                    break;
                
                case "1":

                    Console.WriteLine("Please enter your numbers (digits 0–9 only):");
                    string firstQuadrantValue = Console.ReadLine();

                    if (string.IsNullOrEmpty(firstQuadrantValue) || !firstQuadrantValue.All(char.IsDigit) ||  firstQuadrantValue.Length > 4  )
                    {
                        Console.WriteLine("Invalid input! Please enter 4 numbers within range from 0 - 9.");
                        break; 
                    }

                    quadrant.SetValueInQuadrantONE(firstQuadrantValue);


                    break;

                case "x":
                case "X":
                    quadrant.SetValueInQuadrant(quadrant.GetCurrentWord(), "X");
                    Console.WriteLine("Reflecting on X-Axis...");
                    break;

                case "y":
                case "Y":
                    
                    quadrant.SetValueInQuadrant(quadrant.GetCurrentWord(), "Y");
                    Console.WriteLine("Reflecting on Y-Axis...");
                    break;

                case "4":

                    Console.WriteLine("Enter a Quadrant betwen 1 and 4...");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int quadrantChoice) && quadrantChoice >= 1 && quadrantChoice <= 4) {
                        quadrant.SetQuadrant(quadrantChoice);
                    }
                    else {
                        Console.WriteLine("Invalid input. Please enter a number/range.");
                    }
                    
                    break;

                case "5":
                    Quadrant.GenerateAsciiArt("123496578",1);
                    break;
                

                default:
                    Console.WriteLine("Invalid choice. Please Check the Menu for inputs.");
                    break;
            }




        }

        

    }
}
