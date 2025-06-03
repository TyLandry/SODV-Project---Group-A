using System;

namespace ProjectSODV
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow game = new GameFlow(); // starts program. gameflow is an object and calls start() to begin game.
            game.Start();
        }
    }
    public class Player //testt
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public Player(string name, char symbol) // string = player 1 or 2, char = X or O
        {
            Name = name;
            Symbol = symbol;
        }
    }
    public class GameBoard
    {
        // need to put stuff here
    }

    public class GameFlow
    {   // encapsulation.
        private GameBoard board;
        private Player player1;
        private Player player2;
        private Player currentPlayer; // tracks whos turn it is

        public void Start() // this starts the loop
        {
            board = new GameBoard(); // initializing the gameboard. 
            player1 = new Player("Player 1", 'X');
            player2 = new Player("Player 2", 'O');
            currentPlayer = player1;

            bool playAgain; // asks the user if they want to play again after game ends.
            do
            {
                board.Reset(); // clear board
                bool gameOver = false;
                while (!gameOver) // continues loop until player wins 
                {
                    board.Display();
                    Console.WriteLine("Choose a column (1-7): ");
                    string input = Console.ReadLine();

                    if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7")
                    {
                        int column = int.Parse(input); // parse converts a string into a #
                    }
                    else
                    {
                        Console.WriteLine("That column is full, try another."); // error
                    }
                }