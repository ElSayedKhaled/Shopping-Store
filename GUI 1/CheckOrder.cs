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
    public partial class CheckOrder : Form
    {
        public string name, name1, newline ;
        public int quantity=0;
        List<string> sline = new List<string>();
        List<string> sline1 = new List<string>();
        /// <summary>
        /// stored
        /// </summary>
        /// 
        public void checkNames()
        {
            sline.Clear();
            using (StreamReader sr = File.OpenText("orders.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string x;
                    x = sr.ReadLine();
                    string[] words = x.Split(' ');
                    int indx = 0;
                    foreach (string word in words)
                    {
                        if (indx == 0)
                            sline.Add(word.ToString());
                        indx++;
                    }
                }
                sr.Close();
            }
        }
        public CheckOrder()
        {
            InitializeComponent();
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = "Name";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Text = "Quantity";
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            textBox3.ForeColor = SystemColors.GrayText;
            textBox3.Text = "Name";
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Name";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Quantity";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Quantity")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                textBox3.Text = "Name";
                textBox3.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Name")
            {
                textBox3.Text = "";
                textBox3.ForeColor = SystemColors.WindowText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader file = File.OpenText("orders.txt"))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Quantity");

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
            catch (Exception) { }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader file = File.OpenText("products.txt"))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                dt.Columns.Add("Quantity");

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
                dataGridView2.DataSource = dt;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            { quantity = int.Parse(textBox2.Text.ToString()); }
            catch (Exception) { quantity = 0; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool found = false;
            using (StreamReader or = File.OpenText("products.txt"))
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

                for (int j = 1; j < sline1.Count; j = j + 4)
                {
                    if (name == sline1[j])
                    {
                        // MessageBox.Show(" Found Name");
                        found = true;
                    }
                }
                if(found==false)
                    MessageBox.Show("Product Name NOT Found");
            }
            using (StreamWriter sw = File.AppendText("orders.txt"))
            {
                if (found == true)
                {
                    sw.Write(name.ToString());
                    sw.Write(" ");
                    sw.WriteLine(quantity.ToString());
                    sw.Close();
                    label3.Text = "Saved Successfully";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            name1= textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // checkNames();
           
            using (StreamReader sw = File.OpenText("orders.txt"))
            {
                int counter = 1;
                bool found = false;
                while ((newline = sw.ReadLine()) != null)
                {
                    string[] values = newline.Split(' ');
                    if (name1.ToString() == values[0])
                    {
                        found = true;

                        break;
                    }
                    counter++;

                }
                sw.Close();

                if (found)
                {
                    string tempFile = Path.GetTempFileName();
                    int line_number = 0;
                    using (var sr = new StreamReader("orders.txt"))
                    using (var vv = new StreamWriter(tempFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            line_number++;
                            if (line_number != counter)
                                vv.WriteLine(line);
                        }
                    }
                    // MessageBox.Show(" DONE !");
                    label4.Text = "Deleted Successfully";
                    File.Delete("orders.txt");
                    File.Move(tempFile, "orders.txt");
                   
                }
                else
                    MessageBox.Show("Your Name '" + name1 + "' NOT FOUND");


            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
