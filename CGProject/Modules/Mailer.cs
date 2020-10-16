using System;
using System.Net.Mail;
using System.Text;

namespace Rook.Mailer
{
    public class Mailer
    {
        public static string mailstruct(string name, int _otp)
        {
            StringBuilder MailBody = new StringBuilder();
            MailBody.Append("<div align=center>");
            MailBody.Append("    <table style=\"width:520px; background-color:#CCCCCC;\">");
            MailBody.Append("        <tr>");//margin-left:3%; margin-right:3%;
            MailBody.Append("            <td style=\"height:200px;background-size:100%; background-image:url(http://rooklabs.epizy.com/mail_cloud.png); background-repeat: no-repeat;\">");
            MailBody.Append("                <div style=\"margin-top:150px; padding:10px; background-color:#fff; \">");
            MailBody.Append("                    <div>");
            // MailBody.Append("                        <img style=\"margin-top:10px;\" src=\"https://bmsit.ac.in/assets/logo-5527329e306f832982eb5b10b8325a606bc2058ae61b4aa5705c8c2d4e436212.png\" height=\"60\" />");
            // MailBody.Append("                        <a style=\"margin-left:10px;  font-size:25px; font-family:Arial; font-weight:600; color:#606060\" ;>BMSIT & M</a>");
            MailBody.Append("                    </div>");
            MailBody.Append("                    <p>");
            MailBody.Append("                        <span style=\"font-size:14px; text-align:justify; font-family:Roboto;\">");
            MailBody.Append("                            <br>");
            MailBody.Append("                            Dear  " + name + ",");
            MailBody.Append("                            <br>");
            MailBody.Append("                            Your One Time Password (OTP) for Project registration is <a style=\"font-weight:600\">" + _otp + "</a>");
            MailBody.Append("                            <br /> <br />");
            MailBody.Append("                            The OTP is valid for 10 mins or one successful attempt, whichever is earlier. Please");
            MailBody.Append("                            do not share with anyone.");
            MailBody.Append("                            <br>");
            MailBody.Append("                            <br>");
            MailBody.Append("                            Warm regards, <br>");
            MailBody.Append("                            ROOK LABS");
            MailBody.Append("                            <br>");
            MailBody.Append("                        </span>");
            MailBody.Append("                    </p>");
            MailBody.Append("");
            MailBody.Append("                </div>");
            MailBody.Append("");
            MailBody.Append("            </td>");
            MailBody.Append("        </tr>");
            MailBody.Append("");
            MailBody.Append("");
            MailBody.Append("        <tr>");
            MailBody.Append("            <td>");
            MailBody.Append("                <p style=\"text-align:justify; color:#808080; font-size:10px;font-family:Arial; padding-top:10px; padding-bottom:10px; padding-left:5%; padding-right:5%;\">");
            MailBody.Append("                    This e-mail is addressed to and intended only for BMSIT&M and it is not spam.");
            MailBody.Append("                    You may contact BMSIT&M to clarify any issues that you may have in");
            MailBody.Append("                    regard to any information contained in this email. If you are not the intended client kindly delete this mail. *Please do not reply to");
            MailBody.Append("                    this mail as it is a computer generated mail. <br>");
            MailBody.Append("                </p>");
            MailBody.Append("            </td>");
            MailBody.Append("        </tr>");
            MailBody.Append("    </table>");
            MailBody.Append("</div>");
            return MailBody.ToString();
        }

        public static int MailFunction1(string _mailadd, string _name)
        {
            Random _intt = new Random();
            int _otp = _intt.Next(100000, 999999);
            MailMessage _mail = new MailMessage();
            _mail.To.Add(_mailadd);
            _mail.Body = mailstruct(_name, _otp);
            _mail.Subject = "ONE TIME PASSWORD(OTP) - ROOK LABS SENT AT:: " + DateTime.Now.ToString("h:mm:ss tt");
            _mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            try
            {
                _mail.From = new MailAddress("prashanth_kumar@gmx.com");
                smtp.Host = "mail.gmx.com";
                string u = "<username>", v = "<password>";
                smtp.Credentials = new System.Net.NetworkCredential(u, v);
                smtp.EnableSsl = true;
                smtp.Send(_mail);
            }
            catch (Exception MX2)
            {
                if (MX2.Message != "")
                    _otp = MailFunction2(_mailadd, _name);
            }
            return _otp;
        }

        public static int MailFunction2(string _mailadd, string _name)
        {
            Random _intt = new Random();
            int _otp = _intt.Next(100000, 999999);
            MailMessage _mail = new MailMessage();
            _mail.To.Add(_mailadd);
            _mail.Body = mailstruct(_name, _otp);
            _mail.Subject = " BMSIT: ONE TIME PASSWORD(OTP) - ROOK LABS SENT AT:: " + DateTime.Now.ToString("h:mm:ss tt");
            _mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            try
            {
                _mail.From = new MailAddress("bmsit@gmx.com");
                smtp.Host = "mail.gmx.com";
                string u = "<username>", v = "<password>";
                smtp.Credentials = new System.Net.NetworkCredential(u, v);
                smtp.EnableSsl = true;
                smtp.Send(_mail);
            }
            catch (Exception MX2)
            {

            }
            return _otp;
        }
    }
}