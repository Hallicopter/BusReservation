using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace busproj
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((String)Session["IsAdmin"] == "True")
            {
                Label1.Text = "Welcome Admin!";
            }
            else
            {
                Label1.Text = "Welcome User!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string connectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=BusData;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * from BusDeets WHERE Source=@src AND Destination=@dst";
                    cmd.Parameters.AddWithValue("@src", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@dst", TextBox2.Text);
                    cmd.Connection = con;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    con.Open();
                    adapter.Fill(ds, "BusDeets");

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridView grid = sender as GridView;
            GridViewRow row = grid.Rows[index];

            String busId = row.FindControl("busid").ToString();
            Response.Write("<script> alert('" + busId + "') </script>"); 
        }
    }
}