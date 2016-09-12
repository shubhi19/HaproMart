using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
            Form4 f4 = new Form4(); // creates a new object for Form 2.
            f4.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(); // creates a new object for Form 2.
            f3.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }
    }
}
