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
    public partial class newfaq : Form
    {

       
        OracleConnection conn;
        
        OracleCommand comm;
        // Following classes are used only with select query
        
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
      
    
     
        public newfaq()
        {
            InitializeComponent();
        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";
            conn = new OracleConnection(oradb);  // C#
            conn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            int id = Convert.ToInt32(textBox4.Text);


            OracleCommand cm = new OracleCommand();

            cm.Connection = conn;

            cm.CommandText = "insert into faq1 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";

            cm.CommandType = CommandType.Text;

            cm.ExecuteNonQuery();
            cm.CommandText = "insert into faq2 values('" + id + "','" + textBox1.Text + "')";

            cm.CommandType = CommandType.Text;

            cm.ExecuteNonQuery();

            MessageBox.Show("Inserted!");

            conn.Close();
            Form4 f = new Form4(); // creates a new object for Form 2.
            f.Show(); // Projecting the second form.
            this.Hide(); // Hides the Form 1 but doesn’t close.


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            connect1();
            int id = Convert.ToInt32(textBox4.Text);
            comm = new OracleCommand();
            comm.CommandText = "select * from faq2 where "
                + "serial_no = '" + id + "' ";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "instructor");
            dt = ds.Tables["instructor"];
            int t = dt.Rows.Count;
            if (t != 0)
            {
                MessageBox.Show("ID already present, please enter another");

            }
            else
            {
                MessageBox.Show("ID available");
            }
        }

        private void newfaq_Load(object sender, EventArgs e)
        {

        }
    }
}
