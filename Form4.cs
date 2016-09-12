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
    public partial class Form4 : Form
    {
        OracleConnection conn;

        OracleCommand comm;

        // Following classes are used only with select query

        OracleDataAdapter da;

        DataSet ds;

        DataTable dt;
        int i = 0;
        OracleDataAdapter da1;

        DataSet ds1;

        DataTable dt1;
        DataRow dr1;

       
        public Form4()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            connect1();
            comm = new OracleCommand();
            comm.CommandText = "select email, password from customer where "
                + "email = '" + textBox1.Text + "' and "
                + "password = '" + textBox2.Text + "' ";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "instructor");
            dt = ds.Tables["instructor"];
            int t = dt.Rows.Count;


            if (t != 0)
            {
                string pinno = "";
                connect1();
                comm = new OracleCommand();
                comm.CommandText = "select pin_number from customer where "
                    + "email = '" + textBox1.Text + "' ";
                comm.CommandType = CommandType.Text;
                da1 = new OracleDataAdapter(comm.CommandText, conn);
                ds1 = new DataSet();
                da1.Fill(ds1, "instructor");
                dt1 = ds1.Tables["instructor"];
                int t1 = dt1.Rows.Count;
                dr1 = dt1.Rows[i];
                pinno = dr1["pin_number"].ToString();

                Form7 f7 = new Form7(email,pinno); // creates a new object for Form 2.
                f7.Show(); // Projecting the second form.
                this.Hide(); // Hides the Form 1 but doesn’t close.
            }
            else
                MessageBox.Show("Wrong username or password");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)

        {
            string email = textBox1.Text;
            delete d = new delete(); // creates a new object for Form 2.
            d.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
