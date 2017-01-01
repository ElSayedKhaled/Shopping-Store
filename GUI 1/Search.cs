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
    public partial class Search : Form
    {
        public int id;
       // List<string> sline = new List<string>();
        /// <summary>
        /// stored
        /// </summary>
        ///
        public Search()
        {
            InitializeComponent();
            textBox5.ForeColor = SystemColors.GrayText;
            textBox5.Text = "ID";
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            this.textBox5.Enter += new System.EventHandler(this.textBox5_Enter);
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                textBox5.Text = "ID";
                textBox5.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "ID")
            {
                textBox5.Text = "";
                textBox5.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try { id = int.Parse(textBox5.Text.ToString()); }
            catch (Exception)
            {}
        }
        public int id1;
        public string name1;
        public string price1;
        public string quantity1;
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;

            using (StreamReader sr = File.OpenText("products.txt"))
            { 
                    while (!sr.EndOfStream)
                    {
                        string x;
                        x = sr.ReadLine();
                        string[] words = x.Split(' ');

                        if (id == int.Parse(words[0].ToString()))
                        {
                            id1 = int.Parse(words[0].ToString());
                            name1 = words[1].ToString();
                            price1 = words[2].ToString();
                            quantity1 = words[3].ToString();
                            flag = true;
                        }

                    }
                    sr.Close();
                    if (!flag)
                    {
                        MessageBox.Show("Your ID '" + id.ToString() + "' NOT FOUND");
                        return;
                    }
                    textBox1.Text = id1.ToString();
                    textBox2.Text = name1.ToString();
                    textBox3.Text = price1.ToString();
                    textBox4.Text = quantity1.ToString();
                label1.Text = "ID";
                label2.Text = "Name";
                label3.Text = "Price";
                label4.Text = "Quantity";
                
            }
       }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
