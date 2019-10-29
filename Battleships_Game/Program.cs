using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships_Game
{

    public class Program
    {
        //running of program to call all the methods created!
        static void Main(string[] args)
        {
            //Call the first methods
            introduction();

            BattleshipBoard b = new BattleshipBoard();
            Player p = new Player();

            p.Randomize();

            //Keep the game in a loop until hit count 13
            while (p.getHitCount() < 13)
            {
                b.DrawBoard(p);
                p.AskCoordinates();

            }

            goodBye();

        } // End public class Program


        //NOT CURENTLY USED
        public enum ShipOrientation
        {
            Horizontal = 0,
            Vertical
        }


        static void introduction()
        {
            Console.Title = "Battleships Game";
            Console.WriteLine("Welcome to Battleships \n\nPress any key to continue");
            Console.ReadLine();

        } // End static void introduction()


        //New class for BattleshipBoard Game
        public class BattleshipBoard
        {

            public void DrawBoard(Player p)
            {
                char[,] Grid = p.GetGrid();

                Console.WriteLine("A   B   C   D   E   F   G   H   I   J");
                Console.WriteLine("---------------------------------------");
               
                for (int x = 0; x < 10; x++)
                {
                    
                    for (int i = 0; i < 10; i++)
                    {
                        //  Grid[i, x] = '0';
                        
                        Console.Write(Grid[i , x] + " | ");
                    }
                    Console.WriteLine();
                }

            } //End public void DrawBoard(Player p)



        } // End public class BattleshipBoard
        


        static void goodBye()
        {
            Console.Clear();
            Console.WriteLine("You Win! Thank you for playing Battleships!");
            Console.ReadLine();

        } // End static void goodBye()


                //Position a ship on the grid //Create the random number generator - to place ship
                static void PositionShip()
                {

                    int RandomNumber(int row, int col)
                    {
                        Random randomNumber = new Random();
                        return randomNumber.Next(row, col);

                    }

                }

            

        //New Player Class - Creating the grid array
        public class Player
        {
            char[,] Grid = new char[10, 10];
            public int HitCount = 0;


            int x = 0;
            int y = 0;


            // Declaration of the array and Intialization
            string[] Xcoord = new string[]{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            public int getHitCount()
            {
                return HitCount;
            }


            public char[,] GetGrid()
            {
                return Grid;
            }

            public void SetGrid(int q, int w)
            {
                Grid[q, w] = ' ';
            }


            //Method to call for asking co-ords (player input)
            public void AskCoordinates()
            {

                Console.WriteLine("Enter X (Capital Letter A - J)");
                string xPosition = Console.ReadLine();
                int xvalue;
                int yvalue = 0;

                while (!Array.Exists(Xcoord, element => element == xPosition))
                {
                    Console.WriteLine("Error, enter a capital letter for X");
                    xPosition = Console.ReadLine();
                }
                
                xvalue = Array.IndexOf(Xcoord, xPosition);

                Console.WriteLine("Enter Y (Number 0 - 9)");
                string yPosition = Console.ReadLine();
                int value;


                if (int.TryParse(yPosition, out value))
                {
                    yvalue = value;
                }
                else
                {
                    Console.WriteLine("Error, enter a number for Y");
                    yPosition = Console.ReadLine();
                }

                //Decrement the y by 1
                yvalue--;
                try
                {
                    if (Grid[xvalue,yvalue+1].Equals(' '))
                    {
                        Grid[xvalue, yvalue+1] = 'H';
                        Console.Clear();
                        Console.WriteLine("Hit!\r\n");
                        HitCount += 1;
                    }
                    else
                    {
                        Grid[xvalue, yvalue+1] = 'M';
                        Console.Clear();
                        Console.WriteLine("Miss!\r\n");

                    }
                }
                catch
                {
                    Console.Clear();

                }

            } // End public void AskCoordinates()



            //Method for placing ships on the grid
            public void Randomize()
            {
                //1-2 of length 4 (Destroyer)
                SetGrid(0, 8);
                SetGrid(1, 8);
                SetGrid(2, 8);
                SetGrid(3, 8);

                //2-2 length 4 (Destroyer 2)
                SetGrid(9, 0);
                SetGrid(9, 1);
                SetGrid(9, 2);
                SetGrid(9, 3);

                //1 of length 5 (Battleship)
                SetGrid(7, 4);
                SetGrid(7, 5);
                SetGrid(7, 6);
                SetGrid(7, 7);
                SetGrid(7, 8);

                //NOT CURRENTLY USED
                /*
                //This can be used to create random number (random co-ords for the placement of ships)
                //Not sure how to implement yet!!
                Random rand = new Random();

                // Define a list that holds the ships
                Ship ListShips = new Ship(Grid);

                // Define the ships
                Ship s = new Ship(Grid)
                {

                    Name = "Battleship",
                    Orientation = ShipOrientation.Horizontal,
                    ExtentUnits = 5,

               //     Grid = [2,2],

   

            };

     */



            } // End  public void Randomize()


        } // End public class Player



    } // End public class Program



} // End namespace Battleships_Game

