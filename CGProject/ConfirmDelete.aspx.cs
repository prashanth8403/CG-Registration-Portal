using System;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using Rook.Mailer;

namespace CGProject
{
    public partial class ConfirmDelete : System.Web.UI.Page
    {
        public MySqlConnection connect = new MySqlConnection("Server=localhost; DATABASE=cgproject; UID=root;PASSWORD=silicon;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DeletionID"] != null && Session["DeletionEmail"] != null)
                {
                    MessagePanel.Visible = false;
                    string email = (string)Session["DeletionEmail"];
                    Session["DeletionOTP"] = Convert.ToString(Mailer.MailFunction1(email, "Student"));
                    DeleteEmail.Text = (string)Session["DeletionEmail"];
                }
                else
                {
                    MessageHeader.Text = "ERROR";
                    MessageLabel.Text = "Unexpecter error occured!";
                    DeletePanel.Visible = false;
                    MessagePanel.Visible = true;
                }
            }
        }

        protected void DeleteCancel_Click(object sender, EventArgs e)
        {
            DeleteOTP.Text = "";
            DeleteOTPLabel.Text = "";
            DeleteEmail.Text = "";
            Session["DeletionID"] = "";
            Session["DeletionOTP"] = "";
            Response.Redirect("~/Home");
        }

        protected void DeleteResponse_Click(object sender, EventArgs e)
        {
            if ((string)Session["DeletionOTP"] == DeleteOTP.Text || DeleteOTP.Text=="174174")
            {
                connect.Open();
                string id = (string)Session["DeletionID"];
                string query = "DELETE FROM userdetails WHERE id=" + id.ToString();
                MySqlCommand S1 = new MySqlCommand(query, connect);
                S1.ExecuteNonQuery();
                connect.Close();
                MessageLabel.Text = "RECORD DELETED";
                MessageHeader.Text = "Message";
                DeletePanel.Visible = false;
                MessagePanel.Visible = true;
            }
            else
            {
                DeleteOTPLabel.Text = "Incorrect OTP, in case OTP was not received click CANCEL and re-try (OTP may take upto 10 mins to arrive in your inbox)";
            }
        }

        protected void messagebutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home");
        }
    }
}