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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Orders sistema = new Orders();
            sistema.ShowDialog();
           // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            CheckOrder sistema = new CheckOrder();
            sistema.ShowDialog();
           // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Recipt sistema = new Recipt();
            sistema.ShowDialog();
           // this.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {

        }
    }
}
