using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JeuxPendu
{
    public class GameInstance
    {
        private int maxErrors { get; set; }
        public List<char> Guesses { get; }
        public List<char> Misses { get; }
        public List<Word> Words { get; }
        public Word WordToGuess { get; }

        private Random rnd;
        private bool isWin { get; set; }
        private string CurrentWordGuessed;

        public GameInstance(int maxErrors = 10)
        {
            rnd = new Random();
            this.maxErrors = maxErrors;
            Words = new List<Word>
            {
                new Word("ciao"),
                new Word("amico"),
                new Word("programmazione"),
                new Word("computer"),
                new Word("ski"),
                new Word("musica"),
            };

            Guesses = new List<char>();
            Misses = new List<char>();
            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine("la parola contiene {0} lettere", WordToGuess.Length);
        }

        public GameInstance(List<Word> words, int maxErrors = 10)
        {
            rnd = new Random();
            this.maxErrors = maxErrors;
            Words = words;

            Guesses = new List<char>();
            Misses = new List<char>();
            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine("la parola da indovinare contiene {0} lettere", WordToGuess.Length);
            CurrentWordGuessed = PrintWordToGuess();
        }

        public void Play()
        {
            while (!isWin)
            {
                Console.WriteLine("scrivi una lettera");
                var letter = char.ToUpper(Console.ReadKey(true).KeyChar);
                int letterIndex = WordToGuess.GetIndexOf(letter);
                Console.WriteLine();

                if (letterIndex != -1)
                {
                    Console.WriteLine($"bravo, hai trovato la lettera:{letter}");
                    Guesses.Add(letter);
                }

                else
                {
                    Console.WriteLine("non è la lettera giusta, riprova");
                    Misses.Add(letter);
                }
                if (Misses.Count > 0)
                {
                    Console.WriteLine($"errori ({Misses.Count}) : {string.Join(", ", Misses)}");

                }

                CurrentWordGuessed = PrintWordToGuess();

                if (CurrentWordGuessed.IndexOf('_') == -1)
                {
                    isWin = true;
                    Console.WriteLine("bravo hai vinto");
                    // Console.ReadKey();
                }

                if (Misses.Count >= maxErrors)
                {
                    Console.WriteLine("peccato hai perso");
                    // Console.ReadKey();
                    break;
                }


            }

        }

        private string PrintWordToGuess()
        {
            string currentWordGuessed = "";

            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (Guesses.Contains(WordToGuess.Text[i]))
                {
                    currentWordGuessed += WordToGuess.Text[i];
                }
                else
                {
                    currentWordGuessed += "_";
                }

            }

            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();
            return currentWordGuessed;
        }
    }
}
