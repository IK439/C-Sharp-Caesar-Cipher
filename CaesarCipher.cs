using System;

/* Caesar Cipher: A simple encryption technique that shifts letters
   by a fixed number of positions. 
   This program allows the user to encrypt or decrypt a single message,
   handles uppercase and lowercase letters, preserves symbols and spaces,
   and supports a custom shift key */

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Caesar Cipher...");

            // Ask user to choose either encrypting or decrypting
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1 - Encrypt a message");
            Console.WriteLine("2 - Decrypt a message");
            Console.Write("Enter 1 or 2: ");
            string choice = Console.ReadLine();

            if (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }

            // Ask user for shift key
            Console.Write("\nEnter a number for the shift key: ");
            if (!int.TryParse(Console.ReadLine(), out int shift))
            {
                Console.WriteLine("Invalid input. Exiting.");
                return;
            }

            // Reverse shift if decrypting
            if (choice == "2")
                shift = -shift;

            // Get message from user
            Console.Write("\nEnter your message: ");
            string input = Console.ReadLine();

            // Call Caesar Cipher method with message and shift key arguments
            string output = CaesarCipher(input, shift);

            Console.WriteLine("\nResult:");
            Console.WriteLine(output);
        }
        
        static string CaesarCipher(string text, int shift)
        {
            // Create an array to store the result
            char[] result = new char[text.Length];

            // Loop through each character in the text
            for (int i = 0; i < text.Length; i++)
            {
                // Get the current character
                char letter = text[i];

                // Check if the character is a letter using helper method
                if (char.IsLetter(letter))
                {
                    // Ternary operator to check if the letter is uppercase or lowercase
                    char offset = char.IsUpper(letter) ? 'A' : 'a';

                    // Shift the letter using the shift key value passed in
                    int shifted = (letter - offset + shift) % 26;

                    // Keep the letter within the alphabet range
                    if (shifted < 0)
                    {
                      shifted += 26;
                    }

                    // Convert the number back to a letter
                    result[i] = (char)(shifted + offset);
                }
                else
                {
                    // Retain non-letter characters as is
                    result[i] = letter;
                }
            }
            // Convert the character array to a string and return it
            return new string(result);
        }
    }
}