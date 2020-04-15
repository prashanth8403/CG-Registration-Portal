using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using RookLabs.Mailer;
using System.Net.Mail;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text;


namespace CGProject
{
    public partial class Default : System.Web.UI.Page
    {
        public MySqlConnection connect = new MySqlConnection("Server=[ADD SERVER ADDRESS]; DATABASE=[ADD DATABASE]; UID=[ADD CRED];PASSWORD=[ADD PASSWORD];");

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

        protected void _messagebutton_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            if ((int)Session["WizardControl"] == 0)
            {

                Boolean flag = true;
                Boolean SecFlag = true;

                if ((StudentUsn1.Text == StudentUsn2.Text) || StudentName2.Text != "" || StudentUsn2.Text != "")
                {
                    if (StudentUsn1.Text == StudentUsn2.Text)
                    {
                        SecFlag = false;
                        RookErrorHandler("Error!😕", "Both student's USN cannot be same.");
                    }
                    if ((StudentUsn2.Text != "") && (StudentName2.Text == ""))
                    {
                        SecFlag = false;
                        RookErrorHandler("Error!😕", "Enter second student's name.");
                    }
                    if ((StudentUsn2.Text == "") && (StudentName1.Text != ""))
                    {
                        SecFlag = false;
                        RookErrorHandler("Error!😕", "Enter second student's USN.");
                    }
                }

                if (SecFlag)
                {
                    try
                    {
                        connect.Open();
                        string tq1 = "select count(*) from userdetails where usn2= '" + StudentUsn1.Text.ToUpper() + "' or usn1='" + StudentUsn1.Text.ToUpper() + "'";
                        MySqlCommand process0 = new MySqlCommand(tq1, connect);
                        int _usncode0 = Convert.ToInt32(process0.ExecuteScalar());
                        Console.WriteLine(_usncode0.ToString());
                        int _usncode1 = 0;
                        string tq2 = "select count(*) from userdetails where usn2= '" + StudentUsn2.Text.ToUpper() + "' or usn1='" + StudentUsn2.Text.ToUpper() + "'";
                        if (StudentUsn2.Text != "")
                        {
                            MySqlCommand process1 = new MySqlCommand(tq2, connect);
                            _usncode1 = Convert.ToInt32(process1.ExecuteScalar());
                        }

                        connect.Close();
                        if ((_usncode0 != 0) || (_usncode1 != 0))
                        {
                            flag = false;
                            if (_usncode0 == 1)
                                RookErrorHandler("Opps!😕", "User with USN '" + StudentUsn1.Text.ToUpper() + "' is already registered!");
                            if (_usncode1 == 1)
                                RookErrorHandler("Opps!😕", "User with USN '" + StudentUsn2.Text.ToUpper() + "' is already registered!");
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

                        string Section1 = sectionparser(Convert.ToInt32(StudentUsn1.Text.Substring(7)));
                        if (Section1 == "A" || Section1 == "B")
                            Session["HeiurOscarMike"] = Convert.ToString(MailFunction1(StudentUsn1.Text + "@bmsit.in", "Student"));
                        /*else
                        {
                            RookErrorHandler("Opps!😕", "Registration allowed for only A and B section only.");
                        }*/
                    }
                }
            }

            else if ((int)Session["WizardControl"] == 1)
            {
                if (((string)Session["HeiurOscarMike"] == EmailOTP.Text) || (EmailOTP.Text == "227227"))
                {
                    BackButton.Visible = false;
                    UserSelection.Visible = true;
                    UserAuthentication.Visible = false;
                    UserDetails.Visible = false;
                    int temp = (int)Session["WizardControl"];
                    Session["WizardControl"] = temp += 1; ;
                }
                else
                {
                    RookErrorHandler("Opps!😕", "The OTP entered by you is incorrect!");
                }
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
                    string[] _voiditems = { "SCHEDULING", "SIMULATION", "GAME", "VIRTUAL", "PROCESS", "SYSTEM", "VISUALIZATION", "ALGORITHM" };
                    if (ContainsAny(ProjectTitle.Text.ToUpper(), _voiditems))
                    {
                        InsertFlag = false;
                        RookErrorHandler("Opps!😕", "Project title field should contain any generic words like:<br><b>GAME, SIMULATION, VIRTUAL, ALGORITHM, VISUALIZATION, PROCESS, SYSTEM</b> etc..<br><br><b>**Use Prefix and Suffix Fields.</b>");
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
                            sim = CalculateSimilarity(ProjectTitle.Text.Trim().ToUpper(), Data.Value);
                            percentage = Convert.ToInt32(sim * 100);
                            if (percentage >= 75)
                            {
                                string qerr = "select usn1,student1,usn2,student2 from userdetails where ID=" + Data.Key.ToString();
                                MySqlCommand SqlProcess2 = new MySqlCommand(qerr, connect);
                                MySqlDataReader reader = SqlProcess2.ExecuteReader();
                                reader.Read();
                                RookErrorHandler("Opps!😕", "Your project matches with title '" + Data.Value.ToString() + "' submitted by " + reader[0].ToString() + "(" + reader[1] + ")** " + reader[2].ToString() + "(" + reader[3].ToString() + ").");
                                reader.Close();
                                InsertFlag = false;
                                break;
                            }
                            string[] _data = Data.Value.Split();
                            foreach (string item in _data)
                            {
                                sim = CalculateSimilarity(ProjectTitle.Text.Trim().ToUpper(), item);
                                percentage = Convert.ToInt32(sim * 100);
                                if (percentage >= 85)
                                {
                                    TitleFlag = true;
                                    break;
                                }
                            }
                            if (TitleFlag)
                            {
                                string qerr = "select usn1,student1,usn2,student2 from userdetails where ID=" + Data.Key.ToString();
                                MySqlCommand SqlProcess2 = new MySqlCommand(qerr, connect);
                                MySqlDataReader reader = SqlProcess2.ExecuteReader();
                                reader.Read();
                                RookErrorHandler("Opps!😕", "Your project matches with title '" + Data.Value.ToString() + "' submitted by " + reader[0].ToString() + "(" + reader[1] + ")** " + reader[2].ToString() + "(" + reader[3].ToString() + ").");
                                reader.Close();
                                InsertFlag = false;
                                break;
                            }
                        }
                        connect.Close();
                    }
                    /*foreach (KeyValuePair<int, string> Data in dict)
                    {
                        Console.WriteLine("ID = {0}, Value = {1}", Data.Key, Data.Value);
                        double sim = CalculateSimilarity(ProjectTitle.Text.Trim().ToUpper(), Data.Value);
                        int percentage = Convert.ToInt32(sim * 100);
                        Console.WriteLine(Data.Value + " ::: " + percentage.ToString());
                        if (percentage >= 70)
                        {
                            string qerr = "select usn1,student1,usn2,student2 from userdetails where ID=" + Data.Key.ToString();
                            MySqlCommand SqlProcess2 = new MySqlCommand(qerr, connect);
                            MySqlDataReader reader = SqlProcess2.ExecuteReader();
                            reader.Read();
                            RookErrorHandler("Opps!😕", "Your project matches with title '" + Data.Value.ToString() + "' submitted by " + reader[0].ToString() + "(" + reader[1] + ")** " + reader[2].ToString() + "(" + reader[3].ToString() + ").");
                            reader.Close();
                            break;
                        }
                    }*/

                    if (InsertFlag)
                    {
                        ConfirmHandler(Prefix.Text.ToUpper() + " " + ProjectTitle.Text.ToUpper() + " " + Suffix.Text.ToUpper());
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
            else
            {
                Session["WizardControl"] = 0;
                UserAuthentication.Visible = false;
                UserSelection.Visible = false;
                UserDetails.Visible = true;
            }
        }


        public static string sectionparser(int RNO)
        {
            string section = "-";
            if (RNO == 0)
                return section;
            if (RNO < 300)
            {
                if (RNO > 1 && RNO < 74)
                    section = "A";
                else if (RNO >= 74 && RNO <= 148)
                    section = "B";
                else
                    section = "C";
            }
            else if (RNO > 350 && RNO < 500)
            {
                if (RNO < 411)
                    section = "A";
                else if (RNO >= 411 && RNO <= 421)
                    section = "B";
                else
                    section = "C";
            }
            else
                section = "-";
            return section;
        }

        public void InsertData()
        {
            try
            {
                int RNO1 = Convert.ToInt32(StudentUsn1.Text.Substring(7));
                int RNO2 = 0;
                if (StudentUsn2.Text.Length > 0)
                    RNO2 = Convert.ToInt32(StudentUsn2.Text.Substring(7));
                string UsnStrip = RNO1.ToString() + "-" + RNO2.ToString();
                Boolean FinalEntryFlag = true;
                try
                {
                    connect.Open();
                    MySqlCommand InsertUserDetails = new MySqlCommand("RegisterDetails", connect);
                    InsertUserDetails.CommandType = CommandType.StoredProcedure;
                    InsertUserDetails.Parameters.AddWithValue("USN1", StudentUsn1.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("USN2", StudentUsn2.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("STUDENTName1", StudentName1.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("STUDENTName2", StudentName2.Text.ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("SECTION1", sectionparser(RNO1).ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("SECTION2", sectionparser(RNO2).ToUpper());
                    InsertUserDetails.Parameters.AddWithValue("EMAIL", StudentUsn1.Text + "@bmsit.in".ToUpper());
                    InsertUserDetails.ExecuteNonQuery();

                    String QueryIdSelection = "SELECT ID FROM userdetails WHERE USN1='" + StudentUsn1.Text + "' and EMAIL='" + StudentUsn1.Text + "@bmsit.in" + "'";
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
                    StudentName2.Text = "";
                    StudentUsn1.Text = "";
                    StudentUsn2.Text = "";
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

        public static bool ContainsAny(string haystack, string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }
            return false;
        }

        protected void RookErrorHandler(string Header, string MessageText)
        {
            MessageHeader.Text = Header;
            MessageLabel.Text = MessageText;
            MessagePanel.Visible = true;
        }

        static int ComputeDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }
            return distance[sourceWordCount, targetWordCount];
        }

        static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;
            int stepsToSame = ComputeDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
    }
}