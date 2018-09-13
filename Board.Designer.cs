namespace Zeeslag
{
    partial class Board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.TurnLabel = new System.Windows.Forms.Label();
            this.MyPanel = new System.Windows.Forms.Panel();
            this.EnemyPanel = new System.Windows.Forms.Panel();
            this.RotateSceen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.Location = new System.Drawing.Point(50, 21);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(179, 13);
            this.TurnLabel.TabIndex = 3;
            this.TurnLabel.Text = "Aan het wachten op andere speler...";
            // 
            // MyPanel
            // 
            this.MyPanel.BackgroundImage = global::Zeeslag.Properties.Resources.BackgroundField;
            this.MyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MyPanel.Location = new System.Drawing.Point(12, 458);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(400, 400);
            this.MyPanel.TabIndex = 2;
            // 
            // EnemyPanel
            // 
            this.EnemyPanel.BackgroundImage = global::Zeeslag.Properties.Resources.BackgroundField;
            this.EnemyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnemyPanel.Location = new System.Drawing.Point(12, 49);
            this.EnemyPanel.Name = "EnemyPanel";
            this.EnemyPanel.Size = new System.Drawing.Size(400, 400);
            this.EnemyPanel.TabIndex = 1;
            // 
            // RotateSceen
            // 
            this.RotateSceen.BackgroundImage = global::Zeeslag.Properties.Resources.Rotate;
            this.RotateSceen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RotateSceen.Location = new System.Drawing.Point(12, 12);
            this.RotateSceen.Name = "RotateSceen";
            this.RotateSceen.Size = new System.Drawing.Size(32, 32);
            this.RotateSceen.TabIndex = 4;
            this.RotateSceen.UseVisualStyleBackColor = true;
            this.RotateSceen.Click += new System.EventHandler(this.RotateSceen_Click);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 870);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.RotateSceen);
            this.Controls.Add(this.MyPanel);
            this.Controls.Add(this.EnemyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Board";
            this.Text = "Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosedForm);
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel EnemyPanel;
        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.Label TurnLabel;
        private System.Windows.Forms.Button RotateSceen;
    }
}