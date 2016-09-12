using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace WindowsFormsApplication3
{
    public partial class thankyou : Form
    {
        public thankyou()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit the Application?", "Exit", MessageBoxButtons.YesNoCancel);  

            if (dr == DialogResult.Yes)

                //e.Cancel = true;

                Application.Exit();
        }
    }
}
