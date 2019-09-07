using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace whydothis
{
    public partial class primarydetails : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            if (!IsPostBack)
            {
                BindInterests();
            }
        }

        protected void BindInterests()
        {
            SqlCommand sql = new SqlCommand("SELECT * FROM interests", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            CheckHobbies.DataSource = ds.Tables[0];
            CheckHobbies.DataTextField = "interest_name";
            CheckHobbies.DataValueField = "interest_id";
            CheckHobbies.DataBind();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            AddPrimaryInfo();
        }

        public Int32 AddPrimaryInfo()
        {
            SqlCommand sql = new SqlCommand("AddPrimary", connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@fname", TextFirstName.Text);
            sql.Parameters.AddWithValue("@lname", TextLastName.Text);
            sql.Parameters.AddWithValue("@age", TextAge.Text);
            if (RadioMale.Checked == true)
            {
                sql.Parameters.AddWithValue("@gender", "male");
            }
            else
            {
                sql.Parameters.AddWithValue("@gender", "female");
            }
            sql.Parameters.AddWithValue("@pan", TextPAN.Text);
            sql.Parameters.AddWithValue("@license", TextLicense.Text);
            sql.Parameters.AddWithValue("@phone", TextPhone.Text);
            sql.Parameters.Add("@temp_emp", SqlDbType.Int);
            sql.Parameters["@temp_emp"].Direction = ParameterDirection.Output;
            sql.ExecuteNonQuery();
            Int32 k = Convert.ToInt32(sql.Parameters["@temp_emp"].Value);
            sql.Dispose();
           
            foreach (ListItem item in CheckHobbies.Items)
            {
                if (item.Selected == true)
                {
                    SqlCommand command = new SqlCommand("AddInterests", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("emp_id", k);
                    command.Parameters.AddWithValue("@interest_id", item.Value);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
            }
            
            Response.Write("<script>alert('Success!')</script>");

            return k;
        }        
    }
}