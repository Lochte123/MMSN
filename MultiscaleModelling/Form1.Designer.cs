namespace MultiscaleModelling
{
    partial class Form1
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
            this.structureBox = new System.Windows.Forms.PictureBox();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.grainsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.growthButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.label12 = new System.Windows.Forms.Label();
            this.boundariesColorinBbutton = new System.Windows.Forms.Button();
            this.ClearGrainsButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microstructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.structureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grainsUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // structureBox
            // 
            this.structureBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.structureBox.Location = new System.Drawing.Point(12, 51);
            this.structureBox.Name = "structureBox";
            this.structureBox.Size = new System.Drawing.Size(463, 463);
            this.structureBox.TabIndex = 0;
            this.structureBox.TabStop = false;
            this.structureBox.Click += new System.EventHandler(this.structureBox_Click);
            // 
            // widthUpDown
            // 
            this.widthUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.widthUpDown.Location = new System.Drawing.Point(549, 55);
            this.widthUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(81, 20);
            this.widthUpDown.TabIndex = 2;
            this.widthUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // heightUpDown
            // 
            this.heightUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.heightUpDown.Location = new System.Drawing.Point(549, 85);
            this.heightUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightUpDown.Name = "heightUpDown";
            this.heightUpDown.Size = new System.Drawing.Size(81, 20);
            this.heightUpDown.TabIndex = 3;
            this.heightUpDown.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.setButton.Location = new System.Drawing.Point(509, 161);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(123, 51);
            this.setButton.TabIndex = 6;
            this.setButton.Text = "Generuj";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // grainsUpDown
            // 
            this.grainsUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.grainsUpDown.Location = new System.Drawing.Point(549, 121);
            this.grainsUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.grainsUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.grainsUpDown.Name = "grainsUpDown";
            this.grainsUpDown.Size = new System.Drawing.Size(81, 20);
            this.grainsUpDown.TabIndex = 7;
            this.grainsUpDown.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Liczba ziaren";
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.generateButton.Location = new System.Drawing.Point(509, 218);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(123, 51);
            this.generateButton.TabIndex = 9;
            this.generateButton.Text = "Ziarna";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // growthButton
            // 
            this.growthButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.growthButton.Location = new System.Drawing.Point(509, 275);
            this.growthButton.Name = "growthButton";
            this.growthButton.Size = new System.Drawing.Size(123, 51);
            this.growthButton.TabIndex = 10;
            this.growthButton.Text = "Start";
            this.growthButton.UseVisualStyleBackColor = false;
            this.growthButton.Click += new System.EventHandler(this.growthButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(529, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Granica rozmiar";
            // 
            // boundariesColorinBbutton
            // 
            this.boundariesColorinBbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.boundariesColorinBbutton.Location = new System.Drawing.Point(509, 385);
            this.boundariesColorinBbutton.Name = "boundariesColorinBbutton";
            this.boundariesColorinBbutton.Size = new System.Drawing.Size(123, 48);
            this.boundariesColorinBbutton.TabIndex = 32;
            this.boundariesColorinBbutton.Text = "Granice";
            this.boundariesColorinBbutton.UseVisualStyleBackColor = false;
            this.boundariesColorinBbutton.Click += new System.EventHandler(this.boundariesColoringButton_Click);
            // 
            // ClearGrainsButton
            // 
            this.ClearGrainsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClearGrainsButton.Location = new System.Drawing.Point(509, 439);
            this.ClearGrainsButton.Name = "ClearGrainsButton";
            this.ClearGrainsButton.Size = new System.Drawing.Size(123, 49);
            this.ClearGrainsButton.TabIndex = 33;
            this.ClearGrainsButton.Text = "Czyść";
            this.ClearGrainsButton.UseVisualStyleBackColor = false;
            this.ClearGrainsButton.Click += new System.EventHandler(this.ClearGrainsButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(659, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.microstructureToolStripMenuItem,
            this.bitmapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 22);
            this.fileToolStripMenuItem.Text = "Plik";
            // 
            // microstructureToolStripMenuItem
            // 
            this.microstructureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.microstructureToolStripMenuItem.Name = "microstructureToolStripMenuItem";
            this.microstructureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.microstructureToolStripMenuItem.Text = "TXT";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // bitmapToolStripMenuItem
            // 
            this.bitmapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePictureToolStripMenuItem,
            this.importToolStripMenuItem1});
            this.bitmapToolStripMenuItem.Name = "bitmapToolStripMenuItem";
            this.bitmapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bitmapToolStripMenuItem.Text = "Bitmap";
            // 
            // savePictureToolStripMenuItem
            // 
            this.savePictureToolStripMenuItem.Name = "savePictureToolStripMenuItem";
            this.savePictureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.savePictureToolStripMenuItem.Text = "Export";
            this.savePictureToolStripMenuItem.Click += new System.EventHandler(this.savePictureToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.importToolStripMenuItem1.Text = "Import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(539, 494);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 39;
            this.textBox1.Text = "Moore";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(521, 359);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(659, 526);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ClearGrainsButton);
            this.Controls.Add(this.boundariesColorinBbutton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.growthButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grainsUpDown);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heightUpDown);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.structureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.structureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grainsUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.NumericUpDown heightUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.NumericUpDown grainsUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button growthButton;
        public System.Windows.Forms.PictureBox structureBox;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button boundariesColorinBbutton;
        private System.Windows.Forms.Button ClearGrainsButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microstructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

