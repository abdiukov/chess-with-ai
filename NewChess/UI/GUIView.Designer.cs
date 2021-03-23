using System.Windows.Forms;

namespace Chess
{
    partial class GUIView
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
            this.SuspendLayout();
            // 
            // GUIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(140, 1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GUIView";
            this.Text = "Chess Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUIView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
    }
}