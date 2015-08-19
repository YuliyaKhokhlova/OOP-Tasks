using System;

namespace _0_2_GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessNumberHost game = new GuessNumberHost();
            game.SayHello();

            GuessNumberHost.Answer answer = GuessNumberHost.Answer.Undefined;
            do
            {
                string input = Console.ReadLine();
                int guess = -1;
                try
                {
                    guess = Convert.ToInt32(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Look's like you've made a mistake: " + e.Message);
                    continue;
                }
                answer = game.GetAnswerAboutNumber(guess);
            }
            while (answer != GuessNumberHost.Answer.Exactly && answer != GuessNumberHost.Answer.NoMoreTries);
        }
    }

    class GuessNumberHost
    {
        private int _numberToGuess;
        private int _tries;

        private const int MaxTry = 8;
        private const int MinNumberToSet = 1;
        private const int MaxNumberToSet = 100;

        public GuessNumberHost()
        {
            ResetGame();
        }

        private void ResetGame()
        {
            _numberToGuess = (new Random()).Next(MinNumberToSet, MaxNumberToSet + 1);
            _tries = 0;
        }

        public void SayHello()
        {
            Console.WriteLine("Let's play the game!");
            Console.WriteLine("Try to guees the number I've set (1..100)");
        }

        public Answer GetAnswerAboutNumber(int value)
        {
            _tries++;

            if (value == _numberToGuess)
            {
                Console.WriteLine("You caught me! The number was " + _numberToGuess);
                return Answer.Exactly;
            }

            if (_tries >= MaxTry)
            {
                Console.WriteLine("You've already used all your " + MaxTry + "tries. It was " + _numberToGuess);
                return Answer.NoMoreTries;
            }

            if (value < _numberToGuess)
            {
                Console.WriteLine("Take More!");
                return Answer.TakeMore;
            }

            if (value > _numberToGuess)
            {
                Console.WriteLine("Take Less!");
                return Answer.TakeLess;
            }

            return Answer.Undefined;
        }

        public enum Answer
        {
            TakeMore,
            TakeLess,
            Exactly,
            NoMoreTries,
            Undefined
        }

    }
}
