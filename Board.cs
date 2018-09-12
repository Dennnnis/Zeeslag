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

namespace Zeeslag
{
    public partial class Board : Form
    {
        //Text
        string[] turnText = { "Tegenstander is aan de beurt..", "Jij bent aan de beurt!" };
        Popup pop;

        //Delegates
        delegate void GenericDelegate();
        delegate void ReceiveMoveDelegate(int x, int y);
        delegate void ReceiveMoveInfoDelegate(int x, int y, bool destroyed, Cell c);
        delegate void GameOverDelegate(bool win);

        //Thread
        Thread receivingThread;
        public bool requestThreadClose = false;
        public object threadCloseLock = new object();

        //Rules
        public bool myTurn;
        public bool allowSending = false;

        //Grid stuff
        public int gridW = 10;
        public int gridH = 10;
        public int cellW;
        public int cellH;

        PictureBox[,] enemyVisualGrid;
        PictureBox[,] myVisualGrid;
        Cell[,] enemyGrid;
        Cell[,] myGrid;

        public Board(Cell[,] grid)
        {
            myGrid = grid;
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            myTurn = Connection.amIHost;

            try
            {
                //Tell the other player that we are ready
                Net.SendType(Connection.socket, Type.ready);
            }
            catch(Exception)
            {
                MessageBox.Show("Speler heeft het spel verlaten. ", "Error");
                Close();
            }

            //Create the grids
            enemyVisualGrid = new PictureBox[gridW, gridH];
            myVisualGrid = new PictureBox[gridW, gridH];
            
            enemyGrid = new Cell[gridW, gridH];
            
            cellW = MyPanel.Width / gridW;
            cellH = MyPanel.Height / gridH;
            
            for (int y = 0; y < gridH; y++)
            {
                for (int x = 0; x < gridW; x++)
                {
                    myVisualGrid[x, y] = new PictureBox();
                    enemyVisualGrid[x, y] = new PictureBox();
            
                    myVisualGrid[x, y].Size = new Size(cellW, cellH);
                    myVisualGrid[x, y].Location = new Point(x * cellW, y * cellH);
                    myVisualGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    myVisualGrid[x, y].BackColor = Color.Transparent;
            
                    enemyVisualGrid[x, y].Size = new Size(cellW, cellH);
                    enemyVisualGrid[x, y].Location = new Point(x * cellW, y * cellH);
                    enemyVisualGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    enemyVisualGrid[x, y].BackColor = Color.Transparent;
                    enemyVisualGrid[x, y].Click += ClickedOnEnemyGrid;
            
                    enemyGrid[x, y] = new Cell();
            
                    EnemyPanel.Controls.Add(enemyVisualGrid[x, y]);
                    MyPanel.Controls.Add(myVisualGrid[x, y]);
                }
            }

            //Start reciever thread
            receivingThread = new Thread(new ThreadStart(Receiver));
            receivingThread.Start();

            //Draw grid
            RefreshVisual();

            TurnLabel.Text = "De andere speler is nog niet klaar!";
        }

        public void ShowMessageNonBlocking(string msg)
        {
            pop = new Popup(msg, 4);
            pop.Show();
        }

        public void RefreshVisual()
        {
            Grid.Draw(myVisualGrid, myGrid);
            Grid.Draw(enemyVisualGrid, enemyGrid);

            TurnLabel.Text = turnText[Convert.ToInt32(myTurn)];
        }

        public void ClickedOnEnemyGrid(object sender, EventArgs e)
        {
            if (myTurn && allowSending)
            {
                int x = EnemyPanel.PointToClient(Cursor.Position).X / cellW;
                int y = EnemyPanel.PointToClient(Cursor.Position).Y / cellH;

                if (enemyGrid[x, y].hit || enemyGrid[x, y].missed) return;

                try
                {
                    Net.SendMove(Connection.socket, x, y);
                    myTurn = false;
                    Console.WriteLine($"Send move {x}x{y}");
                    Console.WriteLine("Its not my turn anymore");
                }
                catch(Exception)
                {
                    //TODO add error msg
                    MessageBox.Show("Geen verbinding meer met andere speler!","Error");
                    Close();
                }
                RefreshVisual();
            }
            else
            {
                MessageBox.Show("Jij bent niet aan de beurt!","Dat mag nie");
            }
        }

