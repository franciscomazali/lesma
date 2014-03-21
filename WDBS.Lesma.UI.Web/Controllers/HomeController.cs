using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WDBS.Lesma.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EnviaEmail(string email, string nome, string mensagem)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetAllowResponseInBrowserHistory(false);

            //string email = form["email"];
            //string nome = form["nome"];
            //string mensagem = form["mensagem"];

            string msg = "";

            if (Helper.Email.EnviaEmail(nome, "Contato do site", MontaMensagemEmail(nome, email, mensagem), "lesma.selma@gmail.com"))
                msg = "Mensagem enviada com sucesso.";

            else
                msg = "Ops. Ocorreu um erro em nosso servidor. Por favor, tente outra vez mais tarde.";

            return Json(new { msg }, JsonRequestBehavior.AllowGet);
        }


        private string MontaMensagemEmail(string nome, string email, string mensagem)
        {
            StringBuilder body = new StringBuilder();

            body.AppendLine("<table>");
            body.AppendLine("<tr><td>Nome: </td><td>" + nome + "</td></tr>");
            body.AppendLine("<tr><td>E-mail: </td><td>" + email + "</td></tr>");
            body.AppendLine("<tr><td>Mensagem: </td><td>" + mensagem + "</td></tr>");
            body.AppendLine("<tr><td><br /></td></tr>");
            body.AppendLine("</table>");
            body.AppendLine("<p>**Este e-mail não deve ser respondido. Por favor, entre contato com o remetente desta mensagem em: " + email + " **</p>");

            return body.ToString();

        }

        [HttpPost]
        public JsonResult EnviaEmailEcomenda(string encomenda)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetAllowResponseInBrowserHistory(false);

            //string email = form["encomenda"];
            string msg = "";

            if (Helper.Email.EnviaEmail(encomenda, "Você tem uma nova encomenda!", MontaMensagemEncomenda(encomenda), "lesma.selma@gmail.com"))
                msg = "Encomenda realizada com sucesso.";

            else
                msg = "Ops. Ocorreu um erro em nosso servidor. Por favor, tente outra vez mais tarde.";

            return Json(new { msg }, JsonRequestBehavior.AllowGet);
        }


        private string MontaMensagemEncomenda(string email)
        {
            StringBuilder body = new StringBuilder();

            body.AppendLine("<h2>Você tem uma encomenda!</h2>");
            body.AppendLine("<table>");
            body.AppendLine("<tr><td>O remetente " + email + " gostaria de receber mais noticias sobre o livro. Por favor, entre em contato!</td></tr>");
            body.AppendLine("<tr><td><br /></td></tr>");
            body.AppendLine("</table>");
            body.AppendLine("<p>**Este e-mail não deve ser respondido.**</p>");

            return body.ToString();

        }
    }
}
