using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private registration _form2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (_form2 == null)
                _form2 = new registration();
            _form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            check_admin fLogin = new check_admin();
             if (fLogin.ShowDialog() == DialogResult.OK)
                 {
                       Application.Run(new check_admin());
                 }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
