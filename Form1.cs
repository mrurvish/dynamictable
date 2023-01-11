using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace dynamicdata
{
    public partial class Form1 : Form
    {
        int textbox = 0;
        int datatype = 0;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbname == null&&nofilds== null)
            {

            }
            else
            {
                int fild = Convert.ToInt32(nofilds.Text);

                for (int i = 0; i < fild; i++)
                {
                    TextBox txt = new TextBox();
                    this.Controls.Add(txt);
                    txt.Left = textbox * 60;
                    txt.Name = "fildname" + i;
                    txt.Top = 130;
                    //txt.Text = "TextBox" + this.textbox.ToString();
                    //  textbox = textbox * 60;
                  
                    textbox = textbox + 2;
                }
                for (int i = 0; i < fild; i++)
                {
                    TextBox txt = new TextBox();
                    this.Controls.Add(txt);
                    txt.Left = datatype * 60;
                    txt.Name = "dtype" + i;
                    txt.Top = 150;
                    //txt.Text = "TextBox" + this.textbox.ToString();
                    //  textbox = textbox * 60;
                    datatype = datatype + 2;
                }
                button1.Hide();
                ctable.Show();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctable.Hide();
           
        }

        private void ctable_Click(object sender, EventArgs e)
        {
            try
            {
               




                Class1.cn.Open();
                int fild = Convert.ToInt32(nofilds.Text);
                string sql = "CREATE TABLE " + tbname.Text;
                sql += " " + "(id integer";
                for (int i = 0; i < fild; i++)
                {
                    TextBox txt = (TextBox)Controls["fildname" + i];
                    //fildname[i] = txt.Text;
                    // MessageBox.Show(txt.Text);
                    TextBox txt1 = (TextBox)Controls["dtype" + i];
                    //datatye[i] = txt1.Text;
                    sql += "," + txt.Text + " " + txt1.Text;
                }

                sql += ")";
                // MessageBox.Show(sql);
                SqlCommand cmd = new SqlCommand(sql, Class1.cn);
                cmd.ExecuteNonQuery();
                Class1.cn.Close();

               
                tbname.Text = nofilds.Text = string.Empty;
                button1.Show();
                ctable.Hide();
                for (int ix = 0; ix < fild; ix++)
                {
                     this.Controls["fildname" + ix].Dispose();
                     this.Controls["dtype" + ix].Dispose(); 

                }
                textbox = 0;
                datatype = 0;
                
                }
                catch (SqlException E) {
                    MessageBox.Show("filds is empty or incorrect");
                    Class1.cn.Close();
                }
        }
    }
}
