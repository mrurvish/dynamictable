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

namespace database
{
    public partial class Form1 : Form
    {
        int id = 0;
        int rc = 0;
        int lastid = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.cn.Open();
            string sql = "insert into Table2 values('" + textBox1.Text + "','" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, Class1.cn);
            cmd.ExecuteNonQuery();
            Class1.cn.Close();
            loaddata();
        }


        private void button4_Click(object sender, EventArgs e)
        {
           /* Class1.cn.Open();
            id += 1;
            
            
                string sql1 = "select * from table2 where id='" + id + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, Class1.cn);
                SqlDataReader dr1 = null;
                dr1 = cmd1.ExecuteReader();
                string idcol1 = null;
                while (dr1.Read())
                {
                    textBox1.Text = dr1[1].ToString();
                    textBox2.Text = dr1[2].ToString();
                     idcol1 = dr1[0].ToString();
                }
                Class1.cn.Close();*/
            if (id != lastid)
            {
            lable:

                Class1.cn.Open();
                id += 1;
                string sql2 = "select * from table2 where id='" + id + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, Class1.cn);
                SqlDataReader dr2 = null;
                dr2 = cmd2.ExecuteReader();
                string ids = null;
                while (dr2.Read())
                {
                    ids = dr2[0].ToString();
                    textBox1.Text = dr2[1].ToString();
                    textBox2.Text = dr2[2].ToString();

                }
                if (ids == null)
                {
                    Class1.cn.Close();
                    goto lable;
                }
                else
                {
                    Class1.cn.Close();

                }
                Class1.cn.Close();

            }

           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (id != 0 && id!=1)
            {
            lable:

                Class1.cn.Open();
                id -= 1;
                string sql2 = "select * from table2 where id='" + id + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, Class1.cn);
                SqlDataReader dr2 = null;
                dr2 = cmd2.ExecuteReader();
                string ids = null;
                while (dr2.Read())
                {
                    ids = dr2[0].ToString();
                    textBox1.Text = dr2[1].ToString();
                    textBox2.Text = dr2[2].ToString();

                }
                if (ids == null)
                {
                    Class1.cn.Close();
                    goto lable;
                }
                else
                {
                    Class1.cn.Close();

                }
                Class1.cn.Close();

            }
        }


        private void rowcount()
        {
            Class1.cn.Open();
            string sql = "select * from Table2";
            SqlCommand cmd = new SqlCommand(sql, Class1.cn);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               lastid = Convert.ToInt32(dr[0]);
            }
          //  MessageBox.Show(rc.ToString());
            Class1.cn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rowcount();
            loaddata();
            
        }
        private void loaddata()
        {
            Class1.cn.Open();
            string sql = "select * from Table2";
            SqlCommand cmd = new SqlCommand(sql, Class1.cn);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            /*  while (dr.Read())
              {

                  label1.Text = "name="+dr[1].ToString()+"  "+"pwd="+dr[2].ToString();
                  
              }*/
            Class1.cn.Close();
           rc = dataGridView1.Rows.Count;
            //MessageBox.Show(row1.ToString());
        }

       

    }
}
