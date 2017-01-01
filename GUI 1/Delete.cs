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
    public partial class Delete : Form
    {
        public int id;
        List<string> sline = new List<string>();
        /// <summary>
        /// stored
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
                sr.Close();
            }
        }
        public Delete()
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(textBox1.Text.ToString());
            }
            catch(Exception)
            { }
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            checkids();
            using (StreamWriter sw = File.AppendText("products.txt"))
            {
                int counter = 1;
                bool found = false;
                for (int i = 0; i < sline.Count; i++)
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
                    MessageBox.Show(" DONE !");
                    File.Delete("products.txt");
                    File.Move(tempFile, "products.txt");
                    this.Close();

                }
                else
                    MessageBox.Show("Your ID '" + id.ToString() + "' NOT FOUND");


            }
        }

        private string[] RemoveUnnecessaryLine()
        {
            throw new NotImplementedException();
        }

        private void RemoveUnnecessaryLine(object lines)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
