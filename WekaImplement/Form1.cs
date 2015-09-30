using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WekaImplement
{
    public partial class Form1 : Form
    {
        private string instances;
        private DataSet dataset = new DataSet();
        public Form1()
        {
            InitializeComponent();
            dataset.Info = new List<Instances>();
            dataset.Data = new List<object[]>();
        }

        private void DataProcess(string[] lines) //value line
        {
            object[,] predata = new object[lines.Length-1, lines[0].Split(',').Length];

            //Debug
            if (Debug_Chk.Checked)
            {
                MessageBox.Show(predata.GetLength(0).ToString() + " " + predata.GetLength(1).ToString(), "Dimension Debug");
                this.Text = "Debug Mode";
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(','); //split value into string array
                
                double d_tmp;
                
                for (int j = 0; j < line.Length; j++)
                {
                    if (dataset.Info[j].Type == "Numerical")
                    {
                        if (double.TryParse(line[j], out d_tmp))
                            predata[i - 1, j] = d_tmp;
                        else
                            predata[i - 1, j] = "?";
                    }
                    else if (dataset.Info[j].Type == "Nominal")
                        predata[i - 1, j] = line[j];
                }
            }

            //Debug
            if (Debug_Chk.Checked)
            {
                string _res = "";
                for (int i = 0; i < predata.GetLength(0); i++)
                {
                    for (int j = 0; j < predata.GetLength(1); j++)
                    {
                        _res += predata[i, j] + " ";
                    }
                    _res += "\n";
                }
                MessageBox.Show(_res, "Data Debug");
            }

            for (int i = 0; i < predata.GetLength(1); i++) //0=j=2 1=i=12
            {
                object[] o_data = new object[predata.GetLength(0)];
                for (int j = 0; j < predata.GetLength(0); j++)
                {
                    o_data[j] = predata[j, i];
                }
                dataset.Data.Add(o_data);
            }

            //Debug
            if (Debug_Chk.Checked)
            {
                string _res = "";
                foreach (object[] o_data in dataset.Data)
                {
                    foreach (object k in o_data)
                        _res += k.ToString() + " ";
                    _res += "\n";
                }
                MessageBox.Show(_res, "Dataset Data Debug");
            }
            this.Text = "Weka Implement";
        }
        private void Reset()
        {
            F_Data.Clear();
            F_Path.Clear();
            instances = "";
            dataset.Info.Clear();
            dataset.Data.Clear();
        }
        private void F_Load_Click(object sender, EventArgs e)
        {
            Reset();
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "CSV file(*.csv)|*.csv";

            if (open.ShowDialog() == DialogResult.OK)
            {
                F_Path.Text = open.FileName;
                string[] lines = File.ReadAllLines(open.FileName);

                foreach (string line in lines)
                {
                    instances += line + "\r\n"; //save data into instances
                }

                //Debug
                if (Debug_Chk.Checked)
                {
                    F_Data.Text = instances; //test load
                    this.Text = "Debug Mode";
                }
                else this.Text = "Weka Implement";

                I_Info.PerformClick();
                DataProcess(lines);

                MessageBox.Show("Load success!", "Notification"); 
            }          
        }

        private void F_Save_Click(object sender, EventArgs e)
        {
            if (F_Data.Text == "")  MessageBox.Show("Nothing to save!", "Notification");
            else
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "CSV file(*.csv)|*.csv";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, F_Data.Text);
                }

                MessageBox.Show("File saved!", "Notification");

                //Debug
                if (Debug_Chk.Checked) //test save data
                {
                    Reset();
                    this.Text = "Debug Mode";
                    string[] lines = File.ReadAllLines(save.FileName);
                    foreach (string line in lines)
                    {
                        instances += line + "\r\n";
                    }
                    MessageBox.Show(instances);
                }
                else this.Text = "Weka Implement";
            }
        }

        private void I_Info_Click(object sender, EventArgs e)
        {
            if (dataset.Info.Count != 0) dataset.Info.Clear();
            if (instances == "" || F_Path.Text == "") MessageBox.Show("Data not found!", "Notification");
            else
            {
                var data = File.ReadLines(F_Path.Text).Take(2);
                string[] s_tmp = new string[2];

                //Convert var to string[]
                int j = 0;
                {
                    foreach(var s in data)
                    {
                        s_tmp[j] = s.ToString();
                        j++;
                    }
                }

                //Debug
                if (Debug_Chk.Checked)
                {
                    this.Text = "Debug Mode";
                    MessageBox.Show(s_tmp[0] + " " + s_tmp[1],"var Debug");
                }

                string attrib = s_tmp[0];
                string cmpr = s_tmp[1];

                //Debug
                if (Debug_Chk.Checked)
                {
                    MessageBox.Show(attrib + "\n" + cmpr,"attrib + cmpr");
                }

                attrib = attrib.Replace("\"", "");

                string[] s_attrib = attrib.Split(',');
                string[] s_cmpt = cmpr.Split(',');

                string[] s_type = new string[] { "Numerical", "Nominal" };

                attrib = "";
                double _tmp;

                //Process attribute
                for (int i = 0; i < s_attrib.Length; i++)
                {
                    attrib += "Attribute: " + s_attrib[i] + "\tType: ";
                    if (s_cmpt[i] == "?" || double.TryParse(s_cmpt[i], out _tmp))
                    {
                        attrib += s_type[0] + "\n";
                        dataset.Info.Add(new Instances { Attribute = s_attrib[i], Type = s_type[0] });
                    }
                    else
                    {
                        attrib += s_type[1] + "\n";
                        dataset.Info.Add(new Instances { Attribute = s_attrib[i], Type = s_type[1] });
                    }
                }
                MessageBox.Show(attrib,"Attribute Info");

                //Debug
                if (Debug_Chk.Checked)
                {
                    string _res = "";
                    foreach (Instances x in dataset.Info)
                    {
                        _res += x.Attribute + " " + x.Type + "\n";
                    }
                    MessageBox.Show(_res, "Instances Debug");
                }
                this.Text = "Weka Implement";
            }
        }
    }
}
