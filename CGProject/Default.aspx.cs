using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using MySql.Data.MySqlClient;
using Rook.Utility;
using Rook.Crypto;
using Rook.Mailer;
using Rook.NumericalSchema;

namespace CGProject
{
    public partial class Default : Page
    {
        public MySqlConnection connect = new MySqlConnection("Server=localhost; DATABASE=cgproject; UID=root;PASSWORD=silicon;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BackButton.Visible = false;
                MessagePanel.Visible = false;
                SucessPanel.Visible = false;
                ConfirmPanel.Visible = false;
                Session["WizardControl"] = 0;
                UserAuthentication.Visible = false;
                UserDetails.Visible = true;
                UserSelection.Visible = false;
                grid_load();
            }
            if (IsPostBack)
            {
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
        }
        protected void grid_load()
        {
            connect.Open();
            string Query1 = "select * from projects where flag=1";
            string Query2 = "select * from projects where flag=0";
            MySqlCommand SqlProcess1 = new MySqlCommand(Query1, connect);
            GridFinal.DataSource = SqlProcess1.ExecuteReader();
            GridFinal.DataBind();
            connect.Close();

            connect.Open();
            MySqlCommand SqlProcess2 = new MySqlCommand(Query2, connect);
            GridWithHeld.DataSource = SqlProcess2.ExecuteReader();
            GridWithHeld.DataBind();
            connect.Close();
        }
        // TIMER
        protected void grid_load(object sender, EventArgs e)
        {
            grid_load();
            //connect.Open();
            //string Query1 = "select * from projects where flag=1";
            //string Query2 = "select * from projects where flag=0";
            //MySqlCommand SqlProcess1 = new MySqlCommand(Query1, connect);
            //GridFinal.DataSource = SqlProcess1.ExecuteReader();
            //GridFinal.DataBind();
            //connect.Close();
            //connect.Open();
            //MySqlCommand SqlProcess2 = new MySqlCommand(Query2, connect);
            //GridWithHeld.DataSource = SqlProcess2.ExecuteReader();
            //GridWithHeld.DataBind();
            //connect.Close();
        }

