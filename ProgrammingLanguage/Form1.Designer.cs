namespace ProgrammingLanguage
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
            this.OutputWindow = new System.Windows.Forms.PictureBox();
            this.ProgramWindow = new System.Windows.Forms.RichTextBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.Btn_Run = new System.Windows.Forms.Button();
            this.Btn_Syntax = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputWindow
            // 
            this.OutputWindow.Location = new System.Drawing.Point(523, 82);
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.Size = new System.Drawing.Size(493, 425);
            this.OutputWindow.TabIndex = 0;
            this.OutputWindow.TabStop = false;
            this.OutputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // ProgramWindow
            // 
            this.ProgramWindow.Location = new System.Drawing.Point(52, 82);
            this.ProgramWindow.Name = "ProgramWindow";
            this.ProgramWindow.Size = new System.Drawing.Size(424, 302);
            this.ProgramWindow.TabIndex = 1;
            this.ProgramWindow.Text = "";
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(52, 485);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(424, 22);
            this.commandLine.TabIndex = 2;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // Btn_Run
            // 
            this.Btn_Run.Location = new System.Drawing.Point(52, 560);
            this.Btn_Run.Name = "Btn_Run";
            this.Btn_Run.Size = new System.Drawing.Size(189, 45);
            this.Btn_Run.TabIndex = 3;
            this.Btn_Run.Text = "Run";
            this.Btn_Run.UseVisualStyleBackColor = true;
            // 
            // Btn_Syntax
            // 
            this.Btn_Syntax.Location = new System.Drawing.Point(270, 560);
            this.Btn_Syntax.Name = "Btn_Syntax";
            this.Btn_Syntax.Size = new System.Drawing.Size(253, 45);
            this.Btn_Syntax.TabIndex = 4;
            this.Btn_Syntax.Text = "Check Syntax";
            this.Btn_Syntax.UseVisualStyleBackColor = true;
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(565, 560);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(207, 44);
            this.Btn_Clear.TabIndex = 5;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(805, 560);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(210, 43);
            this.Btn_Save.TabIndex = 6;
            this.Btn_Save.Text = "Save to Text";
            this.Btn_Save.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 650);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_Syntax);
            this.Controls.Add(this.Btn_Run);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.ProgramWindow);
            this.Controls.Add(this.OutputWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OutputWindow;
        private System.Windows.Forms.RichTextBox ProgramWindow;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Button Btn_Run;
        private System.Windows.Forms.Button Btn_Syntax;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Save;
    }
}

