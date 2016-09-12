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
    public partial class search : Form
    {
        DataSet myDataSet;
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
        String mail = "";
        String pinno = "";
        public search(String email, String pin)
        {
            InitializeComponent();
            mail = email;
            pinno = pin;
        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }

        private void search_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            String name = textBox1.Text;
            try
            {

                String query = "select * from productmaster where " + "product_name = '" + name + "' ";
                string ConString = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";
                using (OracleConnection con = new OracleConnection(ConString))
                {
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(mail,pinno); // creates a new object for Form 2.
            f7.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search s = new search(mail,pinno); // creates a new object for Form 2.
            s.Show(); // Projecting the second form.
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
            Form6 f6 = new Form6(mail,pinno); // creates a new object for Form 2.
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
    }
}
