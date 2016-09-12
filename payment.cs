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
    public partial class payment : Form
    {
        String email = "";

        OracleConnection conn;

        OracleCommand comm;

        // Following classes are used only with select query

        OracleDataAdapter da;

        DataSet ds;

        DataTable dt;

        DataRow dr;

        int i = 0;
        string pay = "";
        public payment(string user, string pinno, string payment)
        {
            InitializeComponent();
            label4.Text = user;
            email = user;
            pay = payment;

        }
        public void connect1()
        {

            string oradb = "Data Source=mit-dept-c0123;User ID=system;Password=nayakshivangini";

            conn = new OracleConnection(oradb);  // C#

            conn.Open();

        }


        private void payment_Load(object sender, EventArgs e)
        {

            if ((pay == "CARD") || (pay == "NET BANKING"))
            {

                comm.CommandText = "select card_number from customer where "
                          + "email = '" + email + "' ";
                comm.CommandType = CommandType.Text;    // Command or Stored procedure

                da = new OracleDataAdapter(comm.CommandText, conn);

                ds = new DataSet();

                da.Fill(ds, "instructor");

                dt = ds.Tables["instructor"];
                int t = dt.Rows.Count;
                dr = dt.Rows[i];
                label3.Text = "Card Number";
                label2.Text = dr["card_number"].ToString();

            }
            else
            {
                label3.Text = "Your product will be delivered within 6-7 working days";

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thankyou ty = new thankyou();
            ty.Show();
            this.Hide();
        }
    }
}
