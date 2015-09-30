namespace WekaImplement
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
            this.F_Path = new System.Windows.Forms.TextBox();
            this.F_Load = new System.Windows.Forms.Button();
            this.F_Save = new System.Windows.Forms.Button();
            this.F_Data = new System.Windows.Forms.TextBox();
            this.Debug_Chk = new System.Windows.Forms.CheckBox();
            this.I_Info = new System.Windows.Forms.Button();
            this.Debug_Quit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // F_Path
            // 
            this.F_Path.Location = new System.Drawing.Point(13, 13);
            this.F_Path.Name = "F_Path";
            this.F_Path.ReadOnly = true;
            this.F_Path.Size = new System.Drawing.Size(629, 20);
            this.F_Path.TabIndex = 0;
            // 
            // F_Load
            // 
            this.F_Load.Location = new System.Drawing.Point(648, 13);
            this.F_Load.Name = "F_Load";
            this.F_Load.Size = new System.Drawing.Size(59, 21);
            this.F_Load.TabIndex = 1;
            this.F_Load.Text = "Load";
            this.F_Load.UseVisualStyleBackColor = true;
            this.F_Load.Click += new System.EventHandler(this.F_Load_Click);
            // 
            // F_Save
            // 
            this.F_Save.Location = new System.Drawing.Point(713, 12);
            this.F_Save.Name = "F_Save";
            this.F_Save.Size = new System.Drawing.Size(59, 21);
            this.F_Save.TabIndex = 2;
            this.F_Save.Text = "Save";
            this.F_Save.UseVisualStyleBackColor = true;
            this.F_Save.Click += new System.EventHandler(this.F_Save_Click);
            // 
            // F_Data
            // 
            this.F_Data.Location = new System.Drawing.Point(13, 129);
            this.F_Data.Multiline = true;
            this.F_Data.Name = "F_Data";
            this.F_Data.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.F_Data.Size = new System.Drawing.Size(759, 420);
            this.F_Data.TabIndex = 3;
            this.F_Data.WordWrap = false;
            // 
            // Debug_Chk
            // 
            this.Debug_Chk.AutoSize = true;
            this.Debug_Chk.Location = new System.Drawing.Point(648, 40);
            this.Debug_Chk.Name = "Debug_Chk";
            this.Debug_Chk.Size = new System.Drawing.Size(58, 17);
            this.Debug_Chk.TabIndex = 4;
            this.Debug_Chk.Text = "Debug";
            this.Debug_Chk.UseVisualStyleBackColor = true;
            // 
            // I_Info
            // 
            this.I_Info.Location = new System.Drawing.Point(13, 40);
            this.I_Info.Name = "I_Info";
            this.I_Info.Size = new System.Drawing.Size(75, 23);
            this.I_Info.TabIndex = 5;
            this.I_Info.Text = "Show Info";
            this.I_Info.UseVisualStyleBackColor = true;
            this.I_Info.Click += new System.EventHandler(this.I_Info_Click);
            // 
            // Debug_Quit
            // 
            this.Debug_Quit.AutoSize = true;
            this.Debug_Quit.Location = new System.Drawing.Point(703, 39);
            this.Debug_Quit.Name = "Debug_Quit";
            this.Debug_Quit.Size = new System.Drawing.Size(73, 17);
            this.Debug_Quit.TabIndex = 6;
            this.Debug_Quit.Text = "Terminate";
            this.Debug_Quit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Debug_Quit);
            this.Controls.Add(this.I_Info);
            this.Controls.Add(this.Debug_Chk);
            this.Controls.Add(this.F_Data);
            this.Controls.Add(this.F_Save);
            this.Controls.Add(this.F_Load);
            this.Controls.Add(this.F_Path);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Weka Implement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox F_Path;
        private System.Windows.Forms.Button F_Load;
        private System.Windows.Forms.Button F_Save;
        private System.Windows.Forms.TextBox F_Data;
        private System.Windows.Forms.CheckBox Debug_Chk;
        private System.Windows.Forms.Button I_Info;
        private System.Windows.Forms.CheckBox Debug_Quit;
    }
    public class Instances
    {
        public string Attribute { get; set; }
        public string Type { get; set; }
    }
    public class DataSet
    {
        public System.Collections.Generic.List<Instances> Info { get; set; }
        public System.Collections.Generic.List<object[]> Data { get; set; }
    }
}

