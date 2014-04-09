using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WDBS.Lesma.UI.Web.Helper
{
    public class Email
    {
        public static bool EnviaEmail(string nome, string assunto, string mensagem, string destinatario = "lesma.selma@gmail.com")
        {
            //Define os dados do e-mail
            string nomeRemetente = "Contato Lesma";
            string emailRemetente = "no-reply@lesmaedicoes.com.br";
            string senha = "Gesualda29";

            //Host da porta SMTP
            string SMTP = "smtp.lesmaedicoes.com.br";

            string emailDestinatario = destinatario;

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(emailRemetente, "Lesma Edições" + " <" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailDestinatario);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assunto;

            //Define o corpo do e-mail.
            objEmail.Body = mensagem;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
            objSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                objSmtp.Send(objEmail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }

        }
    }
}