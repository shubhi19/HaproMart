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

    public partial class Form3 : Form
    {

        // Following classes are used only with select query
        String text = " ";
        OracleConnection conn;
        OracleCommand comm;
        // Following classes are used only with select query
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;


        public Form3()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();

          

            OracleCommand cm = new OracleCommand();

            cm.Connection = conn;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Empty Field");
            }
            else if (!Regex.IsMatch(textBox1.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Email Invalid");

            }

            else if (!Regex.IsMatch(textBox9.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Name has only letters");
            }
            else if (!Regex.IsMatch(textBox5.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("City has only letters");
            }
            else if (!Regex.IsMatch(textBox6.Text, (@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$")))
            {
                MessageBox.Show("Invalid Phone Number");
            }
            else if (!Regex.IsMatch(textBox8.Text, (@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$")))
            {
                MessageBox.Show("Invalid Phone Number");
            }
            else if (!Regex.IsMatch(textBox3.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Field accepts only numbers from 0-9");
            }
            else if (!Regex.IsMatch(textBox4.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Field accepts only numbers from 0-9");
            }
            else if (!Regex.IsMatch(textBox7.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Field accepts only numbers from 0-9");
            }


            else
            {
                String email = textBox1.Text;
                String pinno = textBox4.Text;
                DateTime a = dateTimePicker1.Value;
                
                int year = dateTimePicker1.Value.Year;
                int num2 = 2015;
                int num3 = num2 - year;
                String b = num3.ToString();

                OracleCommand ora_cmd = new OracleCommand("insertcustomercard", conn);
                ora_cmd.BindByName = true;
                ora_cmd.CommandType = CommandType.StoredProcedure;

                ora_cmd.Parameters.Add("card_number", OracleDbType.Int64, textBox3.Text, ParameterDirection.Input);
                ora_cmd.Parameters.Add("pin_number", OracleDbType.Int64, textBox4.Text, ParameterDirection.Input);
                ora_cmd.Parameters.Add("balance", OracleDbType.Int64, textBox7.Text, ParameterDirection.Input);
                ora_cmd.ExecuteNonQuery();



                OracleCommand ora_cmd1 = new OracleCommand("insertcustomer", conn);
                ora_cmd1.BindByName = true;
                ora_cmd1.CommandType = CommandType.StoredProcedure;

                ora_cmd1.Parameters.Add("email", OracleDbType.Varchar2, textBox1.Text, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("password", OracleDbType.Varchar2, textBox2.Text, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("name", OracleDbType.Varchar2, textBox9.Text, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("dob", OracleDbType.Varchar2, a, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("card_number", OracleDbType.Int64, textBox3.Text, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("pin_number", OracleDbType.Int64, textBox4.Text, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("city", OracleDbType.Varchar2, textBox5.Text, ParameterDirection.Input);
                ora_cmd1.Parameters.Add("age", OracleDbType.Varchar2, b, ParameterDirection.Input);
                ora_cmd1.ExecuteNonQuery();



                OracleCommand ora_cmd2 = new OracleCommand("insertcustomerphone", conn);
                ora_cmd2.BindByName = true;
                ora_cmd2.CommandType = CommandType.StoredProcedure;

                ora_cmd2.Parameters.Add("email", OracleDbType.Varchar2, textBox1.Text, ParameterDirection.Input);
                ora_cmd2.Parameters.Add("phone", OracleDbType.Int64, textBox6.Text, ParameterDirection.Input);
                ora_cmd2.ExecuteNonQuery();




                OracleCommand ora_cmd3 = new OracleCommand("insertcustomerphone", conn);
                ora_cmd3.BindByName = true;
                ora_cmd3.CommandType = CommandType.StoredProcedure;

                ora_cmd3.Parameters.Add("email", OracleDbType.Varchar2, textBox1.Text, ParameterDirection.Input);
                ora_cmd3.Parameters.Add("phone", OracleDbType.Int64, textBox8.Text, ParameterDirection.Input);
                ora_cmd3.ExecuteNonQuery();

                /*
                cm.CommandText = "insert into customercard values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')";

                cm.CommandType = CommandType.Text;

                cm.ExecuteNonQuery();
                

                cm.CommandText = "insert into customer values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox9.Text + "','" + a + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+b+"')";

                cm.CommandType = CommandType.Text;

                cm.ExecuteNonQuery();


                cm.CommandText = "insert into customerphone values('" + textBox1.Text + "','" + textBox6.Text + "')";

                cm.CommandType = CommandType.Text;

                cm.ExecuteNonQuery();


                cm.CommandText = "insert into customerphone values('" + textBox1.Text + "','" + textBox8.Text + "')";

                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
   */

                Form7 f7 = new Form7(email, pinno); // creates a new object for Form 2.
                f7.Show(); // Projecting the second form.
                this.Hide(); // Hides the Form 1 but doesn’t close.




            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
  

