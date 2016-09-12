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
    public partial class household : Form

    {
        
        OracleConnection conn;

        OracleCommand comm;

        // Following classes are used only with select query

        OracleDataAdapter da;

        DataSet ds;

        DataTable dt;

        DataRow dr;

        int i = 0;
        string emailid = "";
        string cart = "";
        public household(string email,string pinno)
        {
            InitializeComponent();
            label12.Text = email;
            label13.Text = pinno;
            emailid = email;
            cart = pinno;
        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }

        private void household_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect1();
           

                int final = 0;
                string user = label12.Text;
                string pinno = label13.Text;
                string name = "";
                int qty_final = 0;
                
                comm = new OracleCommand();
                if (checkBox2.Checked == true)
                {
                    int cost = 0;
                    int qty = 0;
                 
                   
                    comm.CommandText = "select cost from productmaster where "
                       + "product_name = '" + label14.Text + "' ";
                    comm.CommandType = CommandType.Text;    // Command or Stored procedure

                    da = new OracleDataAdapter(comm.CommandText, conn);

                    ds = new DataSet();

                    da.Fill(ds, "instructor");

                    dt = ds.Tables["instructor"];
                    int t = dt.Rows.Count;
                    dr = dt.Rows[i];
                    cost = Convert.ToInt32(dr["cost"]);


                    qty = Convert.ToInt32(textBox2.Text);
                    final = final + (qty * cost);
                    name = label14.Text;
                    qty_final = qty_final + qty;
                }
                if (checkBox1.Checked == true)
                {
                    int cost = 0;
                    int qty = 0;
                 
                    comm.CommandText = "select cost from productmaster where "
                       + "product_name = '" + label9.Text + "' ";
                    comm.CommandType = CommandType.Text;    // Command or Stored procedure

                    da = new OracleDataAdapter(comm.CommandText, conn);

                    ds = new DataSet();

                    da.Fill(ds, "instructor");

                    dt = ds.Tables["instructor"];
                    int t = dt.Rows.Count;
                    dr = dt.Rows[i];
                    cost = Convert.ToInt32(dr["cost"]);


                    qty = Convert.ToInt32(textBox1.Text);
                    final = final + (qty * cost);
                    name = label9.Text;
                    qty_final = qty_final + qty;
                }
                if (checkBox3.Checked == true)
                {
                    int cost = 0;
                    int qty = 0;
                   
                    comm.CommandText = "select cost from productmaster where "
                       + "product_name = '" + label17.Text + "' ";
                    comm.CommandType = CommandType.Text;    // Command or Stored procedure

                    da = new OracleDataAdapter(comm.CommandText, conn);

                    ds = new DataSet();

                    da.Fill(ds, "instructor");

                    dt = ds.Tables["instructor"];
                    int t = dt.Rows.Count;
                    dr = dt.Rows[i];
                    cost = Convert.ToInt32(dr["cost"]);


                    qty = Convert.ToInt32(textBox3.Text);
                    final = final + (qty * cost);
                    name = label17.Text;
                    qty_final = qty_final + qty;
                }
               
            conn.Close();
            
                Form5 f5 = new Form5(user,cart,name,qty_final,final); // creates a new object for Form 2.
                f5.Show(); // Projecting the second form.
                this.Hide(); // Hides the Form 1 but doesn’t close.

            }


          
        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(emailid, cart); // creates a new object for Form 2.
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
            Form6 f6 = new Form6(emailid, cart); // creates a new object for Form 2.
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_pass cg = new change_pass(); // creates a new object for Form 2.
            cg.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search s = new search(emailid,cart); // creates a new object for Form 2.
            s.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

       
    }
}
