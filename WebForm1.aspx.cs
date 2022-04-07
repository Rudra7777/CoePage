using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;


namespace final
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        DataTable dt = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(strconn);

                SqlCommand cmd = new SqlCommand("select * from Examination", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList7.DataSource = dt;
                DropDownList7.DataBind();
                BindData();


            }       



        }

       


        protected void Button1_Click(object sender, EventArgs e)
        {

            string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {       


                SqlCommand cmd = new SqlCommand("INSERT INTO entries(Seat_No,MnthYear,Semester,Exam_Type,Mod_Date)VALUES(@seat,@exam_session,@sem,@type,@date)", conn);
                cmd.Parameters.AddWithValue("@seat", UserName.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_session", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@sem", DropDownList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@type", DropDownList4.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());




                cmd.ExecuteNonQuery();

                BindData(); 




                UserName.Text = "";

                DropDownList1.SelectedValue = "0";
                DropDownList3.SelectedValue = "0";
                DropDownList4.SelectedValue = "0";
                Response.Write("<script>alert('Record added successfully');</script>");

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }

        protected void BindData()
        {
            string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {


                if (DropDownList7.SelectedValue == "0" && TextBox1.Text.Trim() == "" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue == "0")
                {

                    dt.Clear();
                    SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries", conn);
                    adp.Fill(dt);

                    if (dt.Rows.Count >= 0)
                    {
                        dt.DefaultView.RowFilter = TextBox1.Text = "";
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('No records found');</script>");
                    }


                }

               

               
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            BindData();

            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();

            if (DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND MnthYear='" + DropDownList7.SelectedItem.Text + "'", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'  AND Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'   AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }


            else if (DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'   AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }



        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();

            if (TextBox1.Text.Trim()=="" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "'", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() != "" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND MnthYear='" + DropDownList7.SelectedItem.Text + "'", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() == "" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "'  AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() == "" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where  MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() != "" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'   AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }


            else if (TextBox1.Text.Trim() != "" && DropDownList6.SelectedValue == "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'   AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() == "" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() != "" && DropDownList6.SelectedValue != "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

           
        }

         

         protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
         {
             string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
             SqlConnection conn = new SqlConnection(strconn);
             conn.Open();

              if (TextBox1.Text.Trim()=="" && DropDownList7.SelectedValue == "0"&& DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Semester='" + DropDownList6.SelectedItem.Text + "'", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue == "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue != "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "'  AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue != "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where  Semester='" + DropDownList6.SelectedItem.Text + "'  AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue != "0" && DropDownList8.SelectedValue == "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'   AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Semester='" + DropDownList6.SelectedItem.Text + "' ", conn);
                adp.Fill(dt);
                BindGrid();
            }


            else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue == "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'  AND Semester='" + DropDownList6.SelectedItem.Text + "'  AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue == "0"&& DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }

            else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue != "0" && DropDownList8.SelectedValue != "0")
            {
                dt.Clear();
                SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                adp.Fill(dt);
                BindGrid();
            }


         }

         protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
         {
             string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
             SqlConnection conn = new SqlConnection(strconn);
             conn.Open();

             if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue == "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where  Exam_Type='" + DropDownList8.SelectedItem.Text + "'", conn);
                 adp.Fill(dt);
                 BindGrid();
             }

             else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue == "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND  Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }

             else if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue == "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "'  AND  Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }

             else if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue != "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where  Semester='" + DropDownList6.SelectedItem.Text + "'  AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }

             else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue == "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'   AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND  Exam_Type='" + DropDownList8.SelectedItem.Text + "' ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }


             else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue == "0" && DropDownList6.SelectedValue != "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%'  AND Semester='" + DropDownList6.SelectedItem.Text + "'  AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }

             else if (TextBox1.Text.Trim() == "" && DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue != "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }

             else if (TextBox1.Text.Trim() != "" && DropDownList7.SelectedValue != "0" && DropDownList6.SelectedValue != "0")
             {
                 dt.Clear();
                 SqlDataAdapter adp = new SqlDataAdapter("select Seat_No,MnthYear,Semester,Exam_Type,Mod_Date from entries where Seat_No like'%" + TextBox1.Text + "%' AND Semester='" + DropDownList6.SelectedItem.Text + "' AND MnthYear='" + DropDownList7.SelectedItem.Text + "' AND Exam_Type='" + DropDownList8.SelectedItem.Text + "'  ", conn);
                 adp.Fill(dt);
                 BindGrid();
             }
         }

         protected void BindGrid()
         {


             if (dt.Rows.Count >= 0)
             {

                 GridView1.DataSource = dt;
                 GridView1.DataBind();
             }
             else
             {
                 Response.Write("<script>alert('No records found');</script>");
             }
         }

         protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
         {

             GridView1.EditIndex = e.NewEditIndex;
             BindData();
         }

         protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
         {
             GridView1.EditIndex = -1;
             BindData();
         }

         protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
         {

             string strconn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
             SqlConnection conn = new SqlConnection(strconn);
             conn.Open();

             string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString().Trim();
             string MonthYear = GridView1.DataKeys[e.RowIndex].Values[1].ToString().Trim();
             string sem = GridView1.DataKeys[e.RowIndex].Values[2].ToString().Trim();
             string type = GridView1.DataKeys[e.RowIndex].Values[3].ToString().Trim();
             string date = GridView1.DataKeys[e.RowIndex].Values[4].ToString();





             SqlCommand cmd = new SqlCommand("update entries set Seat_No=@seat,MnthYear=@session,Semester=@sem,Exam_Type=@exam,Mod_Date=@date where Seat_No='" + id + "' AND MnthYear='" + MonthYear + "' AND Semester='" + sem + "' AND Exam_Type='" + type + "' ", conn);

             cmd.Parameters.AddWithValue("@seat", (GridView1.Rows[e.RowIndex].FindControl("TxtSeat") as TextBox).Text.Trim());
             string str1 = (GridView1.Rows[e.RowIndex].FindControl("DropDownList9") as DropDownList).SelectedItem.Text;
             cmd.Parameters.AddWithValue("@session", str1);
             string str2 = (GridView1.Rows[e.RowIndex].FindControl("DropDownList10") as DropDownList).SelectedItem.Text;
             cmd.Parameters.AddWithValue("@sem", str2);
             string str3 = (GridView1.Rows[e.RowIndex].FindControl("DropDownList11") as DropDownList).SelectedItem.Text;
             cmd.Parameters.AddWithValue("@exam", str3);
             cmd.Parameters.AddWithValue("@date", (GridView1.Rows[e.RowIndex].FindControl("TxtDate") as TextBox).Text.Trim());
    
             cmd.ExecuteNonQuery();
             conn.Close();

             GridView1.EditIndex = -1;
             BindData();
             Response.Write("<script>alert('updated');</script>");



         }

         protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {

         }

        

        
    }
}
        


            


        
    
