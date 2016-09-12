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
    public partial class Form7 : Form
    {
        String emailid = "";
        String pin = "";
        public Form7(string email, string pinno)
        {
            InitializeComponent();
            label5.Text = email;
            label6.Text = pinno;
            emailid = email;
            pin = pinno;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)

        {
            string email = label5.Text;
            string pin = label6.Text;
            household h = new household(email,pin); // creates a new object for Form 2.
            h.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = label5.Text;
            string pin = label6.Text;
            personalcare p = new personalcare(email,pin); // creates a new object for Form 2.
            p.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email = label5.Text;
            string pin = label6.Text;
            beverage_snacks b = new beverage_snacks(email,pin);
            b.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string email = label5.Text;
            string pin = label6.Text;
            beauty be = new beauty(email,pin); // creates a new object for Form 2.
            be.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_2(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit the Application?", "Exit", MessageBoxButtons.YesNoCancel);  

            if (dr == DialogResult.Yes)

                //e.Cancel = true;

                Application.Exit();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_pass cg = new change_pass(); // creates a new object for Form 2.
            cg.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete de = new delete(); // creates a new object for Form 2.
            de.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(emailid, pin); // creates a new object for Form 2.
            f7.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(emailid, pin); // creates a new object for Form 2.
            f6.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search s = new search(emailid,pin); // creates a new object for Form 2.
            s.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }
    }
}
