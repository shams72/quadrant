using System;
using System.Numerics;

public class Quadrant
{
    private string[] quadrantValues = new string[4]; 

    private int currentQuadrant = 0;

    private string currentWord = "";

    public string GetCurrentWord() {
        return currentWord;
    }

    public int GetCurrentQuadrant() {
        return currentQuadrant + 1;
    }

    private static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray(); 
        Array.Reverse(charArray);               
        return new string(charArray);           
    }


    public static string GenerateAsciiArt(string word, int axis) {
        
        var digitAscii = new Dictionary<char, string[]>
        {
            { '0', new[] { " _ ", "| |", "|_|" } },
            { '1', new[] { "   ", "  |", "  |" } },
            { '2', new[] { " _ ", " _|", "|_ " } },
            { '3', new[] { " _ ", " _|", " _|" } },
            { '4', new[] { "   ", "|_|", "  |" } },
            { '5', new[] { " _ ", "|_ ", " _|" } },
            { '6', new[] { " _ ", "|_ ", "|_|" } },
            { '7', new[] { " _ ", "  |", "  |" } },
            { '8', new[] { " _ ", "|_|", "|_|" } },
            { '9', new[] { " _ ", "|_|", " _|" } },
        };

        var digitAscii4 = new Dictionary<char, string[]>
        {
            { '0', new[] { " _ ", "| |", "|_|" } },
            { '1', new[] { "   ", "  |", "  |" } },
            { '2', new[] { " _ ", "|_ ", " _|" } },
            { '3', new[] { " _ ", " _|", " _|" } },
            { '4', new[] { "   ", " _|", "| |" } },
            { '5', new[] { " _ ", " _|", "|_ " } },
            { '6', new[] { " _ ", "|_|", " _|" } },
            { '7', new[] { "   ", "  |"," _| " } },
            { '8', new[] { " _ ", "|_|", "|_|" } },
            { '9', new[] { " _ ", "|_ ", "|_|" } },
        };
       
        var digitAscii3 = new Dictionary<char, string[]>
        {
            { '0', new[] { " _ ", "| |", "|_|" } },
            { '1', new[] { "   ", "  |", "  |" } },
            { '2', new[] { " _ ", " _|", "|_ " } },
            { '3', new[] { " _ ", "|_ ", "|_ " } },
            { '4', new[] { "   ", "|_ ", "| |" } },
            { '5', new[] { " _ ", "|_ ", " _|" } },
            { '6', new[] { " _ ", "|_ ", "|_|" } },
            { '7', new[] { "   ", "  |", " _|" } },
            { '8', new[] { " _ ", "|_|", "|_|" } },
            { '9', new[] { " _ ", "|_ ", "|_|" } },

        };

        var digitAscii2 = new Dictionary<char, string[]>
        {
            { '0', new[] { " _ ", "| |", "|_|" } },
            { '1', new[] { "   ", "  |", "  |" } },
            { '2', new[] { " _ ", "|_ ", " _|" } },
            { '3', new[] { " _ ", "|_ ", "|_ " } },
            { '4', new[] { "   ", "|_|", "|  " } },
            { '5', new[] { " _ ", " _|", "|_ " } },
            { '6', new[] { " _ ", " _|", "|_|" } },
            { '7', new[] { " _ ", "|  ", "|  " } },
            { '8', new[] { " _ ", "|_|", "|_|" } },
            { '9', new[] { " _ ", "|_|", "|_ " } },

        };

        string[] finalLines = new string[3]; 

        if (axis == 0) {
            
            char[] charWord = word.ToCharArray();
            
            foreach (char c in charWord){
                for (int i = 0; i < 3; i++) {
                    
                    finalLines[i] += digitAscii[c][i] + " ";
                    
                }
            }
        }

        if (axis == 1) {
            string reversedWord = ReverseString(word);
            char[] charWord = reversedWord.ToCharArray();
          
             foreach (char c in charWord){
                for (int i = 0; i < 3; i++) {
                    
                    finalLines[i] += digitAscii2[c][i] + " ";
                    
                }
            }
            
        }   


        if (axis == 2) {

            string reversedWord = ReverseString(word);
            char[] charWord = reversedWord.ToCharArray();
           
            foreach(char c in charWord){
               for (int i = 0; i < 3; i++) {
                    
                finalLines[i] += digitAscii3[c][i] + " ";
                    
                }
            }

        }

        if (axis == 3) {

            char[] charWord = word.ToCharArray();

            foreach (char c in charWord){
                for (int i = 0; i < 3; i++) {
                    
                    finalLines[i] += digitAscii4[c][i] + " ";
                    
                }
            }
            
        }
         
        string finalOutput = string.Join("\n", finalLines);
        return finalOutput;

    }


    public bool SetValueInQuadrant(string value, string axis) {

        Console.WriteLine("Your Curent Quadrant is:"+  currentQuadrant.ToString());

        if (quadrantValues[0] == null) {

            Console.WriteLine("You need to enter Values in First Quadrant. Press 1 to enter a value in First Quadrant");
            return false;
        }
            
        if(axis == "X" && currentQuadrant % 2 == 0 && quadrantValues[(((currentQuadrant - 1) % 4) + 4) % 4] == null ) {
            quadrantValues[(((currentQuadrant - 1) % 4) + 4) % 4] = GenerateAsciiArt(value,(((currentQuadrant - 1) % 4) + 4) % 4);
            Console.WriteLine("Reflected along the X-Axis to Quadrant" + ((((currentQuadrant - 1) % 4) + 4) % 4).ToString());
            return true;
        } 

        if(axis == "Y" && currentQuadrant % 2 == 0 && quadrantValues[(currentQuadrant + 1) % 4] == null ) {
            quadrantValues[(currentQuadrant + 1) % 4] = GenerateAsciiArt(value,(currentQuadrant + 1) % 4);
            Console.WriteLine("Reflected along the Y-Axis to Quadrant" + ((currentQuadrant + 1) % 4).ToString());
            return true;
           
        } 

        if(axis == "X" && currentQuadrant % 2 != 0 && quadrantValues[(currentQuadrant + 1) % 4] == null) {
            quadrantValues[(currentQuadrant + 1) % 4] = GenerateAsciiArt(value, (currentQuadrant + 1) % 4);
            Console.WriteLine("Reflected along the X-Axis to Quadrant" + ((currentQuadrant + 1) % 4).ToString());
            return true;
        } 

        if(axis == "Y" && currentQuadrant % 2 != 0 && quadrantValues[(((currentQuadrant - 1) % 4) + 4) % 4] == null ) {
            quadrantValues[(((currentQuadrant - 1) % 4) + 4) % 4] = GenerateAsciiArt(value,(((currentQuadrant - 1) % 4) + 4) % 4);
            Console.WriteLine("Reflected along the Y-Axis to Quadrant" + ((((currentQuadrant - 1) % 4) + 4) % 4).ToString());
            return true;
   
        } 

        Console.WriteLine("Couldnot reflect because reflected Quadrant is filled .Press 0 to view the Quadrant");
        return false;        

    }


    public bool SetQuadrant(int value) {
         
        if (quadrantValues[0] == null ) {
            Console.WriteLine("Quadrants can only be changed when first quadrant is filled. Any initial input will be stored in first Quadrant.");
            return false;
        }

        if (quadrantValues[value - 1] == null ) {
            Console.WriteLine("Quadrant doesnot have a value yet. Please Choose a Quadrant with a Value. Press 0 to view the current Quadrants State.");
            return false;
        }

        
        currentQuadrant = value - 1;
        Console.WriteLine("Quadrant updated to:" + value.ToString());
        return true;

    }

    public void SetValueInQuadrantONE(string firstQuadrantValue) {
        
        
        char[] charArray = firstQuadrantValue.ToCharArray();

        char[] firstInputArray = { '0', '0', '0', '0' };
        int j = firstInputArray.Length - 1;
        
        for (int i = charArray.Length - 1; i >= 0; i--) {
            firstInputArray[j] = charArray[i];
            j--;
        }

        currentWord = new string(firstInputArray);

         
        quadrantValues[0] = GenerateAsciiArt(new string(firstInputArray),0);
        Console.WriteLine("First Quadrant Initialized");
    }




    public void PrintQuadrants() {

        
        Console.WriteLine("\n");
        Console.WriteLine("Quadrant Structure: ");
        Console.WriteLine($"  |   {1} |   {2} |");
        Console.WriteLine("--------------------");
        Console.WriteLine($"  |   {4} |   {3} |");
        Console.WriteLine("\n");

        for (int i = 0; i < quadrantValues.Length ; i++ ) {

            Console.WriteLine("Your Current Quadrant is: " + (i+1).ToString());
            Console.WriteLine("Value: ");
            Console.WriteLine(quadrantValues[i]);

            if( i % 2 == 0 ) {
                Console.WriteLine("Reflection on X-axis: Quadrant " +  (((((i - 1) % 4) + 4) % 4) + 1).ToString() + "\n");
                Console.WriteLine(quadrantValues[(((i - 1) % 4) + 4) % 4]);
                
                Console.WriteLine("Reflection on Y-axis: Quadrant " + (((i + 1) % 4) + 1).ToString()+ "\n");
                Console.WriteLine(quadrantValues[(i + 1) % 4]);

                Console.WriteLine("--------------------------------------------------------");
                
            }
            else {

                Console.WriteLine("Reflection on X-axis: Quadrant "+ (((i + 1) % 4) + 1).ToString() + "\n");
                Console.WriteLine(quadrantValues[(i + 1) % 4]);

                Console.WriteLine("Reflection on Y-axis: Quadrant " +  (((((i - 1) % 4) + 4 ) % 4) + 1).ToString() + "\n");
                Console.WriteLine(quadrantValues[(((i- 1) % 4) + 4) % 4]);
                
                Console.WriteLine("--------------------------------------------------------");
            }


        }
       
    }

}
