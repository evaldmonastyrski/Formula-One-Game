namespace Formula_One_Game
{
    partial class DreamTeamOptionWindow
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
            this.textBoxOptions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxOptions
            // 
            this.textBoxOptions.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOptions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOptions.Location = new System.Drawing.Point(0, 0);
            this.textBoxOptions.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOptions.Multiline = true;
            this.textBoxOptions.Name = "textBoxOptions";
            this.textBoxOptions.ReadOnly = true;
            this.textBoxOptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOptions.Size = new System.Drawing.Size(901, 571);
            this.textBoxOptions.TabIndex = 0;
            this.textBoxOptions.TabStop = false;
            // 
            // DreamTeamOptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 571);
            this.Controls.Add(this.textBoxOptions);
            this.Name = "DreamTeamOptionWindow";
            this.Text = "Available Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOptions;
    }
}