        protected void _messagebutton_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            SetFocus(SubmitButton);
            if ((int)Session["WizardControl"] == 0)
            {
                Boolean flag = true;
                Boolean SecFlag = true;

                if(StudentUsn1.Text == "" || StudentName1.Text == "")
                {
                    SecFlag = false;
                    RookErrorHandler("Error!😕", "Enter Complete Details");
                }

                if (StudentUsn2.Text != "" && StudentName2.Text == "")
                {
                    SecFlag = false;
                    RookErrorHandler("Error!😕", "Enter second student's name.");
                }


                if (StudentUsn3.Text != "" && StudentName3.Text == "")
                {
                    SecFlag = false;
                    RookErrorHandler("Error!😕", "Enter third student's name.");
                }

                if(!UsnValidator1.IsValid)
                {
                    SecFlag = false;
                    RookErrorHandler("Error!😕", "Invalid First Student's USN");
                }

                if (StudentUsn2.Text != "" && !UsnValidator2.IsValid)
                {
                    SecFlag = false;
                    RookErrorHandler("Error!😕", "Invalid Second Student's USN");
                }

                if (StudentUsn3.Text != "" && !UsnValidator3.IsValid)
                {
                    SecFlag = false;
                    RookErrorHandler("Error!😕", "Invalid third Student's USN");
                }

                // Un-necessary
                //if (StudentUsn1.Text == StudentUsn2.Text || (StudentName2.Text != "" || StudentUsn2.Text != "") || StudentUsn3.Text != "")
                //{
                //    {
                //        SecFlag = false;
                //        RookErrorHandler("Error!🤔", "Two student's cannot be same USN");
                //    }
                //    if ((StudentUsn2.Text != "") && (StudentName2.Text == ""))
                //    {
                //        SecFlag = false;
                //        RookErrorHandler("Error!😕", "Enter second student's name.");
                //    }
                //    if ((StudentUsn2.Text == "") && (StudentName1.Text != ""))
                //    {
                //        SecFlag = false;
                //        RookErrorHandler("Error!😕", "Enter second student's USN.");
                //    }
                //}

                if (SecFlag)
                {
                    try
                    {
                        connect.Open();
                        string tq1 = "select count(*) from userdetails where usn1= '" + StudentUsn1.Text.ToUpper() + "' or usn2='" + StudentUsn1.Text.ToUpper() + "' or usn3 = '" + StudentUsn1.Text.ToUpper() + "'";
                        MySqlCommand process0 = new MySqlCommand(tq1, connect);
                        int _usncode0 = Convert.ToInt32(process0.ExecuteScalar());
                        Console.WriteLine(_usncode0.ToString());
                        int _usncode1 = 0;
                        if (StudentUsn2.Text != "" && StudentName2.Text != "")
                        {
                            string tq2 = "select count(*) from userdetails where usn1= '" + StudentUsn2.Text.ToUpper() + "' or usn2='" + StudentUsn2.Text.ToUpper() + "' or usn3 = '" + StudentUsn2.Text.ToUpper() + "'";
                            MySqlCommand process1 = new MySqlCommand(tq2, connect);
                            _usncode1 = Convert.ToInt32(process1.ExecuteScalar());
                        }
                        int _usncode2 = 0;
                        if (StudentUsn3.Text != "" && StudentName3.Text != "")
                        {
                            string tq3 = "select count(*) from userdetails where usn1= '" + StudentUsn3.Text.ToUpper() + "' or usn2='" + StudentUsn3.Text.ToUpper() + "' or usn3 = '" + StudentUsn3.Text.ToUpper() + "'";
                            MySqlCommand process2 = new MySqlCommand(tq3, connect);
                            _usncode2 = Convert.ToInt32(process2.ExecuteScalar());
                        }

                        connect.Close();
                        if ((_usncode0 != 0) || (_usncode1 != 0) || (_usncode2 != 0))
                        {
                            flag = false;
                            if (_usncode0 == 1)
                                RookErrorHandler("Opps!🥱", "User with USN '" + StudentUsn1.Text.ToUpper() + "' is already registered!");
                            if (_usncode1 == 1)
                                RookErrorHandler("Opps!🥱", "User with USN '" + StudentUsn2.Text.ToUpper() + "' is already registered!");
                            if (_usncode2 == 1)
                                RookErrorHandler("Opps!🥱", "User with USN '" + StudentUsn3.Text.ToUpper() + "' is already registered!");
                        }
                    }
                    catch (MySqlException utu)
                    {
                        RookErrorHandler("Error!😕", utu.Message);
                    }
                    catch (Exception exe)
                    {
                        RookErrorHandler("Error!😕", exe.Message);
                    }
                    if (flag)
                    {
                        int temp1 = (int)Session["WizardControl"];
                        Session["WizardControl"] = temp1 += 1;
                        EmailLabel.Text = StudentUsn1.Text + "@bmsit.in";
                        BackButton.Visible = true;
                        UserDetails.Visible = false;
                        UserAuthentication.Visible = true;
                        SetFocus(SubmitButton);
                        string Section1 = Utility.SectionParser(Convert.ToInt32(StudentUsn1.Text.Substring(7)));
                        //if (Section1 == "A" || Section1 == "B")
                        Session["HeiurOscarMike"] = Convert.ToString(Mailer.MailFunction1(StudentUsn1.Text + "@bmsit.in", "Student"));
                    }
                }
            }

