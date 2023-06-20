using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace image_size_assignment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string q = "select * from image";
            SqlConnection cn = new SqlConnection(@"Data Source=Akku;Initial Catalog=Image;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter(q, cn);
            da.Fill(ds, "Emp");
            GridView1.DataSource = ds.Tables["emp"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                string strname = FileUpload1.FileName.ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/") + strname);
                string p = "~/img/" + FileUpload1.FileName;
                string q = "insert into image values('" + TextBox1.Text + "','" + p + "')";
                SqlConnection cn = new SqlConnection(@"Data Source=Akku;Initial Catalog=Image;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();

            }
        }
    }
}