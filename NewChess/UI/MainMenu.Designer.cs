
namespace UI
{
    partial class MainMenu
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
            this.button_StartBlackVsComputerGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_StartWhiteVsComputerGame = new System.Windows.Forms.Button();
            this.button_StartHumanGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_StartBlackVsComputerGame
            // 
            this.button_StartBlackVsComputerGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_StartBlackVsComputerGame.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StartBlackVsComputerGame.Location = new System.Drawing.Point(0, 211);
            this.button_StartBlackVsComputerGame.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.button_StartBlackVsComputerGame.Name = "button_StartBlackVsComputerGame";
            this.button_StartBlackVsComputerGame.Size = new System.Drawing.Size(284, 50);
            this.button_StartBlackVsComputerGame.TabIndex = 3;
            this.button_StartBlackVsComputerGame.Text = "Play as Black vs Computer";
            this.button_StartBlackVsComputerGame.UseVisualStyleBackColor = true;
            this.button_StartBlackVsComputerGame.Click += new System.EventHandler(this.Button_StartBlackVsComputerGame_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 50);
            this.label1.TabIndex = 100;
            this.label1.Text = "Welcome to to Ash\'s Chess Program. Have fun!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_StartWhiteVsComputerGame
            // 
            this.button_StartWhiteVsComputerGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_StartWhiteVsComputerGame.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StartWhiteVsComputerGame.Location = new System.Drawing.Point(0, 161);
            this.button_StartWhiteVsComputerGame.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.button_StartWhiteVsComputerGame.Name = "button_StartWhiteVsComputerGame";
            this.button_StartWhiteVsComputerGame.Size = new System.Drawing.Size(284, 50);
            this.button_StartWhiteVsComputerGame.TabIndex = 2;
            this.button_StartWhiteVsComputerGame.Text = "Play as White vs Computer";
            this.button_StartWhiteVsComputerGame.UseVisualStyleBackColor = true;
            this.button_StartWhiteVsComputerGame.Click += new System.EventHandler(this.Button_StartWhiteVsComputerGame_Click);
            // 
            // button_StartHumanGame
            // 
            this.button_StartHumanGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_StartHumanGame.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StartHumanGame.Location = new System.Drawing.Point(0, 111);
            this.button_StartHumanGame.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.button_StartHumanGame.Name = "button_StartHumanGame";
            this.button_StartHumanGame.Size = new System.Drawing.Size(284, 50);
            this.button_StartHumanGame.TabIndex = 1;
            this.button_StartHumanGame.Text = "Play Human vs Human";
            this.button_StartHumanGame.UseVisualStyleBackColor = true;
            this.button_StartHumanGame.Click += new System.EventHandler(this.Button_StartHumanGame_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_StartHumanGame);
            this.Controls.Add(this.button_StartWhiteVsComputerGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_StartBlackVsComputerGame);
            this.Name = "MainMenu";
            this.Text = "Welcome";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_StartBlackVsComputerGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_StartWhiteVsComputerGame;
        private System.Windows.Forms.Button button_StartHumanGame;
    }
}