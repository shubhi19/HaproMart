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
using System.Text.RegularExpressions;
namespace WindowsFormsApplication3
{
    public partial class delete : Form
    {
      
       

        // Following classes are used only with select query
      
        OracleConnection conn;
        OracleCommand comm;
        // Following classes are used only witJ:\New folder\Login\Login\app.configh select query
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        
        
        string delemail = "";
        public delete()
        {
            String info = " ";
            InitializeComponent();
         //   delemail = email;

        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Empty Field");
            }
            else if (!Regex.IsMatch(textBox1.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Email Invalid");

            }
            else
            {

                comm = new OracleCommand();


                comm.CommandText = "delete from customerphone where email= '" + textBox1.Text + "'";
                comm.CommandType = CommandType.Text;    // Command or Stored procedure
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "instructor");
                dt = ds.Tables["instructor"];

                comm.CommandText = "delete from cart where email= '" + textBox1.Text + "'";
                comm.CommandType = CommandType.Text;    // Command or Stored procedure
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "instructor");
                dt = ds.Tables["instructor"];

                comm.CommandText = "delete from customer where email= '" + textBox1.Text + "'";
                comm.CommandType = CommandType.Text;    // Command or Stored procedure
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "instructor");
                dt = ds.Tables["instructor"];

                String info = "";
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 200;
                for (int i = 0; i <= 200; i++)
                {
                    System.Threading.Thread.Sleep(10);
                    progressBar1.Value = i;
                    info = i.ToString();
                }
                MessageBox.Show("Account Deleted Successfully!", "Message Box");
                Form2 f2 = new Form2(); // creates a new object for Form 2.
                f2.Show(); // Projecting the second form.
                this.Hide(); // Hides the Form 1 but doesn’t close.
            }
        }
     
       

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete de = new delete(); // creates a new object for Form 2.
            de.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit the Application?", "Exit", MessageBoxButtons.YesNoCancel);  

            if (dr == DialogResult.Yes)

                //e.Cancel = true;

                Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void delete_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
