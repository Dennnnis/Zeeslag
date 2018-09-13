using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeeslag
{
    public partial class Designer : Form
    {
        //Selection location
        public int selectionX = 0;
        public int selectionY = 0;

        //Selection stuff
        public bool selectionRight = false;
        public bool selectionReady = false;
        public bool selectionGood  = false;
        public ShipCode selectionShip;

        //Counters
        private const int ConstVliegdekschipCount    = 1;
        private const int ConstSlagschipCount        = 0;
        private const int ConstTorpedobootjagerCount = 0;
        private const int ConstPatrouilleschipCount  = 0;

        private int vliegdekschipCount    = ConstVliegdekschipCount;
        private int slagschipCount        = ConstSlagschipCount;
        private int TorpedobootjagerCount = ConstTorpedobootjagerCount;
        private int PatrouilleschipCount  = ConstPatrouilleschipCount;

        //Grid
        public int gridW = 10;
        public int gridH = 10;
        public int cellW;
        public int cellH;
        public Cell[,] grid = new Cell[10, 10];
        public PictureBox[,] visualGrid = new PictureBox[10, 10];

        //Other
        public int boatNumber = 0;

        public Designer()
        {
            InitializeComponent();

            cellW = panel.Width / gridW;
            cellH = panel.Height / gridH;

            for (int y = 0; y < gridH; y++)
            {
                for (int x = 0; x < gridW; x++)
                {
                    visualGrid[x, y] = new PictureBox();
                    visualGrid[x, y].Size = new Size(cellW, cellH);
                    visualGrid[x, y].Location = new Point(x * cellW, y * cellH);
                    visualGrid[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    visualGrid[x, y].BackColor = Color.Transparent;
                    grid[x, y] = new Cell();

                    panel.Controls.Add(visualGrid[x, y]);
                }
            }

            Grid.Draw(visualGrid, grid);
            UpdateLabels();
        }

        private void ResetGrid()
        {
            for (int y = 0; y < gridH; y++)
            {
                for (int x = 0; x < gridW; x++)
                {
                    grid[x, y] = new Cell();
                }
            }
        }

        private void MoveUpdate()
        {
            if (selectionReady)
            {
                selectionGood = true;
                Grid.Draw(visualGrid, grid);
                if (!Grid.CheckSelection(visualGrid,grid, selectionX, selectionY, selectionRight, selectionShip)) selectionGood = false;
                Grid.DrawSelection(visualGrid, selectionX, selectionY, selectionRight, selectionShip, selectionGood);
            }
        }

        private void UpdateLabels()
        {
            label1.Text = vliegdekschipCount.ToString();
            label2.Text = slagschipCount.ToString();
            label3.Text = TorpedobootjagerCount.ToString();
            label4.Text = PatrouilleschipCount.ToString();
        }

        private void Lock(bool locked)
        {
            buttonV.Enabled = !locked;
            buttonS.Enabled = !locked;
            buttonT.Enabled = !locked;
            buttonP.Enabled = !locked;
        }

        
        private void MoveUp_Click(object sender, EventArgs e)   {selectionY--; MoveUpdate(); }   //Moved up
        private void MoveRight_Click(object sender, EventArgs e){selectionX++; MoveUpdate(); } //Moved right
        private void MoveDown_Click(object sender, EventArgs e) {selectionY++;MoveUpdate(); }   //Moved down
        private void MoveLeft_Click(object sender, EventArgs e) {selectionX--;MoveUpdate(); }   //Moved left
        private void Rotate_Click(object sender, EventArgs e)   {selectionRight = !selectionRight; MoveUpdate();} //Spin

        private void Reset_Click(object sender, EventArgs e) //Reset
        {
            selectionX = 0;
            selectionY = 0;
            selectionRight = true;
            MoveUpdate();
        }

        private void Place_Click(object sender, EventArgs e) //Place
        {
            if (selectionGood && selectionReady)
            {
                boatNumber++;

                //Subtract numbers
                switch(selectionShip)
                {
                    case ShipCode.Patrouilleschip: PatrouilleschipCount--; break;
                    case ShipCode.Vliegdekschip: vliegdekschipCount--; break;
                    case ShipCode.Torpedobootjager: TorpedobootjagerCount--; break;
                    case ShipCode.Slagschip: slagschipCount--; break;
                }

                UpdateLabels();

                Grid.PlaceBoat(grid, selectionX, selectionY, selectionRight, boatNumber, selectionShip);

                Lock(false);
                selectionReady = false;

                Grid.Draw(visualGrid, grid);
            }
        }

        private void Boat_Selected(object sender, EventArgs e)
        {
            Button select = sender as Button;
            Reset_Click(this, EventArgs.Empty);

            switch (select.Text)
            {
                case "Vliegdekschip":
                    if (vliegdekschipCount == 0) { return; }
                    selectionShip = ShipCode.Vliegdekschip; 
                    break;
                case "Slagschip":
                    if (slagschipCount == 0) { return; }
                    selectionShip = ShipCode.Slagschip; 
                    break;
                case "Torpedobootjager":
                    if (TorpedobootjagerCount == 0) { return; }
                    selectionShip = ShipCode.Torpedobootjager; 
                    break;
                case "Patrouilleschip":
                    if (PatrouilleschipCount == 0) { return; }
                    selectionShip = ShipCode.Patrouilleschip;
                    break;
                default: throw new Exception("Unknown boat name");
            }

            Reset_Click(this, EventArgs.Empty);
            Lock(true);
            selectionReady = true;
            MoveUpdate();
        }

        private void ResetBoard_Click(object sender, EventArgs e)
        {
            Lock(false);

            vliegdekschipCount = ConstVliegdekschipCount;
            slagschipCount = ConstSlagschipCount;
            TorpedobootjagerCount = ConstTorpedobootjagerCount;
            PatrouilleschipCount = ConstPatrouilleschipCount;

            selectionReady = false;
            ResetGrid();
            UpdateLabels();

            Grid.Draw(visualGrid, grid);
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            if (vliegdekschipCount == 0 && slagschipCount == 0 && TorpedobootjagerCount == 0 && PatrouilleschipCount == 0)
            {
                try
                {
                    using (Board b = new Board(grid))
                    {
                        Hide();
                        b.ShowDialog();
                        Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Geen verbinding met server", "Error");
                    Close();
                }
            }
        }
    }
}
