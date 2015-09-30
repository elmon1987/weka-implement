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
    /*
     * WEKA IMPLEMENT
     * TODO LIST
     * 
     * Fill missing value of dataset
     * Implement discretize algorithm (equal-width/equal-freq)
     * Implement normalize (min-max/z-score)
     * 
     * Design save and display output
     */
    public partial class Form1 : Form
    {
        private string instances;
        private DataSet dataset = new DataSet();
        private List<int> attIndex = new List<int>();

        public Form1()
        {
            InitializeComponent();
            dataset.Info = new List<Instances>();
            dataset.Data = new List<object[]>();
            I_Table.Columns[0].ValueType = typeof(int);
        }

        #region Tooltips
        private string Parser(object[] data) //Get type of attribute
        {
            double dummy;
            foreach (object o in data)
                if (!double.TryParse((string)o, out dummy) && (string)o != "?") return "Nominal";
                return "Numerical";
        }

        private void reParse(List<object[]> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                double dummy;
                if (dataset.Info[i].Type == "Numerical")
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        double.TryParse((string)data[i][j], out dummy);
                        data[i][j] = dummy;
                    }
                }
            }
        }

        private void DataProcessor(string[] lines)
        {
            string attrib = lines[0];
            
            attrib = attrib.Replace("\"", "");
            
            string[] s_attrib = attrib.Split(',');
            foreach (string tmp in s_attrib)
                dataset.Info.Add(new Instances { Attribute = tmp });

            //Debug
            if (Debug_Chk.Checked)
            {
                this.Text = "Debug Mode";
                string _res = "";
                foreach (Instances tmp in dataset.Info)
                    _res += tmp.Attribute + " ";
                MessageBox.Show(_res, "Attribute Debug");
            }

            object[,] predata = new object[lines.Length - 1, dataset.Info.Count]; //row = lines - attrib line //col = numAttrib
            
            if (Debug_Chk.Checked)
                MessageBox.Show("Row = " + predata.GetLength(0).ToString()
                                + "\n Col = " + predata.GetLength(1).ToString()
                                , "Dimension Debug");

            for (int i = 0; i < predata.GetLength(0); i++)
            {
                string[] line = lines[i+1].Split(','); //split value

                for (int j = 0; j < predata.GetLength(1); j++)
                    predata[i, j] = line[j];
            }

            //Debug
            if (Debug_Chk.Checked)
            {
                string _res = "";
                for (int i = 0; i < predata.GetLength(1); i++)
                    _res += predata[0, i] + " ";
                MessageBox.Show(_res, "First predata Debug");
            }

            //Process predata
            for (int i = 0; i < predata.GetLength(1); i++)
            {
                object[] o_data = new object[predata.GetLength(0)];
                for (int j = 0; j < predata.GetLength(0); j++)
                {
                    o_data[j] = predata[j, i];
                    dataset.Info[i].Type = Parser(o_data);
                }
                dataset.Data.Add(o_data);
            }

            reParse(dataset.Data);

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

            //Debug
            if (Debug_Chk.Checked)
            {
                string _res = "";
                foreach (Instances ins in dataset.Info)
                    _res += "\nAttrib: " + ins.Attribute
                         + "\tType: "  + ins.Type;
                MessageBox.Show(_res, "Info Debug");
            }

            if (Debug_Quit.Checked) Application.Exit();
        }

        private void getTable(DataSet dset)
        {
            for (int i = 1; i <= dset.Info.Count; i++)
            {
                I_Table.Rows.Add(i, false, dset.Info[i - 1].Attribute);
            }
        }
        
        private double getMedian(int index)
        {
            List<double> value = new List<double>();

            foreach (object o in dataset.Data[index])
                //if ((string)o != "?") 
                    value.Add((double)o);

            value = value.OrderBy(numbers => numbers)
                         .ToList();

            int cnt = value.Count;
            double res;

            if (cnt % 2 == 0)
            {
                int mid = cnt / 2;
                res = ((value.ElementAt(mid-1)+value.ElementAt(mid))/2);
            }
            else
            {
                double ele = (double)cnt / 2;
                ele = Math.Round(ele, MidpointRounding.AwayFromZero);
                res = value.ElementAt((int)(ele - 1));
            }
            return res;
        }

        private double getMean(int index)
        {
            List<double> value = new List<double>();

            foreach (object o in dataset.Data[index])
                //if ((string)o != "?") 
                    value.Add((double)o);

            return value.Average();
        }

        private string getMode(int index)
        {
            List<string> value = new List<string>();

            foreach (object o in dataset.Data[index])
                if ((string)o != "?") value.Add((string)o);

            return value.GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key;
        }
        private void Reset()
        {
            F_Data.Clear();
            F_Path.Clear();
            instances = "";
            dataset.Info.Clear();
            dataset.Data.Clear();
            I_Table.Rows.Clear();
        }

        private void debugTable()
        {
            string _res = "";
            foreach (DataGridViewRow chk in I_Table.Rows)
            {
                if ((bool)chk.Cells["Chk"].Value == true)
                {
                    attIndex.Add((int)chk.Cells["No"].Value-1);
                    _res += ((int)chk.Cells["No"].Value - 1).ToString() + " ";
                }
            }
            MessageBox.Show(_res, "Table Debug");
        }
        #endregion

        #region Event
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

                DataProcessor(lines);

                I_Info.PerformClick();
                //DataProcess(lines);
                getTable(dataset);

                if (Debug_Chk.Checked)
                {
                    MessageBox.Show(getMean(0).ToString(), "Mean");
                    MessageBox.Show(getMedian(0).ToString(), "Median");
                    MessageBox.Show(getMode(2).ToString(), "Mode");
                }

                this.Text = "Weka Implement";
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
            string _res = "";
            foreach (Instances ins in dataset.Info)
                _res += "\nAttrib: " + ins.Attribute
                     + "\tType: " + ins.Type;
            _res += "\n\nNumber of attributes: " + dataset.Info.Count
                 + "\n\nNumber of instances: " + dataset.Data[0].Length;
            MessageBox.Show(_res, "Data Info");
        }

        private void Chk_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (I_Table.Columns[e.ColumnIndex].Name == "Chk")
            {
                DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();

                chk = (DataGridViewCheckBoxCell)I_Table.Rows[I_Table.CurrentRow.Index].Cells["Chk"];
                if (chk.Value == null || (bool)chk.Value == true)
                    chk.Value = false;
                else chk.Value = true;
            }
        }

        private void Slt_All_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow chk in I_Table.Rows)
                chk.Cells["Chk"].Value = true;
            if (Debug_Chk.Checked)
            {
                this.Text = "Debug Mode";
                debugTable();
            }
            this.Text = "Weka Implement";
        }

        private void Slt_None_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow chk in I_Table.Rows)
                chk.Cells["Chk"].Value = false;
            if (Debug_Chk.Checked)
            {
                this.Text = "Debug Mode";
                debugTable();
            }
            this.Text = "Weka Implement";
        }

        private void Slt_Invert_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow chk in I_Table.Rows)
                chk.Cells["Chk"].Value = !(bool)chk.Cells["Chk"].Value;
            if (Debug_Chk.Checked)
            {
                this.Text = "Debug Mode";
                debugTable();
            }
            this.Text = "Weka Implement";
        }
        #endregion
        private void D_Width_Click(object sender, EventArgs e)
        {
            if (numBin.Text == "") MessageBox.Show("Nothing to do!", "Notification");
            else
            {
                //TODO
            }
        }

        private void D_Freq_Click(object sender, EventArgs e)
        {
            if (weightBin.Text == "") MessageBox.Show("Nothing to do!", "Notification");
            else
            {
                //TODO
            }
        }

        private void I_Fill_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void N_MinMax_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void N_Zscore_Click(object sender, EventArgs e)
        {
            //TODO
        }

        


    }
}