        //THREAD!!
        public void Receiver()
        {
            try
            {
                //Wait for ready before starting.
                if (Net.ReceiveType(Connection.socket) != Type.ready) { throw new Exception(); }
                Invoke(new GenericDelegate(OnReady));

                while (true)
                {
                    ReceiveOne();

                    Console.WriteLine("-----------------------------------------------------------------------------");

                    lock (threadCloseLock)
                    {
                        if (requestThreadClose)
                        {
                            Console.WriteLine("Thread closed");
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Kan geen berichten ontvangen van andere speler!", "Error");
            }

            Console.WriteLine("Thread has closed"); 
        }

        //THREAD
        public void ReceiveOne()
        {
            Type t = Net.ReceiveType(Connection.socket);

            //Received move
            switch(t)
            {
                case Type.lose:
                    {
                        Console.WriteLine("Received lose");
                        lock (threadCloseLock) requestThreadClose = true;
                        BeginInvoke(new GenericDelegate(OnLose));
                        Console.WriteLine($"ThreadClose state == {requestThreadClose}");
                        return;
                    }


                //Received win
                case Type.win:
                    {
                        Console.WriteLine("Received win");
                        lock (threadCloseLock) requestThreadClose = true;
                        Net.SendType(Connection.socket, Type.lose);
                        BeginInvoke(new GenericDelegate(OnWin));
                        return;
                    }

                //Received move
                case Type.move:
                    {
                        Net.ReceiveMove(Connection.socket, out int x, out int y);
                        Console.WriteLine($"Received move {x}x{y}");
                        Invoke(new ReceiveMoveDelegate(OnReceiveMove), new object[] { x, y });
                        return;
                    }

                //Received moveInfo
                case Type.moveInfo:
                    {
                        Net.ReceiveMoveInfo(Connection.socket, out int x, out int y, out bool destroyed, out Cell c);
                        Invoke(new ReceiveMoveInfoDelegate(OnReceiveMoveInfo), new object[] { x, y, destroyed, c });
                        return;
                    }
            }
            return;
        }

        //Main thread
        void OnReady()
        {
            allowSending = true;
            RefreshVisual();
        }

        //Main thread
        void OnLose()
        {
            OnGameOver(false);
        }

        //Main thread
        void OnWin()
        {
            OnGameOver(true);
        }

        //Main thread
        void OnGameOver(bool win)
        {
            Console.WriteLine("Joining thread");
            receivingThread.Join();
            Console.WriteLine("Thread was joined");

            if (win)
            {
                MessageBox.Show("Je hebt gewonnen!", "Goed gedaan");
            }
            else
            {
                MessageBox.Show("Je hebt verloren :c","Rip");
            }
            Close();
        }

        //Main thread
        void OnReceiveMove(int x,int y)
        {
            Console.WriteLine($"OnReceiveMove({x},{y})");

            bool destroyed = false;

            if (myGrid[x, y].isShip)
            {
                myGrid[x, y].hit = true;
                destroyed = Grid.IsRip(myGrid, x, y);
            }
            else
            {
                myGrid[x, y].missed = true;
            }


            Net.SendMoveInfo(Connection.socket, x, y, destroyed, myGrid[x, y]);
            Console.WriteLine($"Send move info {x}x{y}");

            myTurn = true;
            Console.WriteLine("Its my turn");

            if (Grid.IsGameOver(myGrid))
            {
                myTurn = false;
                Net.SendType(Connection.socket, Type.win);
                return;
            }
            RefreshVisual();
        }

        //Main thread
        void OnReceiveMoveInfo(int x, int y, bool destroyed, Cell c)
        {
            Console.WriteLine($"OnReceiveMoveInfo({x}x{y})");

            enemyGrid[x, y] = c;
            enemyGrid[x, y].hidden = true;

            if (c.hit) Sounds.Hit(); else Sounds.Miss();

            if (destroyed)
            {
                for (int iy = 0; iy < enemyGrid.GetLength(1); iy++)
                {
                    for (int ix = 0; ix < enemyGrid.GetLength(0); ix++)
                    {
                        if (enemyGrid[ix, iy].number == c.number)
                        {
                            enemyGrid[ix, iy].hidden = false;
                        }
                    }
                }
                ShowMessageNonBlocking($"{Cell.GetName(c.shipCode)} van je vijand is gezonken!"); 
            }
            RefreshVisual();
        }
    }
}