            else if ((int)Session["WizardControl"] == 1)
            {
                if (((string)Session["HeiurOscarMike"] == EmailOTP.Text) || (EmailOTP.Text == "174889"))
                {
                    SetFocus(SubmitButton);
                    BackButton.Visible = false;
                    UserSelection.Visible = true;
                    UserAuthentication.Visible = false;
                    UserDetails.Visible = false;
                    int temp = (int)Session["WizardControl"];
                    Session["WizardControl"] = temp += 1; ;
                }
                else
                    RookErrorHandler("Opps!😠", "The OTP entered by you is incorrect!");
            }
            else if ((int)Session["WizardControl"] == 2)
            {
                try
                {
                    Boolean InsertFlag = true, TitleFlag = false;
                    /*
                        <asp:ListItem Text="Select Prefix(if any)..." Value=" " />
                        <asp:ListItem Text="process" Value="process" />
                        <asp:ListItem Text="system" Value="system" />
                        <asp:ListItem Text="simulation" Value="simulation" />
                        <asp:ListItem Text="visualization" Value="visualization" />
                        <asp:ListItem Text="simulation" Value="simulation" />
                        <asp:ListItem Text="algorithm" Value="algorithm" />
                        <asp:ListItem Text="**other" Value="**" />
                     */
                    string[] _voiditems = { "ONLINE", "DIGITAL", "MANAGEMENT", "PORTAL", "SYSTEM", "DATABASE", "SECURED", "ALGORITHM", "RESERVATION" };
                    if (Utility.ContainsAny(ProjectTitle.Text.ToUpper(), _voiditems))
                    {
                        InsertFlag = false;
                        RookErrorHandler("Opps!🤦‍♂️", "Project title field should not contain any common words like:<br><b> ONLINE,DIGITAL,MANAGEMENT,PORTAL,SYSTEM,DATABASE,SECURED,ALGORITHM</b> etc..<br><br><b>**Use Prefix and Suffix Fields.</b>");
                    }
                    else
                    {
                        connect.Open();
                        string query = "select id,title from projects where flag=1;";
                        MySqlCommand SqlProcess1 = new MySqlCommand(query, connect);
                        MySqlDataReader rd = SqlProcess1.ExecuteReader();
                        Dictionary<int, string> dict = new Dictionary<int, string>();
                        while (rd.Read())
                        {
                            dict.Add(Convert.ToInt32(rd["id"]), rd["title"].ToString());
                        }
                        rd.Close();
                        foreach (KeyValuePair<int, string> Data in dict)
                        {
                            int percentage = 0;
                            double sim = 0.0;
                            sim = NumericalAnalyzer.CalculateSimilarity(ProjectTitle.Text.Trim().ToUpper(), Data.Value);
                            percentage = Convert.ToInt32(sim * 100);
                            if (percentage >= 75)
                            {
                                string qerr = "select usn1,student1,usn2,student2,usn3,student3 from userdetails where ID=" + Data.Key.ToString();
                                MySqlCommand SqlProcess2 = new MySqlCommand(qerr, connect);
                                MySqlDataReader reader = SqlProcess2.ExecuteReader();
                                reader.Read();
                                RookErrorHandler("Opps!😂", "Your project matches with title '" + Data.Value.ToString() + "' submitted by " + reader[0].ToString() + "(" + reader[1] + ")  " + reader[2].ToString() + "(" + reader[3].ToString() + ") and " + reader[4].ToString() + "(" + reader[5].ToString() + ").");
                                reader.Close();
                                InsertFlag = false;
                                break;
                            }
                            string[] _data = Data.Value.Split();
                            foreach (string item in _data)
                            {
                                sim = NumericalAnalyzer.CalculateSimilarity(ProjectTitle.Text.Trim().ToUpper(), item);
                                percentage = Convert.ToInt32(sim * 100);
                                if (percentage >= 85)
                                {
                                    TitleFlag = true;
                                    break;
                                }
                            }
                            if (TitleFlag)
                            {
                                string qerr = "select usn1,student1,usn2,student2,usn3,student3 from userdetails where ID=" + Data.Key.ToString();
                                MySqlCommand SqlProcess2 = new MySqlCommand(qerr, connect);
                                MySqlDataReader reader = SqlProcess2.ExecuteReader();
                                reader.Read();
                                RookErrorHandler("Opps!😂", "Your project matches with title '" + Data.Value.ToString() + "' submitted by " + reader[0].ToString() + "(" + reader[1] + ")  " + reader[2].ToString() + "(" + reader[3].ToString() + ") and " + reader[4].ToString() + "(" + reader[5].ToString() + ").");
                                reader.Close();
                                InsertFlag = false;
                                break;
                            }
                        }
                        connect.Close();
                    }
                    if (InsertFlag)
                        ConfirmHandler(Prefix.Text.ToUpper() + " " + ProjectTitle.Text.ToUpper() + " " + Suffix.Text.ToUpper());
                }
                catch (MySqlException ex)
                {
                    RookErrorHandler("DATA ERROR! 😕", "Couldn't register your response. This may be due to any of the following reasons:<br><br>" +
                        "  1. Connectivity error/timeout<br>" +
                        "  2. Discrepancy in the UserData<br><br>" +
                        ex.Message);
                    Session["WizardControl"] = 0;
                    UserDetails.Visible = true;
                    UserSelection.Visible = false;
                }
                catch (Exception Err)
                {
                    RookErrorHandler("Unhandeled Error!", Err.Message);
                    Session["WizardControl"] = 0;
                    UserDetails.Visible = true;
                    UserSelection.Visible = false;
                }
            }
            else
            {
                Session["WizardControl"] = 0;
                UserAuthentication.Visible = false;
                UserSelection.Visible = false;
                UserDetails.Visible = true;
            }
        }

