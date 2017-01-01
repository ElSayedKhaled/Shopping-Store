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
using System.Threading;

namespace GUI_1
{
    public partial class registration : Form
    {
        public string usrnm;
        public string usrpass;
        public bool found = false;
        //   private check_admin _form2;
        //public int indxx=0;
        public string lne, pas, nam, lne1, pas1, nam1;
        List<KeyValuePair<string, string>> sline = new List<KeyValuePair<string, string>>();
        List<string> sline1 = new List<string>();

        public registration()
        {
            InitializeComponent();
            //textBox1.ForeColor = SystemColors.GrayText;
            //textBox1.Text = "USER NAME";
            //this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            //this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            //textBox2.ForeColor = SystemColors.GrayText;
            //textBox2.Text = "PASSWORD";
            //this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            //this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);

        }
        //private void textBox1_Enter(object sender, EventArgs e)
        //{
        //    if (textBox1.Text == "USER NAME")
        //    {
        //        textBox1.Text = "";
        //        textBox1.ForeColor = SystemColors.WindowText;
        //    }
        //}
        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    if (textBox1.Text.Length == 0)
        //    {
        //        textBox1.Text = "USER NAME";
        //        textBox1.ForeColor = SystemColors.GrayText;
        //    }
        //}
        //private void textBox2_Enter(object sender, EventArgs e)
        //{
        //    if (textBox2.Text == "PASSWORD")
        //    {
        //        textBox2.Text = "";
        //        textBox2.ForeColor = SystemColors.WindowText;
        //    }
        //}
        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    if (textBox2.Text.Length == 0)
        //    {
        //        textBox2.Text = "PASSWORD";
        //        textBox2.ForeColor = SystemColors.GrayText;
        //    }
        //}
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            usrnm = textBox1.Text.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            usrpass = textBox2.Text.ToString();
            textBox2.PasswordChar = '*';
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = File.OpenText("userdata.txt"))
            {
                int indxx = 0;
                bool alreadyExist = false;

                while (!sr.EndOfStream)
                {

                    lne = sr.ReadLine().ToString();
                    int indx = 0;
                    string[] words = lne.Split(' ');
                    foreach (string word in words)
                    {
                        if (indx == 0) { nam = word; indx++; }
                        else if (indx == 1) { pas = word; indx++; }
                    }
                    sline.Insert(indxx, new KeyValuePair<string, string>(pas, nam));


                    if (sline.Contains(new KeyValuePair<string, string>(usrpass, usrnm)))
                        alreadyExist = true;
                    if (alreadyExist)
                    {
                        // MessageBox.Show(" YES ");
                        this.Hide();
                        User sistema = new User();
                        sistema.ShowDialog();
                        //   this.Close();        
                        break;
                    }

                }

                if (!alreadyExist)
                {
                    MessageBox.Show(" User Not Found!");
                    sr.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    using (StreamReader or = File.OpenText("userdata.txt"))
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
                        for (int j = 0; j < sline1.Count; j=j+2)
                        {
                            if (usrnm == sline1[j])
                            {
                                MessageBox.Show(" Found Name");
                                    found = true;
                            }
                        }
            using (StreamWriter sw = File.AppendText("userdata.txt"))
            {
                if (found == false)
                    {
                        sw.Write(usrnm);
                        sw.Write(" ");
                        sw.WriteLine(usrpass);
                        sw.Close();
                    }
                
            }
        }
    }
}
 

