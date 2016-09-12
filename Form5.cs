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
    public partial class Form5 : Form
    {
        OracleConnection conn;

     

        // Following classes are used only with select query

     
        int cart_id = 0;
        string email = "";
        string item_desc = "Provided by Hapromart";
        string pro_name = "";
        int pro_qty = 0;
        int finalcost = 0;
        string cartid="";


        public Form5(string user,string pinno,string name,int qty,int final)
        {
            InitializeComponent();
            label7.Text = user;
            label8.Text = pinno;
            label4.Text = final.ToString();
            cart_id = Convert.ToInt32(pinno);
            email = user;
            pro_name = name;
            pro_qty = qty;
            finalcost = final;
            cartid = pinno;
            
        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            string payment = comboBox1.SelectedItem.ToString();
           

            OracleCommand cm = new OracleCommand();

            cm.Connection = conn;
            cm.CommandText = "insert into have values('" + cart_id + "','" + pro_name + "','" + pro_qty + "','" + finalcost + "')";
           
            cm.CommandType = CommandType.Text;

            cm.ExecuteNonQuery();
            OracleCommand cmm = new OracleCommand();

            cmm.Connection = conn;

            cmm.CommandText = "insert into cart values('" + cart_id + "','" + payment + "','" + item_desc + "','" + email + "')";

            cmm.CommandType = CommandType.Text;

            cmm.ExecuteNonQuery();

            




            payment p = new payment(email,cartid,payment); // creates a new object for Form 2.
            p.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(email,cartid); // creates a new object for Form 2.
            f7.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete de = new delete(); // creates a new object for Form 2.
            de.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(email,cartid); // creates a new object for Form 2.
            f6.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
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

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search s = new search(email,cartid); // creates a new object for Form 2.
            s.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }
    }
}
