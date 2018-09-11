namespace Zeeslag
{
    partial class Designer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Designer));
            this.buttonV = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.buttonT = new System.Windows.Forms.Button();
            this.buttonP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonGo = new System.Windows.Forms.Button();
            this.Place = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.MoveRight = new System.Windows.Forms.Button();
            this.MoveUp = new System.Windows.Forms.Button();
            this.Rotate = new System.Windows.Forms.Button();
            this.MoveLeft = new System.Windows.Forms.Button();
            this.MoveDown = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.ResetBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonV
            // 
            this.buttonV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonV.ForeColor = System.Drawing.Color.Teal;
            this.buttonV.Location = new System.Drawing.Point(430, 12);
            this.buttonV.Name = "buttonV";
            this.buttonV.Size = new System.Drawing.Size(199, 23);
            this.buttonV.TabIndex = 1;
            this.buttonV.Text = "Vliegdekschip";
            this.buttonV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonV.UseVisualStyleBackColor = true;
            this.buttonV.Click += new System.EventHandler(this.Boat_Selected);
            // 
            // buttonS
            // 
            this.buttonS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonS.ForeColor = System.Drawing.Color.Teal;
            this.buttonS.Location = new System.Drawing.Point(430, 41);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(199, 23);
            this.buttonS.TabIndex = 2;
            this.buttonS.Text = "Slagschip";
            this.buttonS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonS.UseVisualStyleBackColor = true;
            this.buttonS.Click += new System.EventHandler(this.Boat_Selected);
            // 
            // buttonT
            // 
            this.buttonT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonT.ForeColor = System.Drawing.Color.Teal;
            this.buttonT.Location = new System.Drawing.Point(430, 70);
            this.buttonT.Name = "buttonT";
            this.buttonT.Size = new System.Drawing.Size(199, 23);
            this.buttonT.TabIndex = 3;
            this.buttonT.Text = "Torpedobootjager";
            this.buttonT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonT.UseVisualStyleBackColor = true;
            this.buttonT.Click += new System.EventHandler(this.Boat_Selected);
            // 
            // buttonP
            // 
            this.buttonP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonP.ForeColor = System.Drawing.Color.Teal;
            this.buttonP.Location = new System.Drawing.Point(430, 99);
            this.buttonP.Name = "buttonP";
            this.buttonP.Size = new System.Drawing.Size(199, 23);
            this.buttonP.TabIndex = 4;
            this.buttonP.Text = "Patrouilleschip";
            this.buttonP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonP.UseVisualStyleBackColor = true;
            this.buttonP.Click += new System.EventHandler(this.Boat_Selected);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "0";
            // 
            // ButtonGo
            // 
            this.ButtonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGo.ForeColor = System.Drawing.Color.Teal;
            this.ButtonGo.Location = new System.Drawing.Point(580, 389);
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(68, 23);
            this.ButtonGo.TabIndex = 13;
            this.ButtonGo.Text = "Go";
            this.ButtonGo.UseVisualStyleBackColor = true;
            this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // Place
            // 
            this.Place.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Place.BackColor = System.Drawing.Color.White;
            this.Place.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Place.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Place.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Place.ForeColor = System.Drawing.Color.Teal;
            this.Place.Location = new System.Drawing.Point(430, 271);
            this.Place.Name = "Place";
            this.Place.Size = new System.Drawing.Size(108, 32);
            this.Place.TabIndex = 15;
            this.Place.Text = "Plaatsen";
            this.Place.UseVisualStyleBackColor = false;
            this.Place.Click += new System.EventHandler(this.Place_Click);
            // 
            // Reset
            // 
            this.Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset.BackColor = System.Drawing.Color.White;
            this.Reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.ForeColor = System.Drawing.Color.Teal;
            this.Reset.Location = new System.Drawing.Point(468, 195);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(32, 32);
            this.Reset.TabIndex = 16;
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // MoveRight
            // 
            this.MoveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveRight.BackColor = System.Drawing.Color.White;
            this.MoveRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveRight.BackgroundImage")));
            this.MoveRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveRight.ForeColor = System.Drawing.Color.Teal;
            this.MoveRight.Location = new System.Drawing.Point(506, 195);
            this.MoveRight.Name = "MoveRight";
            this.MoveRight.Size = new System.Drawing.Size(32, 32);
            this.MoveRight.TabIndex = 11;
            this.MoveRight.UseVisualStyleBackColor = false;
            this.MoveRight.Click += new System.EventHandler(this.MoveRight_Click);
            // 
            // MoveUp
            // 
            this.MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveUp.BackColor = System.Drawing.Color.White;
            this.MoveUp.BackgroundImage = global::Zeeslag.Properties.Resources.ArrowTop;
            this.MoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveUp.ForeColor = System.Drawing.Color.Teal;
            this.MoveUp.Location = new System.Drawing.Point(468, 157);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(32, 32);
            this.MoveUp.TabIndex = 9;
            this.MoveUp.UseVisualStyleBackColor = false;
            this.MoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // Rotate
            // 
            this.Rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rotate.BackColor = System.Drawing.Color.White;
            this.Rotate.BackgroundImage = global::Zeeslag.Properties.Resources.Rotate;
            this.Rotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Rotate.ForeColor = System.Drawing.Color.Teal;
            this.Rotate.Location = new System.Drawing.Point(506, 233);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(32, 32);
            this.Rotate.TabIndex = 14;
            this.Rotate.UseVisualStyleBackColor = false;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // MoveLeft
            // 
            this.MoveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveLeft.BackColor = System.Drawing.Color.White;
            this.MoveLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveLeft.BackgroundImage")));
            this.MoveLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveLeft.ForeColor = System.Drawing.Color.Teal;
            this.MoveLeft.Location = new System.Drawing.Point(430, 195);
            this.MoveLeft.Name = "MoveLeft";
            this.MoveLeft.Size = new System.Drawing.Size(32, 32);
            this.MoveLeft.TabIndex = 10;
            this.MoveLeft.UseVisualStyleBackColor = false;
            this.MoveLeft.Click += new System.EventHandler(this.MoveLeft_Click);
            // 
            // MoveDown
            // 
            this.MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveDown.BackColor = System.Drawing.Color.White;
            this.MoveDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveDown.BackgroundImage")));
            this.MoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveDown.ForeColor = System.Drawing.Color.Teal;
            this.MoveDown.Location = new System.Drawing.Point(468, 233);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(32, 32);
            this.MoveDown.TabIndex = 12;
            this.MoveDown.UseVisualStyleBackColor = false;
            this.MoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackgroundImage = global::Zeeslag.Properties.Resources.BackgroundField;
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 0;
            // 
            // ResetBoard
            // 
            this.ResetBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBoard.ForeColor = System.Drawing.Color.Teal;
            this.ResetBoard.Location = new System.Drawing.Point(430, 389);
            this.ResetBoard.Name = "ResetBoard";
            this.ResetBoard.Size = new System.Drawing.Size(68, 23);
            this.ResetBoard.TabIndex = 17;
            this.ResetBoard.Text = "Reset";
            this.ResetBoard.UseVisualStyleBackColor = true;
            this.ResetBoard.Click += new System.EventHandler(this.ResetBoard_Click);
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 428);
            this.Controls.Add(this.ResetBoard);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.MoveRight);
            this.Controls.Add(this.Place);
            this.Controls.Add(this.MoveUp);
            this.Controls.Add(this.ButtonGo);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MoveLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MoveDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonP);
            this.Controls.Add(this.buttonT);
            this.Controls.Add(this.buttonS);
            this.Controls.Add(this.buttonV);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Designer";
            this.Text = "ZeeSlag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonV;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.Button buttonT;
        private System.Windows.Forms.Button buttonP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.Button MoveLeft;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button MoveRight;
        private System.Windows.Forms.Button ButtonGo;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.Button Place;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button ResetBoard;
    }
}

