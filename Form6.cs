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
    public partial class Form6 : Form
    {
        OracleConnection conn;

        OracleCommand comm;

        // Following classes are used only with select query

        OracleDataAdapter da;

        DataSet ds;

        DataTable dt;

        DataRow dr;

        int i = 0;
        string email = "";
        string cartid = "";
        
        public Form6(string user,string cart)
        {
            InitializeComponent();
            email = user;
            cartid = cart;
         

        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            connect1();

            comm = new OracleCommand();

            comm.CommandText = "select ques,ans from faq1";

            comm.CommandType = CommandType.Text;    // Command or Stored procedure

            da = new OracleDataAdapter(comm.CommandText, conn);

            ds = new DataSet();

            da.Fill(ds, "instructor");

            dt = ds.Tables["instructor"];

            int t = dt.Rows.Count;

            dr = dt.Rows[i];

            label2.Text = dr["ques"].ToString();

            label3.Text = dr["ans"].ToString();

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       /*     connect1();

            comm = new OracleCommand();

            comm.CommandText = "select ques,ans from faq1";

            comm.CommandType = CommandType.Text;    // Command or Stored procedure

            da = new OracleDataAdapter(comm.CommandText, conn);

            ds = new DataSet();

            da.Fill(ds, "instructor");

            dt = ds.Tables["instructor"];

            int t = dt.Rows.Count;

            dr = dt.Rows[i];

            label2.Text = dr["ques"].ToString();

            label3.Text = dr["ans"].ToString();

            conn.Close();  */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i--;

            if (i < 0)

                i = dt.Rows.Count - 1;

            dr = dt.Rows[i];

            label2.Text = dr["ques"].ToString();

            label3.Text = dr["ans"].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            i++;

            if (i >= dt.Rows.Count)

                i = 0;

            dr = dt.Rows[i];

            label2.Text = dr["ques"].ToString();

            label3.Text = dr["ans"].ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            newfaq faq = new newfaq(); // creates a new object for Form 2.
            faq.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(email, cartid); // creates a new object for Form 2.
            f7.Show(); // Projecting the second form.
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

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete de = new delete(); // creates a new object for Form 2.
            de.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
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
