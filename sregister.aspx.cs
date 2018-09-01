﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class sregister : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path, fn;
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "" || TextBox8.Text == "" || TextBox9.Text == "")
        {
            Label1.Text = "Please enter all details";
        }
        else
        {
            if (FileUpload2.HasFile)
            {
                if (TextBox4.Text == TextBox8.Text)
                {
                    fn = FileUpload2.FileName;
                    path = "~\\images\\stud\\" + fn;
                    FileUpload2.SaveAs(Server.MapPath(path));
                    string value = "";
                    bool isChecked = RadioButton1.Checked;
                    if (isChecked)
                        value = RadioButton1.Text;
                    else
                        value = RadioButton2.Text;
                    SqlCommand cmd = new SqlCommand("insert into tblstudent values(@na,@un,@ps,@ed,@ge,@dob,@ad,@em,@cn,@ph,@st,@cd)", con);
                    cmd.Parameters.AddWithValue("@na", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@un", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@ps", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@ed", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@dob", TextBox7.Text);
                    cmd.Parameters.AddWithValue("@ad", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@em", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@cn", TextBox9.Text);
                    cmd.Parameters.AddWithValue("@ge", value);
                    cmd.Parameters.AddWithValue("@ph", path);
                    cmd.Parameters.AddWithValue("@st", "true");
                    cmd.Parameters.AddWithValue("@cd", Convert.ToDateTime(System.DateTime.Now.ToString()));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session["user"] = TextBox2.Text;
                    Response.Redirect("User/Home.aspx");
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Passwords don't match";
                }
            }
            else
            {
                if (TextBox4.Text == TextBox8.Text)
                {
                    string value = "";
                    bool isChecked = RadioButton1.Checked;
                    if (isChecked)
                        value = RadioButton1.Text;
                    else
                        value = RadioButton2.Text;
                    SqlCommand cmd = new SqlCommand("insert into tblstudent values(@na,@un,@ps,@ed,@ge,@dob,@ad,@em,@cn,@ph,@st,@cd)", con);
                    cmd.Parameters.AddWithValue("@na", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@un", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@ps", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@ed", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@dob", TextBox7.Text);
                    cmd.Parameters.AddWithValue("@ad", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@em", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@cn", TextBox9.Text);
                    cmd.Parameters.AddWithValue("@ge", value);
                    cmd.Parameters.AddWithValue("@ph", "~\\images\\user.png");
                    cmd.Parameters.AddWithValue("@st", "true");
                    cmd.Parameters.AddWithValue("@cd", Convert.ToDateTime(System.DateTime.Now.ToString()));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session["user"] = TextBox2.Text;
                    Response.Redirect("User/Home.aspx");
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Passwords don't match";
                }
            }
        }
    }
}