using System;
using System.Collections.Generic;

namespace DoomsDay (doom remake.)
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;

            // Initialize game objects and variables

            while (true)
            {
                // Process user input

                // Update game state

                // Render the game

                // Add a delay to control game speed
                System.Threading.Thread.Sleep(16); // Approximately 60 FPS
            }
        }
    }
}

{
    class Program
    {
        static bool isGameOver = false;

        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;

            // Initialize game objects and variables

            while (!isGameOver)
            {
                // Process user input

                // Update game state

                // Render the game

                // Add a delay to control game speed
                System.Threading.Thread.Sleep(16); // Approximately 60 FPS
            }

            // Show game over screen
            ShowGameOverScreen();
        }

        static void ShowGameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("Press R to restart or Q to quit.");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char keyPressed = keyInfo.KeyChar;

                if (keyPressed == 'r' || keyPressed == 'R')
                {
                    // Restart the game
                    isGameOver = false;
                    Main(null);
                    break;
                }
                else if (keyPressed == 'q' || keyPressed == 'Q')
                {
                    // Quit the game
                    Environment.Exit(0);
                }
            }
        }
    }
}

using System;

namespace DoomRecreation
{
    class Program
    {
        static int playerX = 0; // Player's X coordinate
        static int playerY = 0; // Player's Y coordinate

        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;

            // Initialize game objects and variables

            while (true)
            {
                // Process user input
                ProcessInput();

                // Update game state

                // Render the game

                // Add a delay to control game speed
                System.Threading.Thread.Sleep(16); // Approximately 60 FPS
            }
        }

        static void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey keyPressed = keyInfo.Key;

                // Move the player based on the arrow key pressed
                switch (keyPressed)
                {
                    case ConsoleKey.LeftArrow:
                        MovePlayer(-1, 0); // Move left
                        break;
                    case ConsoleKey.RightArrow:
                        MovePlayer(1, 0); // Move right
                        break;
                    case ConsoleKey.UpArrow:
                        MovePlayer(0, -1); // Move up
                        break;
                    case ConsoleKey.DownArrow:
                        MovePlayer(0, 1); // Move down
                        break;
                }
            }
        }

        static void MovePlayer(int deltaX, int deltaY)
        {
            // Calculate the new position of the player
            int newPlayerX = playerX + deltaX;
            int newPlayerY = playerY + deltaY;

            // Perform boundary checks to ensure the player stays within the game world
            if (newPlayerX >= 0 && newPlayerX < Console.WindowWidth && newPlayerY >= 0 && newPlayerY < Console.WindowHeight)
            {
                // Update the player's position
                playerX = newPlayerX;
                playerY = newPlayerY;
            }
        }
    }
}
using System;

namespace DoomRecreation
{
    class Program
    {
        static char playerChar = '@'; // Character representing the player
        static int playerX = 0; // Player's X coordinate
        static int playerY = 0; // Player's Y coordinate

        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 30;

            // Initialize game objects and variables

            while (true)
            {
                // Process user input

                // Update game state

                // Render the game
                RenderGame();

                // Add a delay to control game speed
                System.Threading.Thread.Sleep(16); // Approximately 60 FPS
            }
        }

        static void RenderGame()
        {
            // Clear the console
            Console.Clear();

            // Render the player
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(playerChar);
        }
    }
}
using System;
using System.Diagnostics;

namespace DoomRecreation
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static int frameCount = 0;
        static int fps = 0;

        static void Main(string[] args)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 30;

            // Initialize game objects and variables

            stopwatch.Start();

            while (true)
            {
                // Process user input

                // Update game state

                // Render the game
                RenderGame();

                // Add a delay to control game speed
                System.Threading.Thread.Sleep(16); // Approximately 60 FPS

                // Calculate FPS
                CalculateFPS();
            }
        }

        static void RenderGame()
        {
            // Clear the console
            Console.Clear();

            // Render the game objects
        }

        static void CalculateFPS()
        {
            frameCount++;

            if (stopwatch.ElapsedMilliseconds >= 1000)
            {
                fps = frameCount;
                frameCount = 0;
                stopwatch.Restart();
            }

            // Display FPS on the console
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"FPS: {fps}");
        }
    }
}
