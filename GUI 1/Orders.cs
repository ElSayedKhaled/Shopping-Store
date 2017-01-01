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
    
    public partial class Orders : Form
    {
        public string name;
     //   public string price1;
        public int quantity=0;
        List<string> sline1 = new List<string>();

        public Orders()
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
        }

            private void textBox1_Leave(object sender, EventArgs e)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text ="Name";
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
        private void button1_Click(object sender, EventArgs e)
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
                dataGridView1.DataSource = dt;
            }
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                        name = textBox1.Text.ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                quantity = int.Parse(textBox2.Text.ToString());
                //if (quantity == 0)
                //{ MessageBox.Show("Quantity Cannot Be NULL"); }
            }
            catch (Exception )
            {
                quantity = 0;
            }      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool found = false;
            bool found1 = false;
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
            }
                int counter = 1;
                for (int j = 1; j < sline1.Count; j = j + 4)
                {
                    if (name == sline1[j])
                    {
                        // MessageBox.Show(" Found Name");
                        found = true;
                        if (quantity <= int.Parse(sline1[j + 2]))
                        {
                            found1 = true;
                                string tempFile = Path.GetTempFileName();
                                int line_number = 0;
                                using (var sr = new StreamReader("products.txt"))
                                using (var vv = new StreamWriter(tempFile))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        line_number++;
                                        if (line_number == counter)
                                        { 
                                            vv.Write(sline1[j - 1]);
                                            vv.Write(" ");
                                            vv.Write(sline1[j]);
                                            vv.Write(" ");
                                            vv.Write(sline1[j + 1]);
                                            vv.Write(" ");
                                            vv.WriteLine(int.Parse(sline1[j + 2]) - quantity);
                                        }
                                        else
                                            vv.WriteLine(line);
                                    }
                                }
                                File.Delete("products.txt");
                                File.Move(tempFile, "products.txt");
                            
                        }
                    }
                    
                    counter++;
                }
                if(found==false)
                    MessageBox.Show("Product Name NOT Found");
                if (found1 == false)
                    MessageBox.Show("Quantity NOT Found");
            
            using (StreamWriter sw = File.AppendText("orders.txt"))
            {
                if (found == true && found1 == true)
                {
                    sw.Write(name.ToString());
                    sw.Write(" ");
                    sw.WriteLine(quantity.ToString());
                    sw.Close();
                    label5.Text = "Saved Successfully";

                }
                
                    //  MessageBox.Show("         DONE ! ");
              //  this.Close();
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