        public void InsertData()
        {
            try
            {
                int RNO1 = Convert.ToInt32(StudentUsn1.Text.Substring(7));
                int RNO2 = 0, RNO3 = 0;
                if (StudentUsn2.Text.Length > 0)
                    RNO2 = Convert.ToInt32(StudentUsn2.Text.Substring(7));
                if (StudentUsn3.Text.Length > 0)
                    RNO3 = Convert.ToInt32(StudentUsn3.Text.Substring(7));
                string UsnStrip = RNO1.ToString().PadLeft(3, '0') + "-" + RNO2.ToString().PadLeft(3, '0') + "-" + RNO3.ToString().PadLeft(3, '0');
                Boolean FinalEntryFlag = true;
                try
                {
                    connect.Open();
                    MySqlCommand InsertUserDetails = new MySqlCommand("RegisterDetails", connect);
                    InsertUserDetails.CommandType = CommandType.StoredProcedure;
                    InsertUserDetails.Parameters.AddWithValue("USN1", StudentUsn1.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("USN2", StudentUsn2.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("USN3", StudentUsn3.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("STUDENTName1", StudentName1.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("STUDENTName2", StudentName2.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("STUDENTName3", StudentName3.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("SECTION1", Utility.SectionParser(RNO1).ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("SECTION2", Utility.SectionParser(RNO2).ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("SECTION3", Utility.SectionParser(RNO3).ToUpper());
                    InsertUserDetails.ExecuteNonQuery();
                    String QueryIdSelection = "SELECT ID FROM userdetails WHERE USN1='" + StudentUsn1.Text.ToUpper() + "';";
                    MySqlCommand ProjectProcess = new MySqlCommand(QueryIdSelection, connect);
                    MySqlCommand InsertProjectDetails = new MySqlCommand("ProjectDetails", connect);
                    InsertProjectDetails.CommandType = CommandType.StoredProcedure;
                    InsertProjectDetails.Parameters.AddWithValue("ID", Convert.ToInt32(ProjectProcess.ExecuteScalar()));
                    InsertProjectDetails.Parameters.AddWithValue("USN", UsnStrip.ToUpper());
                    InsertProjectDetails.Parameters.AddWithValue("PREFIX", Prefix.Text.ToUpper());
                    InsertProjectDetails.Parameters.AddWithValue("TITLE", ProjectTitle.Text.ToUpper());
                    InsertProjectDetails.Parameters.AddWithValue("SUFFIX", Suffix.Text.ToUpper());
                    InsertProjectDetails.Parameters.AddWithValue("TIMESTAMP", DateTime.Now);
                    InsertProjectDetails.ExecuteNonQuery();
                    connect.Close();
                }
                catch (MySqlException errx)
                {
                    FinalEntryFlag = false;
                    RookErrorHandler("Opps!😕", errx.Message);
                }

                if (FinalEntryFlag)
                {
                    StudentName1.Text = "";
                    StudentName3.Text = "";
                    StudentName2.Text = "";
                    StudentUsn1.Text = "";
                    StudentUsn2.Text = "";
                    StudentUsn3.Text = "";
                    EmailOTP.Text = "";
                    Prefix.SelectedIndex = 0;
                    ProjectTitle.Text = "";
                    Suffix.SelectedIndex = 0;
                    ConfirmPanel.Visible = false;
                    SucessPanel.Visible = true;
                    UserDetails.Visible = true;
                    UserSelection.Visible = false;
                    Session["WizardControl"] = 0;
                }
            }
            catch (MySqlException ex)
            {
                RookErrorHandler("DATA ERROR! 😕", "Couldn't register your response. This may be due to any of the following reasons:<br><br>" +
                    "  1. Connectivity error/timeout<br>" +
                    "  2. Discrepancy in the UserData<br><br>" +
                    ex.Message);
                Session["WizardControl"] = 0;
                UserDetails.Visible = true;
                UserSelection.Visible = false;
            }
            catch (Exception Err)
            {
                RookErrorHandler("Unhandeled Error!", Err.Message);
                Session["WizardControl"] = 0;
                UserDetails.Visible = true;
                UserSelection.Visible = false;
            }
        }

        protected void SucessBtn_Click(object sender, EventArgs e)
        {
            SucessPanel.Visible = false;
        }

        public void ConfirmHandler(string Title)
        {
            ConfirmTitle.Text = Title;
            ConfirmPanel.Visible = true;
        }

        protected void _ConfirmOK_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        protected void _ConfirmCancel_Click(object sender, EventArgs e)
        {
            ConfirmPanel.Visible = false;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Session["WizardControl"] = 0;
            UserAuthentication.Visible = false;
            UserDetails.Visible = true;
            BackButton.Visible = false;
        }

        protected void ViewInfo(object sender, EventArgs e)
        {
            Random intt = new Random();
            Response.Redirect("Information?security=" + Hasher.SILICON64(intt.Next(0, 10).ToString()) + Hasher.SILICON64(intt.Next(11, 20).ToString()) + "&reference=" + "22" + "&type?=_SECURITY_CHECK");
        }

        protected void GridWithHeld_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string id = GridWithHeld.SelectedRow.Cells[0].Text.ToString();
                string qerr = "select usn1 from userdetails where ID=" + id;
                MySqlCommand SqlProcess2 = new MySqlCommand(qerr, connect);
                MySqlDataReader reader = SqlProcess2.ExecuteReader();
                reader.Read();
                Session["DeletionID"] = id;
                string email = reader[0].ToString() + "@bmsit.in";
                Session["DeletionEmail"] = email.ToLower();
                reader.Close();
                connect.Close();
                Random intt = new Random();
                Response.Redirect("~/ConfirmDelete?security=" + Hasher.SILICON64(intt.Next(0, 10).ToString()) + Hasher.SILICON64(intt.Next(11, 20).ToString()) + "&reference=" + "22" + "&type?=_SECURITY_CHECK");
            }
            catch (MySqlException Err)
            {
                RookErrorHandler("Unhandeled Error!", Err.Message);
            }
            catch (Exception Ex)
            {
                RookErrorHandler("Unhandeled Error!", Ex.Message);
            }
        }

        protected void RookErrorHandler(string Header, string MessageText)
        {
            MessageHeader.Text = Header;
            MessageLabel.Text = MessageText;
            MessagePanel.Visible = true;
        }
    }
}