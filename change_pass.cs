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
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApplication3
{
    public partial class change_pass : Form

    {

        
        // Following classes are used only with select query
        String text = " ";
        OracleConnection conn;
        OracleCommand comm;
        // Following classes are used only witJ:\New folder\Login\Login\app.configh select query
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        
        public change_pass()
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
        private void change_pass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Empty Field");
            }
            else if (!Regex.IsMatch(textBox1.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Email Invalid");

            }
            else
            {
                connect1();
                String pass = textBox2.Text;

                OracleCommand cm = new OracleCommand();

                cm.Connection = conn;

                cm.CommandText = "update customer set password=:pb where email =:pdn";

                cm.CommandType = CommandType.Text;

                //Uses OracleParameter to read the parameter from the GUI, each parameter has name, type 

                OracleParameter pa1 = new OracleParameter();

                pa1.ParameterName = "pb";

                pa1.DbType = DbType.String;

                pa1.Value = pass;

                OracleParameter pa2 = new OracleParameter();

                pa2.ParameterName = "pdn";

                pa2.DbType = DbType.String;

                pa2.Value = textBox1.Text;

                cm.Parameters.Add(pa1);    //parameters: Gets the OracleParameterCollection.

                cm.Parameters.Add(pa2);

                cm.ExecuteNonQuery();

                MessageBox.Show("Password updated successfully, please login to continue");

                conn.Close();
                Form2 ff = new Form2(); // creates a new object for Form 2.
                ff.Show(); // Projecting the second form.
                this.Hide(); // Hides the Form 1 but doesn’t close.

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            String info = textBox1.Text;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("shubhishrivastava95@gmail.com");
            mail.To.Add(info);
            mail.Subject = "Password change";
            mail.Body += " <html>";
            mail.Body += "<body>";
            mail.Body += "<table>";
            mail.Body += "<tr>";
            
            mail.Body += "<td>This is to inform regarding change of password</td><td></td>";
            mail.Body += "</tr>";

            mail.Body += "<tr>";
            mail.Body += "<td></td><td>if you have not changed your password please write back to us.</td>";
            mail.Body += "</tr>";
            mail.Body += "</table>";
            mail.Body += "</body>";
            mail.Body += "</html>";
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("shubhishrivastava95@gmail.com", "nayakshivangini");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            MessageBox.Show("sent");

        }
    }
}
