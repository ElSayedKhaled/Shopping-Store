using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GUI_1
{
    
    public partial class check_admin : Form
    {
        public string c;
        public string check;
        

        public check_admin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            c = textBox1.Text.ToString();
            textBox1.PasswordChar = '*';

        }

        private void check_admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == "654321")
            {
               // MessageBox.Show("               OK    ");
                this.Hide();
                Admin sistema = new Admin();
                sistema.ShowDialog();
               // this.Close();
            }
            else
            {
                MessageBox.Show("        INVALID  ");
            }

        }
    }
}
