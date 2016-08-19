using hoadtpd01419_assignment.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hoadtpd01419_assignment
{
    public partial class index : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                load();
            }
        }
        private void load() {
            GridView1.DataSource = kn.getData("select * from KhachHang");
            GridView1.DataBind();
        }
        private void koload()
        {
            GridView1.DataSource = kn.getData("select * from KhachHang");
            GridView1.DataBind();
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtMaKH = (TextBox)GridView1.FooterRow.FindControl("txtMaKH");
            TextBox txtTenKH = (TextBox)GridView1.FooterRow.FindControl("txtTenKH");
            TextBox txtDiaChi = (TextBox)GridView1.FooterRow.FindControl("txtDiaChi");
            TextBox txtSDT = (TextBox)GridView1.FooterRow.FindControl("txtSDT");
            TextBox txtEmail = (TextBox)GridView1.FooterRow.FindControl("txtEmail");
            string makhachhang = txtMaKH.Text;
            string tenkhachhang = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;


            if (txtMaKH.Text.ToString().Equals("")) {

                Response.Write("<script>alert('Mã khách hàng không được để trống!')</script>");

            }
            else if (txtTenKH.Text.ToString().Equals(""))
            {

                Response.Write("<script>alert('Tên khách hàng không được để trống!')</script>");

            }
            else if (txtDiaChi.Text.ToString().Equals(""))
            {

                Response.Write("<script>alert('Địa chỉ không được để trống!')</script>");

            }
            else if (txtSDT.Text.ToString().Equals(""))
            {

                Response.Write("<script>alert('số điện thoại không được để trống!')</script>");

            }
            else if (txtEmail.Text.ToString().Equals(""))
            {

                Response.Write("<script>alert('Địa ch không được để trống!')</script>");

            }

            else {
                int kq = kn.update("insert into KhachHang values('" + makhachhang + "','" + tenkhachhang + "','" + diachi + "','" + sdt + "','" + email + "')");
                if (kq > 0)
                {

                    load();
                    Response.Write("<script>alert('bạn thêm thành công!')</script>");


                }
                else {
                    Response.Write("<script>alert('bạn thêm không thành công!')</script>");
                }
            }
        } 

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string makhachhang = e.Values["MaKH"].ToString();
            int kq = kn.update("delete from KhachHang where MaKH = '" + makhachhang + "'");

            if (kq > 0)
            {
                load();
                Response.Write("<script>alert('bạn xóa thành công')</script>");


            }
            else {
                Response.Write("<script>alert('bạn xóa không thành công')</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            load();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            load();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string makhachhang = e.NewValues["MaKH"].ToString();
            string tenkhachhang = e.NewValues["TenKH"].ToString();
            string diachi = e.NewValues["DiaChi"].ToString();
            string sdt = e.NewValues["SDT"].ToString();
            string email = e.NewValues["Email"].ToString();

            int kq = kn.update("update KhachHang set MaKH='" + makhachhang 
                + "',TenKH='" + tenkhachhang 
                + "',DiaChi='"+diachi
                +"',SDT='" + sdt 
                + "',Email='" + email 
                + "' where MaKH='" + makhachhang + "'");

            if (kq > 0)
            {
                Response.Write("<script>alert('bạn sửa thành công')</script>");
                GridView1.EditIndex = -1;
                load();
            }
            else {
                Response.Write("<script>alert('bạn sửa không thành công')</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}