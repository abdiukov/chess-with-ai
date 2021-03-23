
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
            this.button_PlayAsWhite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_PlayAsWhite
            // 
            this.button_PlayAsWhite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_PlayAsWhite.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_PlayAsWhite.Location = new System.Drawing.Point(0, 211);
            this.button_PlayAsWhite.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.button_PlayAsWhite.Name = "button_PlayAsWhite";
            this.button_PlayAsWhite.Size = new System.Drawing.Size(284, 50);
            this.button_PlayAsWhite.TabIndex = 1;
            this.button_PlayAsWhite.Text = "Start the game";
            this.button_PlayAsWhite.UseVisualStyleBackColor = true;
            this.button_PlayAsWhite.Click += new System.EventHandler(this.button_PlayAsWhite_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 211);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to to Ash\'s Chess Program. Have fun!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_PlayAsWhite);
            this.Name = "MainMenu";
            this.Text = "Welcome";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_PlayAsWhite;
        private System.Windows.Forms.Label label1;
    }
}