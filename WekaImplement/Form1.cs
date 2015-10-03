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
     * 
     * This is copyrighted to University of Technology in Viet Nam
     * 
     * Student ID: 12520638 - 12520971
     * 
     * Features:
     *  -   Can read .csv file
     *  -   Show info of data file
     *  -   Discretize filters with binning
     *  -   Normalize filters with min-max and z-score type
     *  -   Debug + Terminate mode for developers
     */
    public partial class Form1 : Form
    {
        private string instances;
        private string header;
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

        private void reParse(List<object[]> data) //Parse data into database
        {
            for (int i = 0; i < data.Count; i++)
            {
                double dummy;
                if (dataset.Info[i].Type == "Numerical")
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        if (double.TryParse((string)data[i][j], out dummy))
                            data[i][j] = dummy;
                        else data[i][j] = "?";
                    }
                }
            }
        }

        private void DataProcessor(string[] lines) //Pre-process raw data
        {
            string attrib = lines[0];
            
            attrib = attrib.Replace("\"", "");
            
            string[] s_attrib = attrib.Split(',');
            foreach (string tmp in s_attrib)
                dataset.Info.Add(new Instances { Attribute = tmp });

            //Debug attribute
            if (Debug_Chk.Checked)
            {
                this.Text = "Debug Mode";
                string _res = "";
                foreach (Instances tmp in dataset.Info)
                    _res += tmp.Attribute + " ";
                MessageBox.Show(_res, "Attribute Debug");
            }

            object[,] predata = new object[lines.Length - 1, dataset.Info.Count];
            
            //Debug array dimension
            if (Debug_Chk.Checked)
                MessageBox.Show("Row = " + predata.GetLength(0).ToString()
                                + "\n Col = " + predata.GetLength(1).ToString()
                                , "Dimension Debug");

            //Process lines of data into data array
            for (int i = 0; i < predata.GetLength(0); i++)
            {
                string[] line = lines[i+1].Split(','); //split value

                for (int j = 0; j < predata.GetLength(1); j++)
                    predata[i, j] = line[j];
            }

            //Debug get first line of data array
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

        private void setTable(DataSet dset) //Set attribute in table
        {
            for (int i = 1; i <= dset.Info.Count; i++)
            {
                I_Table.Rows.Add(i, false, dset.Info[i - 1].Attribute, dset.Info[i-1].Type);
            }
        }
        
        private double getMean(int index) //Get mean of numerical dataset
        {
            List<double> value = new List<double>();

            foreach (object o in dataset.Data[index])
                if (o.GetType() == typeof(double)) 
                    value.Add((double)o);

            if (value.Count == 0) return 0;
            return value.Average();
        }

        private string getMode(int index) //Get mode of nominal dataset
        {
            List<string> value = new List<string>();

            foreach (object o in dataset.Data[index])
            {
                if ((string)o != "?") value.Add((string)o);
            }


            return value.GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key;
        }

        private void Reset() //Re-init state
        {
            F_Data.Clear();
            F_Path.Clear();
            instances = "";
            dataset.Info.Clear();
            dataset.Data.Clear();
            I_Table.Rows.Clear();
            attIndex.Clear();
        }

        private void debugTable() //Get list of checked attribute
        {
            attIndex.Clear();
            string _res = "";
            foreach (DataGridViewRow chk in I_Table.Rows)
            {
                if ((bool)chk.Cells["Chk"].Value == true)
                {
                    attIndex.Add((int)chk.Cells["No"].Value-1);
                    _res += ((int)chk.Cells["No"].Value - 1).ToString() + " ";
                }
            }
            if (Debug_Chk.Checked)   MessageBox.Show(_res, "Table Debug");
        }

        private string getHeader(DataSet ds)
        {
            string header = "";
            foreach (Instances ins in ds.Info)
                header += "\"" + ins.Attribute + "\",";
            header = header.Substring(0, header.Length - 1) + "\r\n";
            if (Debug_Chk.Checked) F_Data.Text = header;
            return header;
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

                F_Data.Text = instances;

                DataProcessor(lines);

                //I_Info.PerformClick();

                setTable(dataset);

                header = getHeader(dataset);

                numAttrib.Text = dataset.Info.Count.ToString();
                numSample.Text = dataset.Data[0].Length.ToString();

                this.Text = "Weka Implement";
                MessageBox.Show("Load success!", "Notification");
            }          
        }

        private void F_Save_Click(object sender, EventArgs e) //Save data in debug screen to file
        {
            if (F_Data.Text == "")  MessageBox.Show("Nothing to save!", "Notification");
            else
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "CSV file(*.csv)|*.csv";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, F_Data.Text);
                    MessageBox.Show("File saved!", "Notification");
                }


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

        private void I_Info_Click(object sender, EventArgs e) //Show info
        {
            string _res = "";
            foreach (Instances ins in dataset.Info)
                _res += "\nAttrib: " + ins.Attribute
                     + "\tType: " + ins.Type;
            _res += "\n\nNumber of attributes: " + dataset.Info.Count
                 + "\n\nNumber of instances: " + dataset.Data[0].Length;
            MessageBox.Show(_res, "Data Info");
        }

        private void Chk_Click(object sender, DataGridViewCellEventArgs e) //Fire check checkbox event
        {
            if (I_Table.Columns[e.ColumnIndex].Name == "Chk")
            {
                DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();

                chk = (DataGridViewCheckBoxCell)I_Table.Rows[I_Table.CurrentRow.Index].Cells["Chk"];

                chk.Value = !(bool)chk.Value;
            }
        }

        private void Slt_All_Click(object sender, EventArgs e) //Fire check all checkbox event
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

        private void Slt_None_Click(object sender, EventArgs e) //Fire uncheck all checkbox event
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

        private void Slt_Invert_Click(object sender, EventArgs e) //Fire reverse check all checkbox event
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

        private void D_Width_Click(object sender, EventArgs e) //done
        {
            int bin;
            double range; 
            if (numBin.Text == "") MessageBox.Show("Nothing to do!", "Notification");                       //check input
            else if (!int.TryParse(numBin.Text,out bin) || bin == 1) MessageBox.Show("Wrong input","Notification");
            else
            {
                //Invoke result table
                D_Table.Columns[0].HeaderText = "Range";
                D_Table.Columns[1].HeaderText = "Value";


                debugTable();
                if (attIndex.Count == 0)
                    MessageBox.Show("Not choose attribute yet!", "Notification");                   
                else
                {
                    
                    List<object[]> Bindata = new List<object[]>();                         // Data after equal width hold at here!
                    for (int i = 0; i < attIndex.Count; ++i)
                    {
                        if (dataset.Info[attIndex[i]].Type == "Nominal")
                            MessageBox.Show("This attribute can't discretize by width!", "Notification");           //check condition
                        else
                        {                           
                            List<double> dtemp = new List<double>();
                            List<BinData> btemp = new List<BinData>();

                            foreach (object o in dataset.Data[attIndex[i]])                    //get value from dataset     
                                if (o.GetType() == typeof(double)) dtemp.Add((double)o);      
                      
                            Bindata.Add(dataset.Data[attIndex[i]]);                         //copy data from origin

                            if (Debug_Chk.Checked) MessageBox.Show(dtemp.Count.ToString(), "Count dtemp Debug");

                            
                            dtemp.Sort();
                            range = Math.Round((dtemp[dtemp.Count - 1] - dtemp[0]) / (bin - 1),4);                 //calculate range   , NOTE: special case: bin = 1
                            double rtemp = range + dtemp[0];

                            btemp.Add(new BinData { First = dtemp[0] - 1, Last = dtemp[0], AverageValue = "-inf" });
                            dtemp.RemoveAt(0);

                            for (int j = 1; j < bin; ++j)
                            {
                                string aver;
                                double first, last; 
                                List<double> tmp = new List<double>();
                                while (dtemp.Count != 0 && dtemp[0] <= rtemp)                   //take all data on each range
                                {
                                    tmp.Add(dtemp[0]);
                                    dtemp.RemoveAt(0);
                                }
                                if(tmp.Count == 0)                                            //case of empty bin
                                    aver = "0";
                                else                                
                                    aver = Math.Round(tmp.Average(), 3).ToString();          //save                                    
                                first = rtemp - range;
                                last = rtemp;
                                rtemp += range;                                          
                                btemp.Add(new BinData { First = first, Last = last, AverageValue = aver });
                            }

                            //  change data after discretizing.
                            for (int j = 0; j < Bindata[i].Length; ++j)
                            {
                                foreach(BinData bd in btemp)
                                    if ((double)Bindata[i][j] > bd.First && (double)Bindata[i][j] <= bd.Last)
                                    {
                                        if (bd.AverageValue == "-inf")
                                            Bindata[i][j] = (object)("(-inf" + "-" + bd.Last.ToString() + "]");
                                        else
                                            Bindata[i][j] = (object)("(" + bd.First.ToString() + "-" + bd.Last.ToString() + "]");

                                        break;
                                    }
                            }

                                if (Debug_Chk.Checked)
                                {
                                    string _res = "";
                                    foreach (object o in Bindata[i])
                                        _res += o.ToString() + " ";
                                    MessageBox.Show(_res, "First BinData Debug");
                                }                                                         
                        }
                    }
                }
            }
        }

        private void D_Freq_Click(object sender, EventArgs e) //finished but not confirm
        {
            int bin;
            if (weightBin.Text == "") MessageBox.Show("Nothing to do!", "Notification");                //check input
            else if (!int.TryParse(weightBin.Text, out bin)) MessageBox.Show("Wrong input", "Notification");
            else
            {
                debugTable();
                if (attIndex.Count == 0)
                    MessageBox.Show("Not choose attribute yet!", "Notification");
                else
                {
                    List<object[]> Bindata = new List<object[]>();                         // Data after equal weight hold at here!
                    for (int i = 0; i < attIndex.Count; ++i)
                    {
                        if (dataset.Info[attIndex[i]].Type == "Nominal")                            //check condition
                            MessageBox.Show("It's NOT make sense!", "Notification");    
                        else
                        {
                            List<double> dtemp = new List<double>();
                            List<BinData> btemp = new List<BinData>();

                            foreach (object o in dataset.Data[attIndex[i]])                    //get value from dataset     
                                if (o.GetType() == typeof(double)) dtemp.Add((double)o);

                            if (Debug_Chk.Checked) MessageBox.Show(dtemp.Count.ToString(), "Count dtemp Debug");

                            Bindata.Add(dataset.Data[attIndex[i]]);                     //copy data from origin

                            dtemp.Sort();
                            while(dtemp.Count != 0)
                            {
                                string aver;
                                double first, last;
                                List<double> tmp = new List<double>();

                                for (int j = 0; j < bin; ++j)                               //take data to bin
                                {
                                    tmp.Add(dtemp[0]);
                                    dtemp.RemoveAt(0);
                                    if (dtemp.Count == 0) break;
                                }

                                aver = Math.Round(tmp.Average(),3).ToString();              //calculate average
                                first = tmp[0];

                                if (tmp.Count > 2)
                                    tmp.RemoveRange(1, tmp.Count - 2);

                                last = tmp[tmp.Count - 1]; 
                                       
                                btemp.Add(new BinData { First = first, Last = last, AverageValue = aver });
                            }
                            //  change data after discretizing.
                            for (int j = 0; j < Bindata[i].Length; ++j)
                            {
                                foreach (BinData bd in btemp)
                                    if ((double)Bindata[i][j] >= bd.First && (double)Bindata[i][j] <= bd.Last)
                                    {
                                        Bindata[i][j] = (object)("[" + bd.First.ToString() + "-" + bd.Last.ToString() + "]");
                                        break;
                                    }
                            }

                                if (Debug_Chk.Checked)
                                {
                                    string _res = "";
                                    foreach (object o in Bindata[i])
                                        _res += o.ToString() + " ";
                                    MessageBox.Show(_res, "First BinData Debug");
                                }
                        }
                    }
                }
            }
        }
        
        private void I_Fill_Click(object sender, EventArgs e) //Fill missing value of dataset
        {
            DataSet temp_data = dataset;
            if (Debug_Chk.Checked)
            {
                this.Text = "Debug Mode";
                string _res = "";
                foreach (object o in temp_data.Data[3])
                {
                    _res += o.ToString() + " " + o.GetType().ToString() + "\n";
                }
                MessageBox.Show(_res);
            }
            
            for (int i = 0; i < temp_data.Info.Count - 1; i++)
            {
                if (temp_data.Info[i].Type == "Numerical")
                {
                    double _tmp = getMean(i);
                    for (int j = 0; j < temp_data.Data[i].Length; j++)
                    {
                        if (temp_data.Data[i][j].GetType() == typeof(string))
                            temp_data.Data[i][j] = _tmp;
                    }
                }
                else
                {
                    string _tmp = getMode(i);
                    for (int j = 0; j < temp_data.Data[i].Length; j++)
                    {
                        if ((string)temp_data.Data[i][j] == "?")
                            temp_data.Data[i][j] = _tmp;
                    }
                }
            }

            //Print out and save
            string data = "";
            for (int i = 0; i < temp_data.Data[0].Length; i++)
            {
                for (int j = 0; j < temp_data.Info.Count; j++)
                {
                    data += temp_data.Data[j][i] + ",";
                }
                data = data.Substring(0,data.Length-1) + "\r\n";
            }
            F_Data.Text = header + data;
        }

        private void N_MinMax_Click(object sender, EventArgs e) //Normalize using min-max
        {
            debugTable();

            if (attIndex.Count == 0)
                MessageBox.Show("Not choose attribute yet!", "Notification");//check input

            else
            {
                List<List<double>> res = new List<List<double>>();

                for (int i = 0; i < attIndex.Count; ++i)
                {

                    if (dataset.Info[attIndex[i]].Type == "Nominal")                            //check condition
                        MessageBox.Show("This attribute can't normalize!", "Notification");

                    else
                    {
                        List<double> temp = new List<double>();
                        foreach (object o in dataset.Data[attIndex[i]])                 //get data from dataset
                            temp.Add((double)o);

                        double min = temp.Min(), max = temp.Max();

                        for (int j = 0; j < temp.Count; ++j)                            //normalize
                            temp[j] = (temp[j] - min) / (max - min);

                        if (Debug_Chk.Checked)
                        {
                            string _res = "";
                            foreach (double d in temp)
                                _res += d.ToString() + " ";
                            MessageBox.Show(_res, "temp Debug");
                        }

                        res.Add(temp);      //  output data

                        
                    }

                }

                //Print out data for saving
                string _output = "";
                for (int k = 0; k < res[0].Count; k++)
                {
                    for (int j = 0; j < res.Count; j++)
                    {
                        _output += res[j][k].ToString() + ",";
                    }
                    _output = _output.Substring(0,_output.Length - 1) + "\r\n";
                }
                if (Debug_Quit.Checked) MessageBox.Show(_output, "Normalize min max");
                F_Data.Text = header + _output;
            }
        }

        private void N_Zscore_Click(object sender, EventArgs e) //Normalize using z-score
        {
            debugTable();
            if (attIndex.Count == 0)
                MessageBox.Show("Not choose attribute yet!", "Notification");
            else
            {
                List<List<double>> res = new List<List<double>>();
                for (int i = 0; i < attIndex.Count; ++i)
                {
                    if (dataset.Info[attIndex[i]].Type == "Nominal")
                        MessageBox.Show("This attribute can't normalize!", "Notification");
                    else
                    {
                        List<double> temp = new List<double>();
                        foreach (object o in dataset.Data[attIndex[i]])
                            temp.Add((double)o);

                        double mean = temp.Average(), sumofSqr = 0;                  //calculate mean
                        for (int j = 0; j < temp.Count; ++j)      //calculate v' = v - mean
                            temp[j] = temp[j] - mean;

                        for (int j = 0; j < temp.Count; ++j)                         //calculate sum of square
                            sumofSqr += Math.Pow(temp[j], 2);

                        for (int j = 0; j < temp.Count; ++j)
                            temp[j] = Math.Round(temp[j]/Math.Sqrt(sumofSqr/temp.Count),4);     //calculate stddev

                            if (Debug_Chk.Checked)
                            {
                                string _res = "";
                                foreach (double d in temp)
                                    _res += d.ToString() + " ";
                                MessageBox.Show(_res, "temp Debug");
                            }

                            res.Add(temp);               //output data
                    }
                }

                //Print out data for saving
                string _output = "";
                for (int k = 0; k < res[0].Count; k++)
                {
                    for (int j = 0; j < res.Count; j++)
                    {
                        _output += res[j][k].ToString() + ",";
                    }
                    _output = _output.Substring(0, _output.Length - 1) + "\r\n";
                }
                if (Debug_Quit.Checked) MessageBox.Show(_output, "Normalize min max");
                F_Data.Text = header + _output;
            }
        }
        #endregion

    }
}
