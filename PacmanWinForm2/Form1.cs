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
using System.IO;
using NLog;


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
        public static int[,] GhostsPlases = new int[3, 2];
        public static int[,] table = new int[20, 20];
        public static int PacmanX = 0;
        public static int PacmanY = 0;

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
                    if (table[i, j] == value.Pacman)
                    {

                        gr.FillRectangle(Brushes.Red, x, y, 10, 10);
                    }
                    x += 10;
                }
                x = 0;
                y += 10;
            }
        }
        public static void Move1(KeyEventArgs pressedKey )
        {
            Sell value = new Sell();
            logger.Info("MOVE");
            logger.Info("MOVE");
            logger.Info("MOVE");
            if (table[PacmanX,PacmanY]!= value.Wall)
            {
                PacmanX -= 1;
                logger.Info("X- " + PacmanX);
                logger.Info("Y- " + PacmanY);
                if (pressedKey.KeyData==Keys.Up)
                {
                    if (table[PacmanX - 1, PacmanY] !=value.Wall)
                    {                       
                        if (table[PacmanX - 1, PacmanY] ==value.Eat)
                        {
                            colvoOfEat++;
                        }
                        else if (table[PacmanX - 1, PacmanY] == value.Ghost)
                        {
                            MessageBox.Show("Game Over");
                            MessageBox.Show("You lose");
                            return;
                        }
                        table[PacmanX - 1, PacmanY] = value.Pacman;
                        
                        
                        
                    }
                }
            }           
        }
        //public static void WriteMessage(string InputString)
        //{
        //    using (StreamWriter sw = new StreamWriter("output.txt"))
        //    {
        //        WriteList.Add(InputString);
        //        for (int i = 0; i < WriteList.Count-1; i++)
        //        {
        //            sw.WriteLine(WriteList[i]);
        //        }


        //    }
        //}
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Logger updateLogger = LogManager.GetLogger("UpdateLogger");
        public static void Ghost1Move()
        {
            

            logger.Info("Start");
            Sell value = new Sell();
            int x = GhostsPlases[0, 0];
            int y = GhostsPlases[0, 1];
           
            if (x == 0)
            {
                do
                {
                    r1 = rndGhost.Next(temp);
                } while (r1==0);
                logger.Info("Направление -"+r1);
                LifeAfterGhost1 = 0;
            }
            else
            if (y == 0)
            {
                do
                {
                    r1 = rndGhost.Next(temp);
                } while (r1 == 1);
                logger.Info("Направление -" + r1);
                LifeAfterGhost1 = 0;
            }
            else
            if (x == 19)
            {
                do
                {
                    r1 = rndGhost.Next(temp);
                } while (r1 == 2);
                logger.Info("Направление -" + r1);
                LifeAfterGhost1 = 0;
            }
            else
            if (y == 19)
            {
                do
                {
                    r1 = rndGhost.Next(temp);
                } while (r1 == 3);
                logger.Info("Направление -" + r1);
                LifeAfterGhost1 = 0;
            }
            
            if (r1 == 0)//Move to Top
            {
                logger.Info("Move to Top");
               
                
                if (x > 0 && x <= 19 && y >= 0 && y <= 19)
                {
                    x -= 1;
                    logger.Info("x= " + x);
                    logger.Info("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Info("not wall");
                        if (LifeAfterGhost1 == 1)
                        {
                            
                            table[x + 1, y] = value.Eat;
                            logger.Info("table[{0}, {1}] = value.Eat",x+1,y);
                            logger.Info("LifeAfterGhost1 == 0");
                            LifeAfterGhost1 = 0;
                            
                        }
                        else
                        {
                            
                            table[x + 1, y] = value.Normal;
                            logger.Info("LifeAfterGhost1 == 0");
                            logger.Info("table[{0}, {1}] = value.Normal", x + 1, y);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1;
                            logger.Info("LifeAfterGhost1 == 1");
                        }
                        

                        table[x, y] = value.Ghost;
                        logger.Info(" table[{0}, {1}]= value.Ghost",x,y);
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
                logger.Info("Move to Left");
                if (x >= 0 && x <= 19 && y > 0 && y <= 19)
                {
                    y -= 1;//Move to left
                    

                    logger.Info("x= " + x);
                    logger.Info("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Info("not wall");
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y+1] = value.Eat;
                            logger.Info("table[{0}, {1}] = value.Eat", x , y+1);
                            logger.Info("LifeAfterGhost1 == 0");
                            LifeAfterGhost1 = 0;
                           
                        }
                        else
                        {
                            table[x, y + 1] = value.Normal;
                            logger.Info("table[{0}, {1}] = value.Normal", x , y + 1);
                            

                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1; logger.Info("LifeAfterGhost1 == 1");
                        }

                        table[x, y] = value.Ghost;
                        
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                        
                        logger.Info(" table[{0}, {1}]= value.Ghost", x, y);
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
                logger.Info("Move to Bot");
                if (x >= 0 && x < 19 && y >= 0 && y <= 19)
                {
                    x += 1; //Move to Bot
                    logger.Info("x= " + x);
                    logger.Info("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Info("not wall");
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x-1, y] = value.Eat;
                            LifeAfterGhost1 = 0;
                            logger.Info("table[{0}, {1}] = value.Eat", x-1, y );
                            logger.Info("LifeAfterGhost1 == 0");
                        }
                        else
                        {
                            table[x - 1, y] = value.Normal;
                            logger.Info("table[{0}, {1}] = value.Normal", x-1,y );
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1; logger.Info("LifeAfterGhost1 == 1");
                        }

                        table[x, y] = value.Ghost;
                        logger.Info(" table[{0}, {1}]= value.Ghost", x, y);
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                        logger.Info(" GhostsPlases[0, 0] = " + x);
                        logger.Info(" GhostsPlases[0, 1] = " + y);
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
                logger.Info("Move to Right");
                if (x >= 0 && x <= 19 && y >= 0 && y < 19)
                {
                    y += 1;
                    if (table[x, y] != value.Wall)
                    {
                        logger.Info("not wall");
                        if (LifeAfterGhost1 == 1)
                        {
                            table[x, y-1] = value.Eat;
                            LifeAfterGhost1 = 0;
                            logger.Info("table[{0}, {1}] = value.Eat", x, y-1);
                            logger.Info("LifeAfterGhost1 == 0");
                        }
                        else
                        {
                            table[x, y - 1] = value.Normal;
                            logger.Info("table[{0}, {1}] = value.Normal", x, y - 1);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost1 = 1; logger.Info("LifeAfterGhost1 == 1");
                        }

                        table[x, y] = value.Ghost;
                        logger.Info(" table[{0}, {1}]= value.Ghost", x, y);
                        GhostsPlases[0, 0] = x;
                        GhostsPlases[0, 1] = y;
                        logger.Info(" GhostsPlases[0, 0] = " + x);
                        logger.Info(" GhostsPlases[0, 1] = " + y);
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
            if (x == 0)
            {
                do
                {
                    r2 = rndGhost.Next(temp);
                } while (r2 == 0);
                logger.Error("Направление -" + r1);
                LifeAfterGhost2 = 0;
            }
            else
             if (y == 0)
            {
                do
                {
                    r2 = rndGhost.Next(temp);
                } while (r2 == 1);
                LifeAfterGhost2 = 0; logger.Error("Направление -" + r1);
            }
            else
             if (x == 19)
            {
                do
                {
                    r2 = rndGhost.Next(temp);
                } while (r2 == 2);
                LifeAfterGhost2 = 0; logger.Error("Направление -" + r1);
            }
            else
             if (y == 19)
            {
                do
                {
                    r2 = rndGhost.Next(temp);
                } while (r2 == 3);
                LifeAfterGhost2 = 0; logger.Error("Направление -" + r1);
            }

            if (r2 == 0)
            {
                logger.Error("Move to Top");
                if (x > 0 && x <= 19 && y >= 0 && y <= 19)
                {
                    x -= 1; logger.Error("x= " + x);
                    logger.Error("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Error("not wall");
                        if (LifeAfterGhost2 == 1)
                        {
                            table[x+1, y] = value.Eat;
                            LifeAfterGhost2 = 0;
                            logger.Error("table[{0}, {1}] = value.Eat", x + 1, y);
                            logger.Error("LifeAfterGhost2 == 0");
                        }
                        else
                        {
                            table[x + 1, y] = value.Normal;
                            
                            logger.Error("table[{0}, {1}] = value.Normal", x + 1, y);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost2 = 1; logger.Error(" LifeAfterGhost2 = 1");
                        }
                        

                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                        logger.Error(" table[{0}, {1}]= value.Ghost", x, y);
                    }
                    else
                    {
                        r2 = rndGhost.Next(temp);
                    }
                }
            }//Move to Top
            else
            if (r2 == 1)
            {
                logger.Error("Move to Left");
                if (x >= 0 && x <= 19 && y > 0 && y <= 19)
                {
                    y -= 1; logger.Error("x= " + x);
                    logger.Error("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Error("not wall");
                        if (LifeAfterGhost2 == 1)
                        {
                            table[x, y+1] = value.Eat;
                            LifeAfterGhost2 = 0;
                            logger.Error("table[{0}, {1}] = value.Eat", x, y + 1);
                            logger.Error("LifeAfterGhost2 == 0");
                        }
                        else
                        {
                            table[x, y + 1] = value.Normal;
                            logger.Error("table[{0}, {1}] = value.Normal", x, y + 1);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost2 = 1;
                            logger.Error(" LifeAfterGhost2 = 1");


                        }
                        
                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                        logger.Error(" table[{0}, {1}]= value.Ghost", x, y);
                    }
                    else
                    {
                        r2 = rndGhost.Next(temp);
                    }
                }
            }//Move to left
            else
            if (r2 == 2)//Move to Bot
            {
                logger.Error("Move to Bot");
                if (x >= 0 && x < 19 && y >= 0 && y <= 19)
                {
                    x += 1; logger.Error("x= " + x);
                    logger.Error("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Error("not wall");
                        if (LifeAfterGhost2 == 1)
                        {
                            table[x-1, y] = value.Eat;
                            LifeAfterGhost2 = 0;
                            logger.Error("table[{0}, {1}] = value.Eat", x-1, y );
                            logger.Error("LifeAfterGhost2 == 0");
                        }
                        else
                        {
                            table[x - 1, y] = value.Normal;
                            logger.Error("table[{0}, {1}] = value.Normal", x-1, y );
                            
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost2 = 1;
                        }
                        
                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                        logger.Error(" table[{0}, {1}]= value.Ghost", x, y);
                    }
                    else
                    {
                        r2 = rndGhost.Next(temp);
                    }
                }
            } //Move to Bot
            else
            if (r2 == 3)
            {
                logger.Error("Move to Right");
                if (x >= 0 && x <= 19 && y >= 0 && y < 19)
                {
                    y += 1; logger.Error("x= " + x);
                    logger.Error("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Error("not wall");
                        if (LifeAfterGhost2 == 1)
                        {
                            table[x, y-1] = value.Eat;
                            LifeAfterGhost2 = 0;
                            logger.Error("table[{0}, {1}] = value.Eat", x, y-1);
                            logger.Error("LifeAfterGhost2 == 0");
                        }
                        else
                        {
                            table[x, y - 1] = value.Normal;
                            logger.Error("table[{0}, {1}] = value.Normal", x, y - 1);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost2 = 1;
                            logger.Error("LifeAfterGhost2 == 1");
                        }
                        
                        table[x, y] = value.Ghost;
                        GhostsPlases[1, 0] = x;
                        GhostsPlases[1, 1] = y;
                        logger.Error(" table[{0}, {1}]= value.Ghost", x, y);
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
            if (x == 0)
            {
                do
                {
                    r3 = rndGhost.Next(temp);
                } while (r3 == 0);
                LifeAfterGhost3 = 0; logger.Warn("Направление -" + r1);
            }
            else
             if (y == 0)
            {
                do
                {
                    r3 = rndGhost.Next(temp);
                } while (r3 == 1);
                LifeAfterGhost3 = 0; logger.Warn("Направление -" + r1);
            }
            else
             if (x == 19)
            {
                do
                {
                    r3 = rndGhost.Next(temp);
                } while (r3 == 2);
                LifeAfterGhost3 = 0; logger.Warn("Направление -" + r1);
            }
            else
             if (y == 19)
            {
                do
                {
                    r3 = rndGhost.Next(temp);
                } while (r3 == 3);
                LifeAfterGhost3 = 0; logger.Warn("Направление -" + r1);
            }

            if (r3 == 0)//Move to Top
            {
                logger.Warn("Move to Top");
                if (x > 0 && x <= 19 && y >= 0 && y <= 19)
                {
                    x -= 1;
                    logger.Warn("x= " + x);
                    logger.Warn("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Warn("not wall");
                        if (LifeAfterGhost3 == 1)
                        {
                            table[x + 1, y] = value.Eat;
                            LifeAfterGhost3 = 0;
                            logger.Warn("table[{0}, {1}] = value.Eat", x + 1, y);
                            logger.Warn("LifeAfterGhost3 == 0");
                        }
                        else
                        {
                            table[x + 1, y] = value.Normal; logger.Warn("table[{0}, {1}] = value.Normal", x + 1, y);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost3 = 1; logger.Warn(" LifeAfterGhost3 = 1");
                        }


                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                        logger.Warn(" table[{0}, {1}]= value.Ghost", x, y);
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }//Move to Top
            else
            if (r3 == 1)
            {
                logger.Warn("Move to Left");
                if (x >= 0 && x <= 19 && y >0 && y <= 19)
                {
                    y -= 1;
                    logger.Warn("x= " + x);
                    logger.Warn("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Warn("not wall");
                        if (LifeAfterGhost3 == 1)
                        {
                            table[x, y + 1] = value.Eat;
                            LifeAfterGhost3 = 0;
                            logger.Warn("table[{0}, {1}] = value.Eat", x, y + 1);
                            logger.Warn("LifeAfterGhost3 == 0");
                        }
                        else
                        {
                            table[x, y + 1] = value.Normal;
                            logger.Warn("table[{0}, {1}] = value.Normal", x, y + 1);

                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost3 = 1; logger.Warn(" LifeAfterGhost3 = 1");
                        }

                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                        logger.Warn(" table[{0}, {1}]= value.Ghost", x, y);
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }//Move to left
            else
            if (r3 == 2)
            {
                logger.Warn("Move to Right");
                if (x >= 0 && x < 19 && y >= 0 && y <= 19)
                {
                    x += 1;
                    logger.Warn("x= " + x);
                    logger.Warn("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Warn("not wall");
                        if (LifeAfterGhost3 == 1)
                        {
                            table[x - 1, y] = value.Eat;
                            LifeAfterGhost3 = 0;
                            logger.Warn("table[{0}, {1}] = value.Eat", x-1, y);
                            logger.Warn("LifeAfterGhost3 == 0");
                        }
                        else
                        {
                            table[x - 1, y] = value.Normal; logger.Warn("table[{0}, {1}] = value.Normal", x-1, y );
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost3 = 1; logger.Warn(" LifeAfterGhost3 = 1");
                        }

                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                        logger.Warn(" table[{0}, {1}]= value.Ghost", x, y);
                    }
                    else
                    {
                        r3 = rndGhost.Next(temp);
                    }
                }
            }//Move to Bot
            else
            if (r3 == 3)
            {
                logger.Warn("Move to Right");
                if (x >= 0 && x <= 19 && y >= 0 && y < 19)
                {
                    y += 1;
                    logger.Warn("x= " + x);
                    logger.Warn("y= " + y);
                    if (table[x, y] != value.Wall)
                    {
                        logger.Warn("not wall");
                        if (LifeAfterGhost3 == 1)
                        {
                            table[x, y - 1] = value.Eat;
                            LifeAfterGhost3 = 0;
                            logger.Warn("table[{0}, {1}] = value.Eat", x, y + 1);
                            logger.Warn("LifeAfterGhost3 == 0");
                        }
                        else
                        {
                            table[x, y - 1] = value.Normal; logger.Warn("table[{0}, {1}] = value.Normal", x, y + 1);
                        }
                        if (table[x, y] == value.Eat)
                        {
                            LifeAfterGhost3 = 1; logger.Warn(" LifeAfterGhost3 = 1");
                        }

                        table[x, y] = value.Ghost;
                        GhostsPlases[2, 0] = x;
                        GhostsPlases[2, 1] = y;
                        logger.Warn(" table[{0}, {1}]= value.Ghost", x, y);
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
        public static void DrawWall(int[,] table)
        {
            Sell value = new Sell();
            Random r1 = new Random();
            int a = 0;
            int b = 0;
            int[,] TryMestake = new int[3, 3];
            int count = 0;
            int remake = 0;
            while (true)
            {
                
                for (int i = 0; i < 75; i++)
                {
                    a = r1.Next(20);

                    b = r1.Next(20);

                    table[a, b] = value.Wall;
                }
                for (int i = 0; i < table.GetLength(0)-1; i++)
                {
                    for (int j = 0; j < table.GetLength(1)-1; j++)
                    {
                        if (i!=0 && j!=0 && i != table.Length - 1 && j != table.Length - 1)
                        {
                            count = 0;
                            for (int k = 0; k < 3; k++)
                            {
                                for (int h = 0; h < 3; h++)
                                {                                                                     
                                    if (table[k, h] == value.Wall)
                                    {
                                        count++;
                                    }
                                    if (count == 9)
                                    {
                                        remake = remake + 1;
                                        continue;
                                    }
                                    
                                }
                            }
                        }
                    }
                }
                if (remake == 0)
                {
                    break;
                  
                }
                else
                {
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.GetLength(1); j++)
                        {
                            table[i, j] = 0;
                        }
                    }
                }
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
           
       logger.Info("E boy");
            Sell value = new Sell();
            Random r1 = new Random();
            int a = 0;
            int b = 0;

            DrawWall(table);


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
                for (int u = 0; u < table.GetLength(0); u++)
                {
                    if (table[u,0]!=value.Wall)
                    {
                        PacmanX = u;
                        PacmanY = 0;
                        break;
                    }
                }
            }
            button1.Enabled = false;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var handle = this.Handle;
            DrawTable(table, handle);
            Ghost1Move();
            Ghost2Move();
            Ghost3Move();
            

                //table = Move(pressedKey, table, ref X, ref Y);
                if (colvoOfEat == 0)
                {
                    Console.WriteLine("Congratulations");
                    return;
                }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Move1(e);

        }
    }
}

