using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_1
{
    public partial class Recipt : Form
    {
        public string[] values_or;
        public string[] values_pr;
        public string line;
        public string newline;
        public int d, f, res;
        List<string> sline = new List<string>();
        List<string> sline1 = new List<string>();
        public Recipt()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         //   bool found = false;
            //string tempFile = Path.GetTempFileName();
            using (StreamReader or = File.OpenText("orders.txt"))
            using (StreamWriter re = File.CreateText("recipt.txt"))
            using (StreamReader pr = File.OpenText("products.txt"))
            {

                while (!or.EndOfStream)
                {
                    string x;
                    x = or.ReadLine();
                    string[] words = x.Split(' ');
                    foreach (string word in words)
                    {
                        sline1.Add(word.ToString());
                    }
                }
                or.Close();

                while (!pr.EndOfStream)
                {
                    string x;
                    x = pr.ReadLine();
                    string[] words = x.Split(' ');
                    foreach (string word in words)
                    {
                        sline.Add(word.ToString());
                    }
                }
                pr.Close();

                for (int i = 0; i < sline1.Count; i++)
                {
                    for (int j = 1; j < sline.Count; j = j + 4)
                    {
                        if (sline1[i] == sline[j])
                        {
                            re.Write(sline[j]);
                            re.Write(" ");
                            re.Write(sline1[i + 1]);
                            re.Write(" ");
                            d = int.Parse(sline[j + 2].ToString());
                            f = int.Parse(sline1[i + 1].ToString());
                            res = d * f;
                            re.WriteLine(res.ToString());

                        }
                    }
                }
            }


            using (StreamReader file = File.OpenText("recipt.txt"))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Total");

                string newline;
                while ((newline = file.ReadLine()) != null)
                {
                    DataRow dr = dt.NewRow();
                    string[] values = newline.Split(' ');
                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    dt.Rows.Add(dr);
                }
                file.Close();

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.validcreditcardnumber.com/");
            File.Delete("orders.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("THANK YOU !");
            File.Delete("orders.txt");
            this.Close();

        }
    }
       
 }

