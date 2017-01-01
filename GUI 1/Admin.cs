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
    public partial class Admin: Form
    {
        public string c;
        public Admin()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
          //  this.Hide();
            ADD sistema = new ADD();
            sistema.ShowDialog();
            //this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          //  this.Hide();
            Search sistema = new Search();
            sistema.ShowDialog();
          //  this.Close();
            //  Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  this.Hide();
            UPdate sistema = new UPdate();
            sistema.ShowDialog();
          //  this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   this.Hide();
            Delete sistema = new Delete();
            sistema.ShowDialog();
          //  this.Close();
        }
    }
}
