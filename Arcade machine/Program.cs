using System;
using System.Collections.Generic;

namespace Arcade_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameOn = true;
            string[] games = new string[] { "Tic Tac Toe", "Minesweeper", "Connect 4", "Hangman", "No at Game", "Rock Paper Scissors", "Battleships" };

            do
            {
                int i = 1, gameChoiceInt;

                Console.Clear();
                Console.WriteLine("Welcome to Baconcade\n");
                foreach (var item in games)
                {
                    Console.WriteLine("{0}. {1}", i, item);
                    i++;
                }
                Console.WriteLine("{0}. Shutdown Baconcade\n", i);
                Console.Write("Choose game: ");
                string gameChoiceString = Console.ReadLine();


                bool isNummber = int.TryParse(gameChoiceString, out gameChoiceInt);
                if (isNummber)
                {
                    switch (gameChoiceInt)
                    {
                        case 1:
                            Console.Clear();
                            TTTMain();
                            break;
                        case 2:
                            Console.Clear();
                            MineSweeperMain();
                            break;
                        case 3:
                            Console.Clear();
                            Connect4();
                            break;
                        case 4:
                            Console.Clear();
                            HangmanMain();
                            break;
                        case 5:
                            Console.Clear();
                            NotAGame();
                            break;
                        case 6:
                            Console.Clear();
                            RPSMain();
                            break;
                        case 7:
                            Console.Clear();
                            break;
                        default:
                            break;
                    }
                }

            } while (gameOn);
        }

        //Tic Tac Toe
        static void TTTMain()
        {
            string TTTmenuChoice;
            bool TTTisNumber, TTTgameRunning = true;
            int TTToutput, TTTplayAgain;


            while (TTTgameRunning)
            {
                Console.Clear();
                Console.WriteLine("Tic Tac Toe");
                Console.WriteLine("\n1. Play");
                Console.WriteLine("2. Stop game");
                TTTmenuChoice = Console.ReadKey().KeyChar.ToString();
                TTTisNumber = int.TryParse(TTTmenuChoice, out TTToutput);
                if (TTTisNumber)
                {
                    switch (TTToutput)
                    {
                        case 1:
                            while (true)
                            {
                                Console.Clear();
                                TTTGame();
                                TTTplayAgain = TTTPlayAgain();
                                if (TTTplayAgain == 2)
                                {
                                    break;
                                }
                            }
                            break;
                        case 2:
                            TTTgameRunning = false;
                            break;
                        default:
                            break;
                    }

                }
            }

        }
        static void TTTGame()
        {
            string player = "x";
            int output, output2;
            bool isNumber, isNumber2, playerWon, playersDraw;
            string[] spil = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Console.Clear();
            Console.WriteLine("Tic Tac Toe\n");
            TTTBoard(spil);
            while (true)
            {
                while (true)
                {

                    Console.WriteLine("\nPlayer: {0}", player);
                    Console.Write("Choose space: ");
                    string spaceChoosen = Console.ReadKey().KeyChar.ToString();
                    isNumber = int.TryParse(spaceChoosen, out output);
                    if (isNumber)
                    {
                        isNumber2 = int.TryParse(spil[output - 1], out output2);
                        if (isNumber2)
                        {
                            spil[output - 1] = player;
                            Console.Clear();
                            Console.WriteLine("Tic Tac Toe\n");
                            TTTBoard(spil);
                            break;
                        }
                    }
                }

                playerWon = TTTWinnerChecker(spil);
                playersDraw = TTTDrawChecker(spil);


                if (playerWon || playersDraw)
                {
                    break;
                }



                switch (player)
                {
                    case "x":
                        player = "o";
                        break;
                    case "o":
                        player = "x";
                        break;
                    default:
                        break;
                }
            }
        }
        static int TTTPlayAgain()
        {
            int playAgain;
            string menuChoice;
            bool isNumber;
            while (true)
            {
                Console.WriteLine("\nPlay again?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                menuChoice = Console.ReadKey().KeyChar.ToString();
                isNumber = int.TryParse(menuChoice, out playAgain);
                if (isNumber)
                {
                    if (playAgain == 1 || playAgain == 2)
                    {
                        break;
                    }
                }
            }
            return playAgain;
        }
        static void TTTBoard(string[] spil)
        {
            Console.WriteLine("╔═══╦═══╦═══╗");
            Console.WriteLine("║ {0} ║ {1} ║ {2} ║", spil[0], spil[1], spil[2]);
            Console.WriteLine("╠═══╬═══╬═══╣");
            Console.WriteLine("║ {0} ║ {1} ║ {2} ║", spil[3], spil[4], spil[5]);
            Console.WriteLine("╠═══╬═══╬═══╣");
            Console.WriteLine("║ {0} ║ {1} ║ {2} ║", spil[6], spil[7], spil[8]);
            Console.WriteLine("╚═══╩═══╩═══╝");
        }
        static bool TTTWinnerChecker(string[] spil)
        {
            if (spil[0] == spil[1] && spil[1] == spil[2])
            {
                Console.WriteLine("{0} Won", spil[0]);
                return true;
            }
            else if (spil[3] == spil[4] && spil[4] == spil[5])
            {
                Console.WriteLine("{0} Won", spil[3]);
                return true;
            }
            else if (spil[6] == spil[7] && spil[7] == spil[8])
            {
                Console.WriteLine("{0} Won", spil[6]);
                return true;
            }
            else if (spil[0] == spil[3] && spil[3] == spil[6])
            {
                Console.WriteLine("{0} Won", spil[0]);
                return true;
            }
            else if (spil[1] == spil[4] && spil[4] == spil[7])
            {
                Console.WriteLine("{0} Won", spil[1]);
                return true;
            }
            else if (spil[2] == spil[5] && spil[5] == spil[8])
            {
                Console.WriteLine("{0} Won", spil[2]);
                return true;
            }
            else if (spil[0] == spil[4] && spil[4] == spil[8])
            {
                Console.WriteLine("{0} Won", spil[0]);
                return true;
            }
            else if (spil[2] == spil[4] && spil[4] == spil[6])
            {
                Console.WriteLine("{0} Won", spil[2]);
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool TTTDrawChecker(string[] spil)
        {
            int i = 0, output;
            foreach (var item in spil)
            {
                bool isNumber = int.TryParse(item, out output);
                if (isNumber)
                {
                    i++;
                }
            }
            if (i == 0)
            {
                Console.WriteLine("It was a Tie");
                return true;
            }
            else
            {
                return false;
            }


        }
        //Tic Tac Toe



        //Minesweeper
        static void MineSweeperMain()
        {
            bool gameOn = true;
            while (gameOn)
            {
                Console.Clear();
                Console.WriteLine("Minesweeper");
                Console.WriteLine();
                Console.WriteLine("1. Beginner");
                Console.WriteLine("2. Intermediate");
                Console.WriteLine("3. Expert");
                Console.WriteLine("4. Close game");
                Console.Write("\nSelect: ");
                string menuChoice = Console.ReadKey().KeyChar.ToString();
                bool isNumber = int.TryParse(menuChoice, out int output);
                if (isNumber)
                {
                    if (output >= 1 && output <= 3)
                    {
                        Board(output);
                    }
                    else if (output == 4)
                    {
                        gameOn = false;
                    }
                }
            }
        }
        static void Board(int difficulity)
        {
            Console.Clear();
            int width;
            int hight;
            int numberOfBombs;
            switch (difficulity)
            {
                case 1:
                    width = 9;
                    hight = 9;
                    numberOfBombs = 10;
                    break;
                case 2:
                    width = 16;
                    hight = 16;
                    numberOfBombs = 40;
                    break;
                case 3:
                    width = 30;
                    hight = 16;
                    numberOfBombs = 99;
                    break;
                default:
                    width = 5;
                    hight = 5;
                    numberOfBombs = 5;
                    break;
            }
            List<int> boardBombPosList = new List<int>(width * hight);
            boardBombPosList = bombGeneration(width, hight, numberOfBombs);


            List<int> allNumbersList = new List<int>(width * hight);
            allNumbersList = allNumbers(boardBombPosList, width, hight);

            List<string> boardList = new List<string>(width * hight);
            for (int i = 0; i < width * hight; i++)
            {
                boardList.Add("");
            }
            for (int i = 0; i < width * hight; i++)
            {
                if (boardBombPosList.Contains(i))
                {
                    boardList[i] = "BOMB";
                }
                else if (allNumbersList.Contains(i))
                {
                    int customCount = 0;
                    foreach (var item in allNumbersList)
                    {
                        if (item == i)
                        {
                            customCount += 1;
                        }
                    }
                    boardList[i] = " 0" + customCount.ToString() + " ";
                }
                else
                {
                    boardList[i] = "    ";
                }
            }
            List<string> revealedBoardList = new List<string>();
            List<int> allPlayerInputs = new List<int>();
            while (true)
            {
                revealedBoardList = BoardRevealer(boardList, allPlayerInputs);
                ActualBoard(width, revealedBoardList);
                int playerPos = PlayerInput(width, hight, boardList);
                allPlayerInputs.Add(playerPos);
                Console.Clear();
                if (boardList[playerPos] == "BOMB")
                {
                    ActualBoard(width, boardList);
                    Console.WriteLine("You've lost the game!");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    bool haveWon = WinningChecker(boardList, allPlayerInputs, numberOfBombs);
                    if (haveWon)
                    {
                        ActualBoard(width, boardList);
                        Console.WriteLine("Congratulations! You've won the game");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
        static void ActualBoard(int width, List<string> boardList)
        {

            int hightCounter = 1;
            Console.Write("    ║");
            string customNumber = "";
            for (int i = 1; i <= width; i++)
            {
                if (i < 10)
                {
                    customNumber = "0" + i.ToString();
                }
                else
                {
                    customNumber = i.ToString();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" {0} ", customNumber);
                Console.ResetColor();
                Console.Write("║");
            }
            for (int i = 0; i < boardList.Count; i++)
            {
                if (hightCounter < 10)
                {
                    customNumber = "0" + hightCounter;
                }
                else
                {
                    customNumber = hightCounter.ToString();
                }
                if ((i % width) == 0)
                {
                    hightCounter += 1;
                    Console.WriteLine();
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write("════╬");
                    }
                    Console.WriteLine("════╣");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" {0} ", customNumber);
                    Console.ResetColor();
                    Console.Write("║");
                }
                switch (boardList[i])
                {
                    case " 01 ":
                    case " 02 ":
                    case " 03 ":
                    case " 04 ":
                    case " 05 ":
                    case " 06 ":
                    case " 07 ":
                    case " 08 ":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0}", boardList[i]);
                        Console.ResetColor();
                        Console.Write("║");
                        break;
                    case "NULL":
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", boardList[i]);
                        Console.ResetColor();
                        Console.Write("║");
                        break;
                    case "BOMB":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}", boardList[i]);
                        Console.ResetColor();
                        Console.Write("║");
                        break;
                    case "    ":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("{0}", boardList[i]);
                        Console.ResetColor();
                        Console.Write("║");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
            for (int j = 0; j < width; j++)
            {
                Console.Write("════╩");
            }
            Console.WriteLine("════╝");
        }
        static List<int> bombGeneration(int width, int hight, int numberOfBombs)
        {
            List<int> boardBombPosList = new List<int>(width * hight);
            Random boardBombPosRandom = new Random();

            for (int i = 0; i < numberOfBombs; i++)
            {
                int boardBombPosInt = 0;
                bool bombGeneration = true;
                while (bombGeneration)
                {
                    boardBombPosInt = boardBombPosRandom.Next(1, width * hight + 1);
                    if (boardBombPosList.Contains(boardBombPosInt))
                    {
                        bombGeneration = true;
                    }
                    else
                    {
                        bombGeneration = false;
                    }
                }
                boardBombPosList.Add(boardBombPosInt);
            }

            return boardBombPosList;
        }
        static int PlayerInput(int width, int hight, List<string> boardList)
        {
            string playerPickColumnString, playerPickRowString;
            bool columnIsNumber, rowIsNumber;
            int playerPickColumnInt, playerPickRowInt;
            while (true)
            {
                Console.Write("\rPick a column: ");
                playerPickColumnString = Console.ReadLine();
                columnIsNumber = int.TryParse(playerPickColumnString, out playerPickColumnInt);
                if (columnIsNumber)
                {
                    if (playerPickColumnInt <= width && playerPickColumnInt > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.CursorTop--;
                    }
                }
                else
                {
                    Console.CursorTop--;
                }
            }
            while (true)
            {
                Console.Write("\rPick a row: ");
                playerPickRowString = Console.ReadLine();
                rowIsNumber = int.TryParse(playerPickRowString, out playerPickRowInt);
                if (rowIsNumber)
                {
                    if (playerPickRowInt <= hight && playerPickRowInt > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.CursorTop--;
                    }
                }
                else
                {
                    Console.CursorTop--;
                }
            }
            int boardPlayerPossitionChoise = (playerPickRowInt - 1) * width + playerPickColumnInt - 1;
            return boardPlayerPossitionChoise;

        }
        static List<int> allNumbers(List<int> boardBombPosList, int width, int hight)
        {
            List<int> allNumbersList = new List<int>(width * hight);
            for (int i = 0; i < allNumbersList.Count; i++)
            {
                allNumbersList.Add(0);
            }
            foreach (var item in boardBombPosList)
            {
                if (!boardBombPosList.Contains(item - width - 1) && (item % width) != 0)
                    allNumbersList.Add(item - width - 1);
                if (!boardBombPosList.Contains(item - width))
                    allNumbersList.Add(item - width);
                if (!boardBombPosList.Contains(item - width + 1) && (item % width) != width - 1)
                    allNumbersList.Add(item - width + 1);
                if (!boardBombPosList.Contains(item - 1) && (item % width) != 0)
                    allNumbersList.Add(item - 1);
                if (!boardBombPosList.Contains(item + 1) && (item % width) != width - 1)
                    allNumbersList.Add(item + 1);
                if (!boardBombPosList.Contains(item + width - 1) && (item % width) != 0)
                    allNumbersList.Add(item + width - 1);
                if (!boardBombPosList.Contains(item + width))
                    allNumbersList.Add(item + width);
                if (!boardBombPosList.Contains(item + width + 1) && (item % width) != width - 1)
                    allNumbersList.Add(item + width + 1);
            }
            return allNumbersList;
        }
        static List<string> BoardRevealer(List<string> boardList, List<int> allPlayerInputs)
        {
            List<string> revealedBoardList = new List<string>();

            for (int i = 0; i < boardList.Count; i++)
            {
                if (allPlayerInputs.Contains(i))
                {
                    revealedBoardList.Add(boardList[i]);
                }
                else
                {
                    revealedBoardList.Add("NULL");
                }
            }
            return revealedBoardList;
        }
        static bool WinningChecker(List<string> boardList, List<int> allPlayerInputs, int numberOfBombs)
        {
            bool won = false;
            int customCount = 0;
            for (int i = 0; i < boardList.Count; i++)
            {
                if (boardList[i] != "BOMB")
                {
                    if (!allPlayerInputs.Contains(i))
                    {
                        won = false;
                        break;
                    }
                    customCount += 1;
                }
                if (customCount == boardList.Count - numberOfBombs)
                {
                    won = true;
                }
            }

            if (won)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Minesweeper



        //Connect 4
        static void Connect4()
        {
            Console.SetWindowSize(36, 16);
            bool gameOnline = true, emptySpace = true;
            bool isNumber, isNumber2, won = false;
            int output, output2;
            while (gameOnline)
            {
                Console.Clear();
                Console.WriteLine("Four In A Row");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Close game\n");
                Console.Write("Choose: ");

                string menuChoosen = Console.ReadKey().KeyChar.ToString();
                isNumber = int.TryParse(menuChoosen, out output);

                if (isNumber)
                {
                    switch (output)
                    {
                        case 1:
                            string player = "P1";
                            string[] p01 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            string[] p02 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            string[] p03 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            string[] p04 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            string[] p05 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            string[] p06 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            string[] p07 = new string[] { "  ", "  ", "  ", "  ", "  ", "  " };
                            int p01Arr = 0, p02Arr = 0, p03Arr = 0, p04Arr = 0, p05Arr = 0, p06Arr = 0, p07Arr = 0;
                            while (true)
                            {
                                emptySpace = true;
                                while (emptySpace)
                                {
                                    Board(p01, p02, p03, p04, p05, p06, p07);
                                    Console.Write("Current player: ");
                                    if (player == "P1")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    }
                                    else if (player == "P2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                    }
                                    Console.Write(player);
                                    Console.ResetColor();
                                    Console.Write("\nChoose a space: ");
                                    string pChoosen = Console.ReadKey().KeyChar.ToString();
                                    isNumber2 = int.TryParse(pChoosen, out output2);
                                    if (isNumber2)
                                    {
                                        switch (output2)
                                        {
                                            case 1:
                                                if (p01Arr != 6)
                                                {
                                                    p01[p01Arr] = player;
                                                    p01Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            case 2:
                                                if (p02Arr != 6)
                                                {
                                                    p02[p02Arr] = player;
                                                    p02Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            case 3:
                                                if (p03Arr != 6)
                                                {
                                                    p03[p03Arr] = player;
                                                    p03Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            case 4:
                                                if (p04Arr != 6)
                                                {
                                                    p04[p04Arr] = player;
                                                    p04Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            case 5:
                                                if (p05Arr != 6)
                                                {
                                                    p05[p05Arr] = player;
                                                    p05Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            case 6:
                                                if (p06Arr != 6)
                                                {
                                                    p06[p06Arr] = player;
                                                    p06Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            case 7:
                                                if (p07Arr != 6)
                                                {
                                                    p07[p07Arr] = player;
                                                    p07Arr += 1;
                                                    emptySpace = false;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                won = WinningTest(p01, p02, p03, p04, p05, p06, p07);
                                if (won)
                                {
                                    Board(p01, p02, p03, p04, p05, p06, p07);
                                    Console.Write("Winning player: ");
                                    if (player == "P1")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                    }
                                    else if (player == "P2")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                    }
                                    Console.WriteLine(player);
                                    Console.ResetColor();
                                    Console.Write("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                else if (p01Arr == 6 && p02Arr == 6 && p03Arr == 6 && p04Arr == 6 && p05Arr == 6 && p06Arr == 6 && p07Arr == 6)
                                {
                                    Board(p01, p02, p03, p04, p05, p06, p07);
                                    Console.WriteLine("Tie");
                                    Console.Write("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                if (player == "P1")
                                {
                                    player = "P2";
                                }
                                else
                                {
                                    player = "P1";
                                }
                            }
                            break;
                        case 2:
                            gameOnline = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        static void Board(string[] p01, string[] p02, string[] p03, string[] p04, string[] p05, string[] p06, string[] p07)
        {
            Console.Clear();
            Console.WriteLine("║ 01 ║ 02 ║ 03 ║ 04 ║ 05 ║ 06 ║ 07 ║");
            Console.WriteLine("╠════╬════╬════╬════╬════╬════╬════╣");

            for (int i = 5; i >= 0; i--)
            {
                Console.Write("║");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(" ");
                    switch (j)
                    {
                        case 0:
                            if (p01[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p01[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p01[i]);
                            Console.ResetColor();
                            break;
                        case 1:
                            if (p02[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p02[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p02[i]);
                            Console.ResetColor();
                            break;
                        case 2:
                            if (p03[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p03[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p03[i]);
                            Console.ResetColor();
                            break;
                        case 3:
                            if (p04[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p04[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p04[i]);
                            Console.ResetColor();
                            break;
                        case 4:
                            if (p05[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p05[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p05[i]);
                            Console.ResetColor();
                            break;
                        case 5:
                            if (p06[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p06[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p06[i]);
                            Console.ResetColor();
                            break;
                        case 6:
                            if (p07[i] == "P1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (p07[i] == "P2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            Console.Write(p07[i]);
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }
                    Console.Write(" ║");
                }
                Console.ResetColor();
                if (i != 0)
                {
                    Console.WriteLine("\n╠════╬════╬════╬════╬════╬════╬════╣");
                }

            }
            Console.WriteLine("\n╚════╩════╩════╩════╩════╩════╩════╝");


        }
        static bool WinningTest(string[] p01, string[] p02, string[] p03, string[] p04, string[] p05, string[] p06, string[] p07)
        {
            bool winner = false;
            string[] players = new string[] { "P1", "P2" };

            //Winning
            foreach (var item in players)
            {
                if (item == p01[0] && item == p01[1] && item == p01[2] && item == p01[3] || item == p01[1] && item == p01[2] && item == p01[3] && item == p01[4] || item == p01[2] && item == p01[3] && item == p01[4] && item == p01[5] ||
                    item == p02[0] && item == p02[1] && item == p02[2] && item == p02[3] || item == p02[1] && item == p02[2] && item == p02[3] && item == p02[4] || item == p02[2] && item == p02[3] && item == p02[4] && item == p02[5] ||
                    item == p03[0] && item == p03[1] && item == p03[2] && item == p03[3] || item == p03[1] && item == p03[2] && item == p03[3] && item == p03[4] || item == p03[2] && item == p03[3] && item == p03[4] && item == p03[5] ||
                    item == p04[0] && item == p04[1] && item == p04[2] && item == p04[3] || item == p04[1] && item == p04[2] && item == p04[3] && item == p04[4] || item == p04[2] && item == p04[3] && item == p04[4] && item == p04[5] ||
                    item == p05[0] && item == p05[1] && item == p05[2] && item == p05[3] || item == p05[1] && item == p05[2] && item == p05[3] && item == p05[4] || item == p05[2] && item == p05[3] && item == p05[4] && item == p05[5] ||
                    item == p06[0] && item == p01[1] && item == p01[2] && item == p01[3] || item == p06[1] && item == p01[2] && item == p01[3] && item == p01[4] || item == p06[2] && item == p01[3] && item == p01[4] && item == p01[5] ||
                    item == p07[0] && item == p07[1] && item == p07[2] && item == p07[3] || item == p07[1] && item == p07[2] && item == p07[3] && item == p07[4] || item == p07[2] && item == p07[3] && item == p07[4] && item == p07[5] ||
                    item == p01[0] && item == p02[0] && item == p03[0] && item == p04[0] || item == p01[1] && item == p02[1] && item == p03[1] && item == p04[1] || item == p01[2] && item == p02[2] && item == p03[2] && item == p04[2] ||
                    item == p01[3] && item == p02[3] && item == p03[3] && item == p04[3] || item == p01[4] && item == p02[4] && item == p03[4] && item == p04[4] || item == p01[5] && item == p02[5] && item == p03[5] && item == p04[5] ||
                    item == p02[0] && item == p03[0] && item == p04[0] && item == p05[0] || item == p02[1] && item == p03[1] && item == p04[1] && item == p05[1] || item == p02[2] && item == p03[2] && item == p04[2] && item == p05[2] ||
                    item == p02[3] && item == p03[3] && item == p04[3] && item == p05[3] || item == p02[4] && item == p03[4] && item == p04[4] && item == p05[4] || item == p02[5] && item == p03[5] && item == p04[5] && item == p05[5] ||
                    item == p03[0] && item == p04[0] && item == p05[0] && item == p06[0] || item == p03[1] && item == p04[1] && item == p05[1] && item == p06[1] || item == p03[2] && item == p04[2] && item == p05[2] && item == p06[2] ||
                    item == p03[3] && item == p04[3] && item == p05[3] && item == p06[3] || item == p03[4] && item == p04[4] && item == p05[4] && item == p06[4] || item == p03[5] && item == p04[5] && item == p05[5] && item == p06[5] ||
                    item == p04[0] && item == p05[0] && item == p06[0] && item == p07[0] || item == p04[1] && item == p05[1] && item == p06[1] && item == p07[1] || item == p04[2] && item == p05[2] && item == p06[2] && item == p07[2] ||
                    item == p04[3] && item == p05[3] && item == p06[3] && item == p07[3] || item == p04[4] && item == p05[4] && item == p06[4] && item == p07[4] || item == p04[5] && item == p05[5] && item == p06[5] && item == p07[5] ||
                    item == p01[0] && item == p02[1] && item == p03[2] && item == p04[3] || item == p01[1] && item == p02[2] && item == p03[3] && item == p04[4] || item == p01[2] && item == p02[3] && item == p03[4] && item == p04[5] ||
                    item == p02[0] && item == p03[1] && item == p04[2] && item == p05[3] || item == p02[1] && item == p03[2] && item == p04[3] && item == p05[4] || item == p02[2] && item == p03[3] && item == p04[4] && item == p05[5] ||
                    item == p03[0] && item == p04[1] && item == p05[2] && item == p06[3] || item == p03[1] && item == p04[2] && item == p05[3] && item == p06[4] || item == p03[2] && item == p04[3] && item == p05[4] && item == p06[5] ||
                    item == p04[0] && item == p05[1] && item == p06[2] && item == p07[3] || item == p04[1] && item == p05[2] && item == p06[3] && item == p07[4] || item == p04[2] && item == p05[3] && item == p06[4] && item == p07[5] ||
                    item == p01[5] && item == p02[4] && item == p03[3] && item == p04[2] || item == p01[4] && item == p02[3] && item == p03[2] && item == p04[1] || item == p01[3] && item == p02[2] && item == p03[1] && item == p04[0] ||
                    item == p02[5] && item == p03[4] && item == p04[3] && item == p05[2] || item == p02[4] && item == p03[3] && item == p04[2] && item == p05[1] || item == p02[3] && item == p03[2] && item == p04[1] && item == p05[0] ||
                    item == p03[5] && item == p04[4] && item == p05[3] && item == p06[2] || item == p03[4] && item == p04[3] && item == p05[2] && item == p06[1] || item == p03[3] && item == p04[2] && item == p05[1] && item == p06[0] ||
                    item == p04[5] && item == p05[4] && item == p06[3] && item == p07[2] || item == p04[4] && item == p05[3] && item == p06[2] && item == p07[1] || item == p04[3] && item == p05[2] && item == p06[1] && item == p07[0]
                )
                {
                    winner = true;
                }
            }





            if (winner)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //Connect 4



        //Hangman
        static void HangmanMain()
        {
            bool hangmanGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Hangman");
                Console.WriteLine("\n1. Play");
                Console.WriteLine("2. Close game\n");
                Console.Write("Menu choice: ");
                string hangmanChoice = Console.ReadLine();

                bool hangmanIsNummber = int.TryParse(hangmanChoice, out _);
                if (hangmanIsNummber)
                {
                    switch (hangmanChoice)
                    {
                        case "1":
                            hangmanGame();
                            break;
                        case "2":
                            hangmanGameOn = false;
                            break;

                        default:
                            break;
                    }
                }

            } while (hangmanGameOn);
        }
        static void hangmanGame()
        {
            bool haventWon = true;
            int maxForsøg = 6, forkertForsøg = 0, forsøgNummer = 0;
            string hangmanWord = wordCreation();
            List<string> hangmanSplittetSentence = new List<string>();
            string[] hangedPerson = new string[] { " ", " ", " ", " ", " ", " " };
            string letter;

            foreach (char item in hangmanWord)
            {
                switch (item.ToString())
                {
                    case "A":
                    case "a":
                        letter = "a";
                        break;
                    case "B":
                    case "b":
                        letter = "b";
                        break;
                    case "C":
                    case "c":
                        letter = "c";
                        break;
                    case "D":
                    case "d":
                        letter = "d";
                        break;
                    case "E":
                    case "e":
                        letter = "e";
                        break;
                    case "F":
                    case "f":
                        letter = "f";
                        break;
                    case "G":
                    case "g":
                        letter = "g";
                        break;
                    case "H":
                    case "h":
                        letter = "h";
                        break;
                    case "I":
                    case "i":
                        letter = "i";
                        break;
                    case "J":
                    case "j":
                        letter = "j";
                        break;
                    case "K":
                    case "k":
                        letter = "k";
                        break;
                    case "L":
                    case "l":
                        letter = "l";
                        break;
                    case "M":
                    case "m":
                        letter = "m";
                        break;
                    case "N":
                    case "n":
                        letter = "n";
                        break;
                    case "O":
                    case "o":
                        letter = "o";
                        break;
                    case "P":
                    case "p":
                        letter = "p";
                        break;
                    case "Q":
                    case "q":
                        letter = "q";
                        break;
                    case "R":
                    case "r":
                        letter = "r";
                        break;
                    case "S":
                    case "s":
                        letter = "s";
                        break;
                    case "T":
                    case "t":
                        letter = "t";
                        break;
                    case "U":
                    case "u":
                        letter = "u";
                        break;
                    case "V":
                    case "v":
                        letter = "v";
                        break;
                    case "W":
                    case "w":
                        letter = "w";
                        break;
                    case "X":
                    case "x":
                        letter = "x";
                        break;
                    case "Y":
                    case "y":
                        letter = "y";
                        break;
                    case "Z":
                    case "z":
                        letter = "z";
                        break;
                    case "Æ":
                    case "æ":
                        letter = "æ";
                        break;
                    case "Ø":
                    case "ø":
                        letter = "ø";
                        break;
                    case "Å":
                    case "å":
                        letter = "å";
                        break;
                    default:
                        letter = " ";
                        break;
                }
                hangmanSplittetSentence.Add(letter);
            }
            List<string> possibleLetters = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "æ", "ø", "å" };


            List<string> hangmanGuessedLetters = new List<string>() { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };


            //Gætter ord
            while (true)
            {
                Console.Clear();
                foreach (var item in hangmanSplittetSentence)
                {
                    if (item.ToString() == " ")
                    {
                        Console.Write("   ");
                    }
                    else if (hangmanGuessedLetters.Contains(item.ToString()))
                    {
                        Console.Write(item + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(@"_________");
                Console.WriteLine(@" |/     | ");
                Console.WriteLine(@" |      | ");
                Console.WriteLine(@" |      {0} ", hangedPerson[0]);
                Console.WriteLine(@" |     {0}{1}{2}", hangedPerson[2], hangedPerson[1], hangedPerson[3]);
                Console.WriteLine(@" |     {0} {1}", hangedPerson[4], hangedPerson[5]);
                Console.WriteLine(@" |        ");
                Console.WriteLine(@"_|________________");
                hangmanGuessedLetters.Sort();
                Console.WriteLine(@"| {0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13} |", hangmanGuessedLetters[0], hangmanGuessedLetters[1], hangmanGuessedLetters[2], hangmanGuessedLetters[3], hangmanGuessedLetters[4], hangmanGuessedLetters[5], hangmanGuessedLetters[6], hangmanGuessedLetters[7], hangmanGuessedLetters[8], hangmanGuessedLetters[9], hangmanGuessedLetters[10], hangmanGuessedLetters[11], hangmanGuessedLetters[12], hangmanGuessedLetters[13]);
                Console.WriteLine(@"| {0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13} |", hangmanGuessedLetters[14], hangmanGuessedLetters[15], hangmanGuessedLetters[16], hangmanGuessedLetters[17], hangmanGuessedLetters[18], hangmanGuessedLetters[19], hangmanGuessedLetters[20], hangmanGuessedLetters[21], hangmanGuessedLetters[22], hangmanGuessedLetters[23], hangmanGuessedLetters[24], hangmanGuessedLetters[25], hangmanGuessedLetters[26], hangmanGuessedLetters[27]);
                Console.WriteLine();

                foreach (var item in hangmanSplittetSentence)
                {
                    if (!hangmanGuessedLetters.Contains(item))
                    {
                        haventWon = true;
                        break;
                    }
                    else
                    {
                        haventWon = false;
                    }
                }



                if (forkertForsøg == maxForsøg && haventWon)
                {
                    Console.Write("GAME OVER\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }
                else if (forkertForsøg < maxForsøg && haventWon)
                {
                    Console.Write("Guess a letter: ");
                    string guessedLetter = Console.ReadKey().KeyChar.ToString();
                    if (!hangmanGuessedLetters.Contains(guessedLetter) && possibleLetters.Contains(guessedLetter))
                    {
                        hangmanGuessedLetters[forsøgNummer] = guessedLetter;
                        forsøgNummer += 1;
                        if (!hangmanSplittetSentence.Contains(guessedLetter))
                        {
                            forkertForsøg += 1;
                            switch (forkertForsøg)
                            {
                                case 1:
                                    hangedPerson[0] = "O";
                                    break;
                                case 2:
                                    hangedPerson[1] = "|";
                                    break;
                                case 3:
                                    hangedPerson[2] = "/";
                                    break;
                                case 4:
                                    hangedPerson[3] = @"\";
                                    break;
                                case 5:
                                    hangedPerson[4] = "/";
                                    break;
                                case 6:
                                    hangedPerson[5] = @"\";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                else if (haventWon == false)
                {
                    Console.Write("CONGRATULATIONS! YOU WON\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                }
            }




        }
        static string wordCreation()
        {
            Console.Clear();
            Console.WriteLine("Host choose a word or sentence\n");
            Console.Write("Word/Sentence: ");
            string word = Console.ReadLine();
            return word;
        }
        //Hangman



        //NotAGame
        static void NotAGame()
        {
            bool gameOn = true, menu;
            int counter = 0;
            while (gameOn)
            {
                menu = true;
                Console.WriteLine("This is not a game");
                Console.WriteLine("\n1. Shutdown Game");
                Console.Write("\nMenu choise: ");
                do
                {
                    string menuChoise = Console.ReadLine();

                    switch (menuChoise)
                    {
                        case "1":
                            gameOn = false;
                            menu = false;
                            break;
                        case "start":
                        case "Start":
                            Console.Clear();
                            Console.WriteLine("The wood frog can hold its pee for up to eight months.");
                            Console.WriteLine("Congratulations! This is a fact. Now close the game.");
                            Console.WriteLine("\n1. Shutdown Game");
                            break;
                        case "Quit":
                        case "quit":
                            Console.Clear();
                            Console.WriteLine("So you are a quitter huh?\nTake this fact as a medal.");
                            Console.WriteLine("Quitters never win");
                            Console.WriteLine("\n1. Shutdown Game");
                            break;
                        case "Trash":
                        case "trash":
                            Console.Clear();
                            Console.WriteLine("The average person generates over 4 pounds (1,8 kg) of trash every day");
                            Console.WriteLine("\n1. Shutdown Game");
                            break;
                        case "end":
                        case "End":
                            Console.Clear();
                            Console.WriteLine("39 BILLION videos are viewed per month in the U.S. That's 211 videos viewed and 16 hours of time spent per person, per MONTH!");
                            Console.WriteLine("\n1. Shutdown Game");
                            break;
                        case "  ":
                        case " ":
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("\n1. Shutdown Game");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Okay dummy... Try again");
                            menu = false;
                            break;
                    }
                    counter += 1;
                    if (counter == 3)
                    {
                        Console.WriteLine("Heres another fact! This is not a game.\n");
                    }
                    if (counter == 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Apparently dedication pays off...");
                        Console.Write("Press any key to play a random game...");
                        Console.ReadKey();
                        Random range = new Random();
                        int randomGame = range.Next(1,7);

                        switch (randomGame)
                        {
                            case 1:
                                Console.Clear();
                                TTTMain();
                                break;
                            case 2:
                                Console.Clear();
                                MineSweeperMain();
                                break;
                            case 3:
                                Console.Clear();
                                Connect4();
                                break;
                            case 4:
                                Console.Clear();
                                HangmanMain();
                                break;
                            case 5:
                                Console.Clear();
                                RPSMain();
                                break;
                            case 6:
                                
                                break;
                            default:
                                break;
                        }

                        menu = false;
                        gameOn = false;

                    }
                } while (menu);
            }
        }
        //NotAGame



        //Rock Paper Scissors
        static void RPSMain()
        {
            bool RPSGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Rock Paper Scissors");
                Console.WriteLine("\n1. Play");
                Console.WriteLine("2. Close game\n");

                Console.Write("Choose menu: ");
                string RPSMenuChoise = Console.ReadLine();

                bool RPSIsNumber = int.TryParse(RPSMenuChoise, out _);
                if (RPSIsNumber)
                {
                    switch (RPSMenuChoise)
                    {
                        case "1":
                            RPSgame();
                            break;
                        case "2":
                            RPSGameOn = false;
                            break;
                        default:
                            break;
                    }
                }


            } while (RPSGameOn);
        }
        static void RPSgame()
        {
            string[] RPSitems = new string[] { "Rock", "Paper", "Scissors" };
            int RPSItemChoosenInt;
            do
            {
                Console.Clear();
                Console.WriteLine("Rock > Scissors > Paper > Rock");
                Console.WriteLine("\n1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Scissors\n");
                Console.Write("Choose an item: ");
                string RPSItemChoosen = Console.ReadLine();
                bool RPSItemIsNumber = int.TryParse(RPSItemChoosen, out RPSItemChoosenInt);
                if (RPSItemIsNumber)
                {
                    int RPSrobotChoise = RPSRobot();
                    Console.Clear();
                    Console.WriteLine("Player choise: {0}\nAI choise: {1}", RPSitems[RPSItemChoosenInt - 1], RPSitems[RPSrobotChoise - 1]);

                    RPSWinnerCheck(RPSitems[RPSItemChoosenInt - 1], RPSitems[RPSrobotChoise - 1]);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();

                    break;
                }
            } while (true);
        }
        static int RPSRobot()
        {
            Random RPSrange = new Random();
            int RPSitem = RPSrange.Next(1, 4);
            Console.WriteLine(RPSitem);
            return RPSitem;
        }
        static void RPSWinnerCheck(string RPSPlayerItem, string RPSAIItem)
        {
            if (RPSPlayerItem == "Rock" && RPSAIItem == "Scissors" || RPSPlayerItem == "Paper" && RPSAIItem == "Rock" || RPSPlayerItem == "Scissors" && RPSAIItem == "Paper")
            {
                Console.WriteLine("Player won");
            }
            else if (RPSAIItem == "Rock" && RPSPlayerItem == "Scissors" || RPSAIItem == "Paper" && RPSPlayerItem == "Rock" || RPSAIItem == "Scissors" && RPSPlayerItem == "Paper")
            {
                Console.WriteLine("Ai won");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
        //Rock Paper Scissors



        //Battleships

        //Battleships
    }
}
