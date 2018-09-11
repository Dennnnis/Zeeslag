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
            this.SuspendLayout();
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.Location = new System.Drawing.Point(9, 827);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(179, 13);
            this.TurnLabel.TabIndex = 3;
            this.TurnLabel.Text = "Aan het wachten op andere speler...";
            // 
            // MyPanel
            // 
            this.MyPanel.BackgroundImage = global::Zeeslag.Properties.Resources.BackgroundField;
            this.MyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MyPanel.Location = new System.Drawing.Point(12, 418);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(400, 400);
            this.MyPanel.TabIndex = 2;
            // 
            // EnemyPanel
            // 
            this.EnemyPanel.BackgroundImage = global::Zeeslag.Properties.Resources.BackgroundField;
            this.EnemyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnemyPanel.Location = new System.Drawing.Point(12, 12);
            this.EnemyPanel.Name = "EnemyPanel";
            this.EnemyPanel.Size = new System.Drawing.Size(400, 400);
            this.EnemyPanel.TabIndex = 1;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 849);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.MyPanel);
            this.Controls.Add(this.EnemyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Board";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel EnemyPanel;
        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.Label TurnLabel;
    }
}