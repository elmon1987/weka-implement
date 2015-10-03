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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.F_Path = new System.Windows.Forms.TextBox();
            this.F_Load = new System.Windows.Forms.Button();
            this.F_Save = new System.Windows.Forms.Button();
            this.F_Data = new System.Windows.Forms.TextBox();
            this.Debug_Chk = new System.Windows.Forms.CheckBox();
            this.I_Info = new System.Windows.Forms.Button();
            this.Debug_Quit = new System.Windows.Forms.CheckBox();
            this.I_Table = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attrib_Panel = new System.Windows.Forms.Panel();
            this.Slt_Invert = new System.Windows.Forms.Button();
            this.Slt_None = new System.Windows.Forms.Button();
            this.Slt_All = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.I_Fill = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.weightBin = new System.Windows.Forms.TextBox();
            this.numBin = new System.Windows.Forms.TextBox();
            this.D_Freq = new System.Windows.Forms.Button();
            this.D_Width = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.N_Zscore = new System.Windows.Forms.Button();
            this.N_MinMax = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numAttrib = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.numSample = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.I_Table)).BeginInit();
            this.Attrib_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // F_Path
            // 
            this.F_Path.Location = new System.Drawing.Point(13, 13);
            this.F_Path.Name = "F_Path";
            this.F_Path.ReadOnly = true;
            this.F_Path.Size = new System.Drawing.Size(568, 20);
            this.F_Path.TabIndex = 0;
            // 
            // F_Load
            // 
            this.F_Load.Location = new System.Drawing.Point(587, 12);
            this.F_Load.Name = "F_Load";
            this.F_Load.Size = new System.Drawing.Size(59, 21);
            this.F_Load.TabIndex = 1;
            this.F_Load.Text = "Load";
            this.F_Load.UseVisualStyleBackColor = true;
            this.F_Load.Click += new System.EventHandler(this.F_Load_Click);
            // 
            // F_Save
            // 
            this.F_Save.Location = new System.Drawing.Point(652, 12);
            this.F_Save.Name = "F_Save";
            this.F_Save.Size = new System.Drawing.Size(59, 21);
            this.F_Save.TabIndex = 2;
            this.F_Save.Text = "Save";
            this.F_Save.UseVisualStyleBackColor = true;
            this.F_Save.Click += new System.EventHandler(this.F_Save_Click);
            // 
            // F_Data
            // 
            this.F_Data.Location = new System.Drawing.Point(13, 271);
            this.F_Data.Multiline = true;
            this.F_Data.Name = "F_Data";
            this.F_Data.ReadOnly = true;
            this.F_Data.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.F_Data.Size = new System.Drawing.Size(481, 278);
            this.F_Data.TabIndex = 3;
            this.F_Data.WordWrap = false;
            // 
            // Debug_Chk
            // 
            this.Debug_Chk.AutoSize = true;
            this.Debug_Chk.Location = new System.Drawing.Point(573, 44);
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
            this.Debug_Quit.Location = new System.Drawing.Point(638, 44);
            this.Debug_Quit.Name = "Debug_Quit";
            this.Debug_Quit.Size = new System.Drawing.Size(73, 17);
            this.Debug_Quit.TabIndex = 6;
            this.Debug_Quit.Text = "Terminate";
            this.Debug_Quit.UseVisualStyleBackColor = true;
            // 
            // I_Table
            // 
            this.I_Table.AllowUserToAddRows = false;
            this.I_Table.AllowUserToDeleteRows = false;
            this.I_Table.AllowUserToResizeRows = false;
            this.I_Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.I_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.I_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Chk,
            this.Attribute,
            this.Type});
            this.I_Table.Location = new System.Drawing.Point(3, 48);
            this.I_Table.Name = "I_Table";
            this.I_Table.RowHeadersVisible = false;
            this.I_Table.RowTemplate.ReadOnly = true;
            this.I_Table.Size = new System.Drawing.Size(467, 144);
            this.I_Table.TabIndex = 7;
            this.I_Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Chk_Click);
            // 
            // No
            // 
            this.No.FillWeight = 42.2723F;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // Chk
            // 
            this.Chk.FillWeight = 30.45686F;
            this.Chk.HeaderText = "";
            this.Chk.Name = "Chk";
            this.Chk.ReadOnly = true;
            // 
            // Attribute
            // 
            this.Attribute.FillWeight = 227.2709F;
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Attrib_Panel
            // 
            this.Attrib_Panel.AccessibleName = "";
            this.Attrib_Panel.Controls.Add(this.Slt_Invert);
            this.Attrib_Panel.Controls.Add(this.Slt_None);
            this.Attrib_Panel.Controls.Add(this.Slt_All);
            this.Attrib_Panel.Controls.Add(this.label1);
            this.Attrib_Panel.Controls.Add(this.I_Table);
            this.Attrib_Panel.Location = new System.Drawing.Point(13, 69);
            this.Attrib_Panel.Name = "Attrib_Panel";
            this.Attrib_Panel.Size = new System.Drawing.Size(473, 196);
            this.Attrib_Panel.TabIndex = 8;
            // 
            // Slt_Invert
            // 
            this.Slt_Invert.Location = new System.Drawing.Point(136, 17);
            this.Slt_Invert.Name = "Slt_Invert";
            this.Slt_Invert.Size = new System.Drawing.Size(60, 25);
            this.Slt_Invert.TabIndex = 11;
            this.Slt_Invert.Text = "Invert";
            this.Slt_Invert.UseVisualStyleBackColor = true;
            this.Slt_Invert.Click += new System.EventHandler(this.Slt_Invert_Click);
            // 
            // Slt_None
            // 
            this.Slt_None.Location = new System.Drawing.Point(70, 17);
            this.Slt_None.Name = "Slt_None";
            this.Slt_None.Size = new System.Drawing.Size(60, 25);
            this.Slt_None.TabIndex = 10;
            this.Slt_None.Text = "None";
            this.Slt_None.UseVisualStyleBackColor = true;
            this.Slt_None.Click += new System.EventHandler(this.Slt_None_Click);
            // 
            // Slt_All
            // 
            this.Slt_All.Location = new System.Drawing.Point(4, 17);
            this.Slt_All.Name = "Slt_All";
            this.Slt_All.Size = new System.Drawing.Size(60, 25);
            this.Slt_All.TabIndex = 9;
            this.Slt_All.Text = "All";
            this.Slt_All.UseVisualStyleBackColor = true;
            this.Slt_All.Click += new System.EventHandler(this.Slt_All_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select";
            // 
            // I_Fill
            // 
            this.I_Fill.Location = new System.Drawing.Point(94, 40);
            this.I_Fill.Name = "I_Fill";
            this.I_Fill.Size = new System.Drawing.Size(75, 23);
            this.I_Fill.TabIndex = 9;
            this.I_Fill.Text = "Fill Value";
            this.I_Fill.UseVisualStyleBackColor = true;
            this.I_Fill.Click += new System.EventHandler(this.I_Fill_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.weightBin);
            this.panel1.Controls.Add(this.numBin);
            this.panel1.Controls.Add(this.D_Freq);
            this.panel1.Controls.Add(this.D_Width);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(500, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 93);
            this.panel1.TabIndex = 10;
            // 
            // weightBin
            // 
            this.weightBin.Location = new System.Drawing.Point(109, 50);
            this.weightBin.Name = "weightBin";
            this.weightBin.Size = new System.Drawing.Size(97, 20);
            this.weightBin.TabIndex = 4;
            // 
            // numBin
            // 
            this.numBin.Location = new System.Drawing.Point(109, 19);
            this.numBin.Name = "numBin";
            this.numBin.Size = new System.Drawing.Size(97, 20);
            this.numBin.TabIndex = 3;
            // 
            // D_Freq
            // 
            this.D_Freq.Location = new System.Drawing.Point(6, 48);
            this.D_Freq.Name = "D_Freq";
            this.D_Freq.Size = new System.Drawing.Size(97, 23);
            this.D_Freq.TabIndex = 2;
            this.D_Freq.Text = "Equal-frequency";
            this.D_Freq.UseVisualStyleBackColor = true;
            this.D_Freq.Click += new System.EventHandler(this.D_Freq_Click);
            // 
            // D_Width
            // 
            this.D_Width.Location = new System.Drawing.Point(6, 17);
            this.D_Width.Name = "D_Width";
            this.D_Width.Size = new System.Drawing.Size(97, 23);
            this.D_Width.TabIndex = 1;
            this.D_Width.Text = "Equal-width";
            this.D_Width.UseVisualStyleBackColor = true;
            this.D_Width.Click += new System.EventHandler(this.D_Width_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Discretize";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.N_Zscore);
            this.panel2.Controls.Add(this.N_MinMax);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(500, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 97);
            this.panel2.TabIndex = 11;
            // 
            // N_Zscore
            // 
            this.N_Zscore.Location = new System.Drawing.Point(109, 29);
            this.N_Zscore.Name = "N_Zscore";
            this.N_Zscore.Size = new System.Drawing.Size(97, 47);
            this.N_Zscore.TabIndex = 2;
            this.N_Zscore.Text = "Z-score";
            this.N_Zscore.UseVisualStyleBackColor = true;
            this.N_Zscore.Click += new System.EventHandler(this.N_Zscore_Click);
            // 
            // N_MinMax
            // 
            this.N_MinMax.Location = new System.Drawing.Point(6, 29);
            this.N_MinMax.Name = "N_MinMax";
            this.N_MinMax.Size = new System.Drawing.Size(97, 47);
            this.N_MinMax.TabIndex = 1;
            this.N_MinMax.Text = "Min-max";
            this.N_MinMax.UseVisualStyleBackColor = true;
            this.N_MinMax.Click += new System.EventHandler(this.N_MinMax_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Normalize";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.numAttrib);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(188, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 23);
            this.panel4.TabIndex = 13;
            // 
            // numAttrib
            // 
            this.numAttrib.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numAttrib.Location = new System.Drawing.Point(55, 5);
            this.numAttrib.Name = "numAttrib";
            this.numAttrib.ReadOnly = true;
            this.numAttrib.Size = new System.Drawing.Size(115, 13);
            this.numAttrib.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Attribute";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.numSample);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(391, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(176, 23);
            this.panel5.TabIndex = 14;
            // 
            // numSample
            // 
            this.numSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSample.Location = new System.Drawing.Point(56, 5);
            this.numSample.Name = "numSample";
            this.numSample.ReadOnly = true;
            this.numSample.Size = new System.Drawing.Size(115, 13);
            this.numSample.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sample";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 561);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.I_Fill);
            this.Controls.Add(this.Attrib_Panel);
            this.Controls.Add(this.Debug_Quit);
            this.Controls.Add(this.I_Info);
            this.Controls.Add(this.Debug_Chk);
            this.Controls.Add(this.F_Data);
            this.Controls.Add(this.F_Save);
            this.Controls.Add(this.F_Load);
            this.Controls.Add(this.F_Path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Weka Implement";
            ((System.ComponentModel.ISupportInitialize)(this.I_Table)).EndInit();
            this.Attrib_Panel.ResumeLayout(false);
            this.Attrib_Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.DataGridView I_Table;
        private System.Windows.Forms.Panel Attrib_Panel;
        private System.Windows.Forms.Button Slt_Invert;
        private System.Windows.Forms.Button Slt_None;
        private System.Windows.Forms.Button Slt_All;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button I_Fill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox weightBin;
        private System.Windows.Forms.TextBox numBin;
        private System.Windows.Forms.Button D_Freq;
        private System.Windows.Forms.Button D_Width;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button N_MinMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button N_Zscore;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox numAttrib;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox numSample;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
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
    public class BinData
    {
        public double First  { get; set; }
        public double Last { get; set; }
        public string AverageValue { get; set; }
    }
}

