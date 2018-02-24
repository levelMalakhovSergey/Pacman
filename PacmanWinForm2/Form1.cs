using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PacmanWinForm2
{
    public partial class Form1 : Form
    {
        public static int temp = 4;
        static Random rndGhost = new Random();
        public static int r1 = rndGhost.Next(temp);
        public static int r2 = rndGhost.Next(temp);
        public static int r3 = rndGhost.Next(temp);
        public static int LifeAfterGhost1 = 0;
        public static int LifeAfterGhost2 = 0;
        public static int LifeAfterGhost3 = 0;
        public static int colvoOfEat = 10;
        public static int rightsite = 0;
        public static int leftsite = 0;
        public static int topSite = 0;
        public static int botsite = 0;
        public static int[,] GhostsPlases = new int[3, 2];
        public static int[,] table = new int[20, 20];
        public static void DrawTable(int[,] table, System.IntPtr handle)
        {
            int x = 0;
            int y = 0;
            Sell value = new Sell();
            Graphics gr = Graphics.FromHwnd(handle);
            for (int i = 0; i < table.GetLength(0); i++)
            {

                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == value.Wall)
                    {

                        gr.FillRectangle(Brushes.Black, x, y, 10, 10);

                    }
                    if (table[i, j] == value.Eat)
                    {

                        gr.FillRectangle(Brushes.Green, x, y, 10, 10);
                    }
                    if (table[i, j] == value.Normal)
                    {

                        gr.FillRectangle(Brushes.Yellow, x, y, 10, 10);
                    }
                    if (table[i, j] == value.Ghost)
                    {

                        gr.FillRectangle(Brushes.Blue, x, y, 10, 10);
                    }
                    x += 10;
                }
                x = 0;
                y += 10;
            }
        }
        //public static string[,] Move1(KeyEventArgs pressedKey, string[,] table, ref int x, ref int y)
        //{                  
        //    if (pressedKey.KeyData == Keys.Right)
        //    {
        //        if (y != 9)
        //        {
        //            if (table[y + 1, x] == "* ")
        //            {
        //                botsite = 1;
        //            }
        //            else
        //            {
        //                botsite = 0;
        //            }
        //        }
        //        if (x != 9)
        //        {
        //            if (table[y, x + 1] == "* ")
        //            {
        //                rightsite = 1;

        //            }
        //            else
        //            {
        //                rightsite = 0;
        //            }
        //        }
        //        if (x != 0)
        //        {
        //            if (table[y, x - 1] == "* ")
        //            {
        //                leftsite = 1;
        //            }
        //            else
        //            {
        //                leftsite = 0;
        //            }
        //        }

        //        if (y != 0)
        //        {
        //            if (table[y - 1, x] == "* ")
        //            {
        //                topSite = 1;
        //            }
        //            else
        //            {
        //                topSite = 0;
        //            }
        //        }






        //        x++;
        //        if (x < 0)
        //        {
        //            x = 0;
        //        }
        //        if (x > 9)
        //        {
        //            x = 9;
        //        }
        //        if (x < 10)
        //        {
        //            if (table[y, x] != "0 " && x != 9)
        //            {
        //                table[y, x] = "@ ";
        //                if (x != 0 && table[y, x - 1] != "0 ")
        //                {
        //                    table[y, x - 1] = "  ";
        //                }//Зачистка   
        //                if (rightsite == 1)
        //                {
        //                    colvoOfEat--;
        //                }


        //            }
        //            else
        //            {
        //                x--;
        //            }

        //        }


        //    }
        //    if (pressedKey.Key == ConsoleKey.DownArrow)
        //    {

        //        if (y != 9)
        //        {
        //            if (table[y + 1, x] == "* ")
        //            {
        //                botsite = 1;
        //            }
        //            else
        //            {
        //                botsite = 0;
        //            }
        //        }
        //        if (x != 9)
        //        {
        //            if (table[y, x + 1] == "* ")
        //            {
        //                rightsite = 1;

        //            }
        //            else
        //            {
        //                rightsite = 0;
        //            }
        //        }
        //        if (x != 0)
        //        {
        //            if (table[y, x - 1] == "* ")
        //            {
        //                leftsite = 1;
        //            }
        //            else
        //            {
        //                leftsite = 0;
        //            }
        //        }
        //        if (y != 0)
        //        {
        //            if (table[y - 1, x] == "* ")
        //            {
        //                topSite = 1;
        //            }
        //            else
        //            {
        //                topSite = 0;
        //            }
        //        }
        //        y++;
        //        if (y < 0)
        //        {
        //            y = 0;
        //        }
        //        if (y > 9)
        //        {
        //            y = 9;
        //        }
        //        if (y < 10)
        //        {
        //            if (table[y, x] != "0 " && y != 9)
        //            {
        //                table[y, x] = "@ ";
        //                if (y != 0 && table[y - 1, x] != "0 ")
        //                {
        //                    table[y - 1, x] = "  ";
        //                }//Зачистка
        //                if (botsite == 1)
        //                {
        //                    colvoOfEat--;
        //                }

        //            }
        //            else
        //            {
        //                y--;
        //            }
        //        }
        //    }
        //    if (pressedKey.Key == ConsoleKey.UpArrow)
        //    {
        //        if (y != 9)
        //        {
        //            if (table[y + 1, x] == "* ")
        //            {
        //                botsite = 1;
        //            }
        //            else
        //            {
        //                botsite = 0;
        //            }
        //        }
        //        if (x != 9)
        //        {
        //            if (table[y, x + 1] == "* ")
        //            {
        //                rightsite = 1;

        //            }
        //            else
        //            {
        //                rightsite = 0;
        //            }
        //        }
        //        if (x != 0)
        //        {
        //            if (table[y, x - 1] == "* ")
        //            {
        //                leftsite = 1;
        //            }
        //            else
        //            {
        //                leftsite = 0;
        //            }
        //        }
        //        if (y != 0)
        //        {
        //            if (table[y - 1, x] == "* ")
        //            {
        //                topSite = 1;
        //            }
        //            else
        //            {
        //                topSite = 0;
        //            }
        //        }
        //        y--;
        //        if (y < 0)
        //        {
        //            y = 0;
        //        }
        //        if (y > 9)
        //        {
        //            y = 9;
        //        }
        //        if (y >= 0)
        //        {
        //            if (table[y, x] != "0 " && y != 9)
        //            {
        //                table[y, x] = "@ ";

        //                if (y != columns && table[y + 1, x] != "0 ")
        //                {
        //                    table[y + 1, x] = "  ";
        //                }//Зачистка
        //                if (topSite == 1)
        //                {
        //                    colvoOfEat--;
        //                }


        //            }
        //            else
        //            {
        //                y++;
        //            }
        //        }

        //    }
        //    if (pressedKey.Key == ConsoleKey.LeftArrow)
        //    {

        //        if (y != 9)
        //        {
        //            if (table[y + 1, x] == "* ")
        //            {
        //                botsite = 1;
        //            }
        //            else
        //            {
        //                botsite = 1;
        //            }
        //        }
        //        if (x != 9)
        //        {
        //            if (table[y, x + 1] == "* ")
        //            {
        //                rightsite = 1;

        //            }
        //            else
        //            {
        //                rightsite = 0;
        //            }
        //        }
        //        if (x != 0)
        //        {
        //            if (table[y, x - 1] == "* ")
        //            {
        //                leftsite = 1;
        //            }
        //            else
        //            {
        //                leftsite = 0;
        //            }
        //        }
        //        if (y != 0)
        //        {
        //            if (table[y - 1, x] == "* ")
        //            {
        //                topSite = 1;
        //            }
        //            else
        //            {
        //                topSite = 0;
        //            }
        //        }


        //        x--;

        //        if (x < 0)
        //        {
        //            x = 0;
        //        }
        //        if (x > 9)
        //        {
        //            x = 9;
        //        }
        //        if (x >= 0)
        //        {
        //            if (table[y, x] != "0 " && x != 9)
        //            {
        //                table[y, x] = "@ ";
        //                if (x != rows && table[y, x + 1] != "0 ")
        //                {
        //                    table[y, x + 1] = "  ";
        //                }//Зачистка
        //                if (leftsite == 1)
        //                {
        //                    colvoOfEat--;
        //                }

        //            }
        //            else
        //            {
        //                x++;
        //            }
        //        }

        //    }
        //    return table;
        //}
        public static void Ghost1Move()
        {
            Sell value = new Sell();
            int x = GhostsPlases[0, 0];
            int y = GhostsPlases[0, 1];
            if (x - 1 == 0||x==0)
            {
                r1 = 2;
            }
            else
            if (y - 1 == 0 || y == 0)
            {
                r1 = 3;
            }
            else
            if (x + 1 == 19 || x == 19)
            {
                r1 = 0;
            }
            else
            if(y + 1 == 19 || y == 19)
                {
                r1 = 1;
            }
                
            if (r1 == 0)//Move to Top
            {
                              
                if (x >= 0 && x < 19 && y >=0 && y < 19)
                {x -= 1;
                    if (table[x, y] != value.Wall)
                    {                                             
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1==1)
                        {
                            table[x+1, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x+1, y] = value.Normal;
                        }

                        table[x , y] = value.Ghost;
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                    }
                    else
                    {
                        r1 = rndGhost.Next(temp);
                    }
                }
            } //Move to Top
            else
            if (r1 == 1)//Move to left
            {
                
                if (x >= 0 && x < 19 && y >= 0 && y < 19)
                {y -= 1;//Move to left
                    if (table[x, y ] != value.Wall)
                    {
                        if (table[x , y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x, y+1] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                    }
                    else
                    {
                        r1 = rndGhost.Next(temp);
                    }
                }
            }//Move to left
            else
            if (r1 == 2) //Move to Bot
            {
                
                if (x >= 0 && x < 19 && y >= 0 && y < 19)
                {x += 1; //Move to Bot
                    if (table[x , y] != value.Wall)
                    {
                        if (table[x , y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x-1, y] = value.Normal;
                        }
                        table[x , y] = value.Ghost;
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                    }
                    else
                    {
                        r1 = rndGhost.Next(temp);
                    }
                }
            } //Move to Bot
            else
            if (r1 == 3) //Move to Right
            {
                
                if (x >= 0 && x < 19 && y >= 0 && y < 19)
                {y+= 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x , y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x, y-1] = value.Normal;
                        }
                        table[x , y] = value.Ghost;
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                    }
                    else
                    {
                        r1 = rndGhost.Next(temp);
                    }//Move to Right
                }
            }


        }
        public static void Ghost2Move()
        {
            Sell value = new Sell();
            int x = GhostsPlases[1, 0];
            int y = GhostsPlases[1, 1];
            if (x - 1 == 0 || x == 0)
            {
                r2 = 2;
            }
            else
            if (y - 1 == 0 || y == 0)
            {
                r2 = 3;
            }
            else
            if (x + 1 == 19 || x == 19)
            {
                r2 = 0;
            }
            else
            if (y + 1 == 19 || y == 19)
            {
                r2 = 1;
            }

            if (r2 == 0)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    x -= 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x + 1, y] = value.Normal;
                        }

                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                    }
                    else
                    {
                        r2= rndGhost.Next(temp);
                    }
                }
            }//Move to left
            else
            if (r2 == 1)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    y -= 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x, y + 1] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                    }
                    else
                    {
                        r2 = rndGhost.Next(temp);
                    }
                }
            }
            else
            if (r2 == 2)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    x += 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x-1, y] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                    }
                    else
                    {
                        r2 = rndGhost.Next(temp);
                    }
                }
            }
            else
            if (r2 == 3)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    y += 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x, y-1] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                    }
                    else
                    {
                        r2 = rndGhost.Next(temp);
                    }
                }
            }


        }
        public static void Ghost3Move()
        {
            Sell value = new Sell();
            int x = GhostsPlases[2, 0];
            int y = GhostsPlases[2, 1];
            if (x - 1 == 0 || x == 0)
            {
                r3 = 2;
            }
            else
            if (y - 1 == 0 || y == 0)
            {
                r3 = 3;
            }
            else
            if (x + 1 == 19 || x == 19)
            {
                r3 = 0;
            }
            else
            if (y + 1 == 19 || y == 19)
            {
                r3 = 1;
            }

            if (r3 == 0)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    x -= 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x + 1, y] = value.Normal;
                        }

                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }//Move to left
            else
            if (r3 == 1)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    y -= 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x, y + 1] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }
            else
            if (r3 == 2)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    x += 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x-1, y] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }
            else
            if (r3 == 3)
            {

                if (x > 0 && x < 19 && y > 0 && y < 19)
                {
                    y += 1;
                    if (table[x, y] != value.Wall)
                    {
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                        }
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                        }
                        else
                        {
                            table[x, y-1] = value.Normal;
                        }
                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Sell value = new Sell();
            Random r1 = new Random();
            int a = 0;
            int b = 0;
            for (int i = 0; i < 50; i++)
            {
                a = r1.Next(20);

                b = r1.Next(20);

                table[a, b] = value.Wall;
            }
            for (int i = 0; i < 10; i++)
            {
                a = r1.Next(20);

                b = r1.Next(20);

                if (table[a, b] != value.Wall)
                {
                    table[a, b] = value.Eat;
                }
                else
                {
                    i--;
                }

            }

            for (int i = 0; i < 3; i++)
            {
                a = r1.Next(20);

                b = r1.Next(20);

                if (table[a, b] != value.Wall)
                {
                    if (table[a, b] != value.Eat)
                    {

                        table[a, b] = value.Ghost;
                        GhostsPlases[i, 0] = a;
                        GhostsPlases[i, 1] = b;
                    }

                }
                else
                {
                    i--;
                }

            }
            button1.Enabled = false;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var handle = this.Handle;
            DrawTable(table, handle);
            new Thread(Ghost1Move).Start();
            new Thread(Ghost2Move).Start();
            new Thread(Ghost3Move).Start();


            //table = Move(pressedKey, table, ref X, ref Y);
            if (colvoOfEat == 0)
            {
                Console.WriteLine("Congratulations");
                return;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


        }
    }
}

