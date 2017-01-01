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
    public partial class ADD : Form
    {
        /// <summary>
        /// variables
        /// </summary>
        public int id;
        public double price,quantity;
        public string name1;
        List<string> sline = new List<string>();
      //  private object DialogRuslt;
      //  private object listReadFile;

        /// <summary>
        /// store ids' products
        /// </summary>
        /// 

        public void checkids()
        {
            sline.Clear();
            using (StreamReader sr = File.OpenText("products.txt"))
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
            }
        }
        
        public ADD()
        {
            InitializeComponent();
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = "ID";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Text = "Name";
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            textBox3.ForeColor = SystemColors.GrayText;
            textBox3.Text = "Price";
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
            textBox4.ForeColor = SystemColors.GrayText;
            textBox4.Text = "Quantity";
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            this.textBox4.Enter += new System.EventHandler(this.textBox4_Enter);
            textBox3.ForeColor = SystemColors.GrayText;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "ID";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Name";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                textBox3.Text = "Price";
                textBox3.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Price")
            {
                textBox3.Text = "";
                textBox3.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                textBox4.Text = "Quantity";
                textBox4.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Quantity")
            {
                textBox4.Text = "";
                textBox4.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(textBox1.Text.ToString());
                
            }
            catch (Exception) { }//MessageBox.Show("INVALED ID"); }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            name1 = textBox2.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                checkids();
            using (StreamWriter sw = File.AppendText("products.txt"))
            {
                bool insertion = true;
                for (int i = 0; i < sline.Count; i++)
                {
                    if (id.ToString() == sline[i])
                    { MessageBox.Show("       Found!"); insertion = false; break; }
                }
                if (insertion)
                {
                    sw.Write(id.ToString());
                    sw.Write(" ");
                    sw.Write(name1.ToString());
                    sw.Write(" ");
                    sw.Write(price.ToString());
                    sw.Write(" ");
                    sw.WriteLine(quantity.ToString());
                    sw.Close();
                    label1.Text = "Added successfully";
                    //this.Close();
                }
                
            }
            
        }

     
        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                quantity = double.Parse(textBox4.Text.ToString());
            }
            catch (Exception)
            { }
            //MessageBox.Show("INVALED"); }
        }

        private void ADD_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                price = double.Parse(textBox3.Text.ToString());
            }
            catch (Exception)
            { }// MessageBox.Show("INVALED"); }
        }

       
    }
}
