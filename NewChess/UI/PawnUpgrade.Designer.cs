
namespace UI
{
    partial class PawnUpgrade
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
            this.pictureBox_Bishop = new System.Windows.Forms.PictureBox();
            this.pictureBox_Rook = new System.Windows.Forms.PictureBox();
            this.pictureBox_Knight = new System.Windows.Forms.PictureBox();
            this.pictureBox_Queen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Rook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Knight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Queen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Bishop
            // 
            this.pictureBox_Bishop.Location = new System.Drawing.Point(-2, 84);
            this.pictureBox_Bishop.Name = "pictureBox_Bishop";
            this.pictureBox_Bishop.Size = new System.Drawing.Size(126, 78);
            this.pictureBox_Bishop.TabIndex = 2;
            this.pictureBox_Bishop.TabStop = false;
            this.pictureBox_Bishop.Click += new System.EventHandler(this.pictureBox_Bishop_Click);
            // 
            // pictureBox_Rook
            // 
            this.pictureBox_Rook.Location = new System.Drawing.Point(130, 0);
            this.pictureBox_Rook.Name = "pictureBox_Rook";
            this.pictureBox_Rook.Size = new System.Drawing.Size(137, 78);
            this.pictureBox_Rook.TabIndex = 1;
            this.pictureBox_Rook.TabStop = false;
            this.pictureBox_Rook.Click += new System.EventHandler(this.pictureBox_Rook_Click);
            // 
            // pictureBox_Knight
            // 
            this.pictureBox_Knight.Location = new System.Drawing.Point(130, 84);
            this.pictureBox_Knight.Name = "pictureBox_Knight";
            this.pictureBox_Knight.Size = new System.Drawing.Size(137, 78);
            this.pictureBox_Knight.TabIndex = 3;
            this.pictureBox_Knight.TabStop = false;
            this.pictureBox_Knight.Click += new System.EventHandler(this.pictureBox_Knight_Click);
            // 
            // pictureBox_Queen
            // 
            this.pictureBox_Queen.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox_Queen.Name = "pictureBox_Queen";
            this.pictureBox_Queen.Size = new System.Drawing.Size(126, 78);
            this.pictureBox_Queen.TabIndex = 0;
            this.pictureBox_Queen.TabStop = false;
            this.pictureBox_Queen.Click += new System.EventHandler(this.pictureBox_Queen_Click);
            // 
            // PawnUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 162);
            this.Controls.Add(this.pictureBox_Knight);
            this.Controls.Add(this.pictureBox_Bishop);
            this.Controls.Add(this.pictureBox_Rook);
            this.Controls.Add(this.pictureBox_Queen);
            this.Name = "PawnUpgrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PawnUpgrade";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Rook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Knight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Queen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Bishop;
        private System.Windows.Forms.PictureBox pictureBox_Rook;
        private System.Windows.Forms.PictureBox pictureBox_Knight;
        private System.Windows.Forms.PictureBox pictureBox_Queen;
    }
}