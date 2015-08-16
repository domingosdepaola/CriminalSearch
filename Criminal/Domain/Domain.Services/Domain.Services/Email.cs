using Domain.Entity;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class Email
    {
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static bool SendEmail(List<Criminal> lstCriminal, string emailTo)
        {
            string message = FillMessage(lstCriminal);
            return SendEmail("Criminal Search Result", emailTo, message,true);
        }
        private static bool SendEmail(string subject, string to, string message,bool pdf)
        {
            try
            {
                
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("sitegerenciadoremail@gmail.com");
                //objEmail.ReplyTo = "";
                objEmail.To.Add(to);
                //objEmail.Bcc.Add("Email oculto");
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = subject;
                
                if (pdf)
                {
                    GenerateAttachment(message, objEmail);
                    objEmail.Body = " In attachment the results of your criminal search";
                }
                else 
                {
                    objEmail.Body = message;
                }
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.EnableSsl = true;
                objSmtp.Port = 587;
                objSmtp.Credentials = new NetworkCredential("criminalsearchcrossover@gmail.com", "crossover");
                objSmtp.Send(objEmail);

                return true;

            }
            catch (Exception ex)
            {
                log.Error(ex, ex.Message, null);
                return false;
            }
        }

        private static void GenerateAttachment(string message, MailMessage objEmail)
        {
            StringReader sr = new StringReader(message);

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                objEmail.Attachments.Add(new Attachment(new MemoryStream(bytes), "SearchResult.pdf"));
            }
        }
        private static String FillMessage(List<Criminal> lstCriminal)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (lstCriminal.Count > 0)
                {
                    foreach (Criminal item in lstCriminal)
                    {
                        sb.Append("<br/>-------------------------------------------<br/>");
                        sb.Append("Name : ");
                        sb.Append(item.Name);
                        sb.Append("<br/>");

                        sb.Append("Adress :");
                        sb.Append(item.Adress.Street);
                        sb.Append(" Number: ");
                        sb.Append(item.Adress.Number.Value.ToString());
                        sb.Append(" Complement: ");
                        sb.Append(item.Adress.Complement);
                        sb.Append("<br/>");
                        sb.Append("City :");
                        sb.Append(item.Adress.City.Description);
                        sb.Append(" State : ");
                        sb.Append(item.Adress.City.State.Description);
                        sb.Append("<br/>");
                        sb.Append("Country: ");
                        sb.Append(item.Adress.City.State.Country.Description);
                        sb.Append("<br/>");

                        sb.Append("Age: ");
                        sb.Append(item.Age.Value.ToString());
                        sb.Append("<br/>");

                        sb.Append("------------------------------------------------<br/>");
                        sb.Append(" History of ");
                        sb.Append(item.Name);
                        sb.Append(":<br/>");
                        sb.Append("------------------------------------------------<br/>");
                        if (item.CrimesHistory != null && item.CrimesHistory.Count > 0)
                        {
                            foreach (CrimesHistory history in item.CrimesHistory)
                            {
                                sb.Append("Crime Date: ");
                                sb.Append(history.Date.Value.ToString("MM/dd/yyyy HH:mm"));
                                sb.Append("<br/>");

                                sb.Append("Crime Type: ");
                                sb.Append(history.CrimeTypes.Description);
                                sb.Append("<br/>");

                                if (history.Adress != null)
                                {
                                    sb.Append("Crime Adress : ");
                                    sb.Append(history.Adress.Street);
                                    sb.Append(" Number: ");
                                    sb.Append(history.Adress.Number.Value.ToString());
                                    sb.Append(" Complement: ");
                                    sb.Append(history.Adress.Complement);
                                    sb.Append("<br/>");
                                    if (history.Adress.City != null)
                                    {
                                        sb.Append("City :");
                                        sb.Append(history.Adress.City.Description);

                                        if (history.Adress.City.State != null)
                                        {
                                            sb.Append(" State : ");
                                            sb.Append(history.Adress.City.State.Description);
                                            sb.Append("<br/>");
                                            if (history.Adress.City.State.Country != null)
                                            {
                                                sb.Append("Country: ");
                                                sb.Append(history.Adress.City.State.Country.Description);
                                                sb.Append("<br/>");
                                            }
                                        }
                                    }
                                }
                                sb.Append("------------------------------------------------<br/>");
                            }
                        }
                        else
                        {
                            sb.Append("No crimes");
                        }

                    }
                }
                else
                {
                    sb.Append("Your search doesnt have any results.");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex, ex.Message, null);
                return string.Empty;
            }
        }
    }
}
