using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace CurriculumDelivery
{
    class Email
    {
        public static void Send(string mailSender, string mailDestination,
                                string nameSender, string nameDestination,
                                string subject, string message,
                                string password, string filePath)
        {
            MailAddress origin = new MailAddress(mailSender, nameSender);
            MailAddress dest = new MailAddress(mailDestination, nameDestination);

            MailMessage mailMessage = new MailMessage(origin, dest);

            mailMessage.Subject = subject;
            mailMessage.Body = message;

            mailMessage.Attachments.Add(new Attachment(filePath));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential(origin.Address, password);

            try
            {
                smtp.Send(mailMessage);
                MessageBox.Show("Email Enviado com sucesso");
                Logger("Email Enviado com sucesso");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Logger("Erro ao tentar enviar Email", e);
            } //Tentativa de enviar Email
        }

        private static void Logger(string erro, Exception e)
        {
            string Line = e.StackTrace.Substring(e.StackTrace.IndexOf("linha"));
            Line = Line.Replace("linha ", "");

            erro += " - " + DateTime.Now.ToString();
            erro += "\n{\n" + e.Message + "\n" + "Line: " + Line + "\n}" + "\n\n";

            StreamWriter sw = File.AppendText("log.txt");
            sw.Write(erro);
            sw.Close();
        }

        private static void Logger(string concluido)
        {
            concluido += " - " + DateTime.Now.ToString() + "\n\n";

            StreamWriter sw = File.AppendText("log.txt");
            sw.Write(concluido);
            sw.Close();
        }
    }
}