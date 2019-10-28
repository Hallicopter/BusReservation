using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace busproj
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (YourValidationFunction(Login1.UserName, Login1.Password))
            {
                // e.Authenticated = true;
                Response.Redirect("dashboard.aspx");
                Login1.Visible = false;
            }
            else
            {
                e.Authenticated = false;
            }
        }
        protected void Login1_LoginError(object sender, EventArgs e)
        {
            if (ViewState["LoginErrors"] == null)
                ViewState["LoginErrors"] = 0;
            int ErrorCount = (int)ViewState["LoginErrors"] + 1;
            ViewState["LoginErrors"] = ErrorCount;
            if ((ErrorCount > 3) && (Login1.PasswordRecoveryUrl != string.Empty))
                Response.Redirect(Login1.PasswordRecoveryUrl);
        }
        private bool YourValidationFunction(string UserName, string Password)
        {
            bool boolReturnValue = false;
            string strConnection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=BusData;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            String SQLQuery = "SELECT Username, Password, IsAdmin FROM Users";
            SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);
            SqlDataReader Dr;
            sqlConnection.Open();
            Dr = command.ExecuteReader();
            String tmp = "";
            while (Dr.Read())
            {
                tmp += Dr["Username"].ToString() + Dr["Password"].ToString();
                
                if ((UserName == Dr["Username"].ToString()) & (Password == Dr["Password"].ToString()))
                {
                    if (Dr["IsAdmin"].ToString() == "True")
                    {
                        Session["IsAdmin"] = "True";
                    }
                    else {
                        Session["IsAdmin"] = "False";
                    }
                    boolReturnValue = true;
                }
                if (boolReturnValue)
                {
                    Dr.Close();
                    return boolReturnValue;
                }
                //tmp += boolReturnValue.ToString();
                
                
            }
            return boolReturnValue;
        }
    }
}