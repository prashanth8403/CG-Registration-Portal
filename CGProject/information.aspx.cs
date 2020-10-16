using System;
using MySql.Data.MySqlClient;
using System.Text;
using System.Security.Cryptography;


namespace CGProject
{
    public partial class information : System.Web.UI.Page
    {
        public MySqlConnection connect = new MySqlConnection("Server=localhost; DATABASE=cgproject; UID=root;PASSWORD=silicon;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                
                _intitaldataload();
        }

        public static string _hasher(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }


        private void _intitaldataload()
        {
            try
            {
                GridPanel.Visible = false;
                MessagePanel.Visible = false;
                connect.Open();
                string Query2 = "select count(*) from projects where flag=1";
                MySqlCommand SqlProcess2 = new MySqlCommand(Query2, connect);
                MySqlDataReader Reader = SqlProcess2.ExecuteReader();
                Reader.Read();
                int counts = Convert.ToInt32(Reader[0]);
                Reader.Close();
                if (counts > 0)
                {
                    GridPanel.Visible = true;
                    Reader.Close();
                    string Query1 = "select prefix,title,suffix,student1,student2,student3,section1,section2,section3 from userdetails,projects where flag=1 and userdetails.ID = projects.ID ;";
                    MySqlCommand SqlProcess1 = new MySqlCommand(Query1, connect);
                    printableTable.DataSource = SqlProcess1.ExecuteReader();
                    printableTable.DataBind();
                }
                else
                {
                    MessagePanel.Visible = true;
                    MessageHeader.Text = "ERROR";
                    MessageLabel.Text = "Currenty No Registration(s) found";
                }

            }
            catch (MySqlException sqle)
            {
                if (sqle.Message != "")
                {
                    MessagePanel.Visible = true;
                    MessageHeader.Text = "Data Error";
                    MessageLabel.Text = sqle.Message;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    MessagePanel.Visible = true;
                    MessageHeader.Text = "Unexpected Error";
                    MessageLabel.Text = "Unexpected System error occured! | "+ex.Message;
                }
            }
            finally
            {
                connect.Close();
            }
        }

        protected void printableTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = printableTable.SelectedRow.Cells[1].Text.ToString();
            Response.Redirect("information.aspx?reference=" + "1112" + "#" + id);
        }


        protected void _messagebutton_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            Response.Redirect("Home");
        }
       

        protected void printsilicon_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home");
        }
    }
}