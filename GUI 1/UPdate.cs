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
    public partial class UPdate : Form
    {
            public string id;
          public  List<string> sline = new List<string>();
            public int id1;
            public string name1;
            public string price1;
            public string quantity1;

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
                    sr.Close();
                }
            }
        public UPdate()
        {
            InitializeComponent();
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = "ID";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
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
      
        private void UPdate_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = (textBox1.Text.ToString());
            }
            catch (Exception)
            { }
        }
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
                        if (id == (words[0].ToString()))
                        {
                            id1 = int.Parse(words[0].ToString());
                           name1 = words[1].ToString();
                           price1 = words[2].ToString();
                           quantity1 = words[3].ToString();
                            flag = true;
                        }

                    }
                    sr.Close();
                }


                if (!flag)
                {
                    MessageBox.Show("Your ID '" + id.ToString() + "' NOT FOUND");
                return;
                }
            
                textBox2.Text = id1.ToString();
                textBox5.Text = name1.ToString();
                textBox4.Text = price1.ToString();
                textBox3.Text = quantity1.ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
           checkids();
            using (StreamWriter sw = File.AppendText("products.txt"))
            {
                int counter = 1;
                bool found = false;
                for (int i = 0; i <sline.Count; i++)
                {
                    if (id.ToString() == sline[i])
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
                    using (var sr = new StreamReader("products.txt"))
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
                    //  MessageBox.Show(" DONE !");
                    File.Delete("products.txt");
                    File.Move(tempFile, "products.txt");
                    // this.Close();

                }
                else
                    MessageBox.Show(" ID NOT EXIST !");
            }
            using (StreamWriter sw = File.AppendText("products.txt"))
            {
                
                    sw.Write(textBox2.Text.ToString());
                    sw.Write(" ");
                    sw.Write(textBox5.Text.ToString());
                    sw.Write(" ");
                    sw.Write(textBox4.Text.ToString());
                    sw.Write(" ");
                    sw.WriteLine(textBox3.Text.ToString());
                label7.Text = "Updated Successfully";
                sw.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
