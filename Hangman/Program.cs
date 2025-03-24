using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            const int MAX_LIVES = 7;
            int guessCount = 0;
            bool outOfLives = false;
            string userGuess = "";

                        
            List<string> words = new List<String>();

            words.Add("lamborghini");
            words.Add("artificial intelligence");
            words.Add("football");
            words.Add("arnold schwarzenegger");
            words.Add("seafood paella");
            words.Add("argentina");
            words.Add("spiderman");
            words.Add("chocolate mousse");

            List<char> alreadyGuessed = new List<char>();
            

            Random rnd = new Random();
            int randomIndex = rnd.Next(words.Count);                  
            
            string selectedWord = words[randomIndex];         
                                   
            Console.WriteLine("Welcome to the Hangman");
            Console.WriteLine("Hangman is a game where a word is secretly chosen and the player guesses letters to fill in the word");
            Console.WriteLine($"You will have {MAX_LIVES} lives to try and guess the word, select a letter");
                        
            Console.WriteLine(words[randomIndex]);

            char[] hiddenWord = new char[selectedWord.Length];       
                        
            for (int i = 0; i < hiddenWord.Length; i++)                
            {
                hiddenWord[i] = '_';

                if (selectedWord[i] == ' ')
                {
                    hiddenWord[i] = ' ';                    
                }
            }            

            for (int i = 0; i < hiddenWord.Length; i++)///3
            {
                Console.Write(hiddenWord[i]);
            }
            
            while (!outOfLives)  
            {
                if (selectedWord == new string(hiddenWord))    
                {
                    Console.WriteLine("YOU WIN");
                    break;
                }

                if (guessCount < MAX_LIVES)
                {                    
                    userGuess = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();
                    
                    if (alreadyGuessed.Contains(char.Parse(userGuess)))
                    {                       
                        Console.WriteLine("Dupliclate input");
                        continue;                     
                       
                    }

                    if (!char.IsLetter(Char.Parse(userGuess)))
                    {
                        Console.WriteLine("Please enter a valid letter");
                        continue; 
                    }                                                         

                    if (selectedWord.Contains(userGuess))       
                    {
                        for (int i = 0; i < hiddenWord.Length; i++)
                        {
                            if (selectedWord[i].ToString() == userGuess)
                            {
                                hiddenWord[i] = Char.Parse(userGuess);
                            }
                        }
                    }
                    else               
                    {
                        Console.WriteLine("worng letter,try again");

                        guessCount++;
                        Console.WriteLine($"You have used {guessCount} of your 7 lives");

                        if (guessCount == MAX_LIVES)
                        {
                            Console.WriteLine("GAME OVER, you have used all your lives");
                            break;
                        }

                        continue;
                    }               
                }

                for (int i = 0; i < hiddenWord.Length; i++)////5
                {
                    Console.Write(hiddenWord[i]);                    
                }
                Console.WriteLine();
                alreadyGuessed.Add(char.Parse(userGuess));
            }
        }
    }
}



