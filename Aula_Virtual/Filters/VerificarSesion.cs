using Aula_Virtual.Controllers;
using Aula_Virtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_Virtual.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        private usuarios oUsuarios;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);

                oUsuarios = (usuarios)HttpContext.Current.Session["User"];
                if (oUsuarios == null)
                {
                    if (filterContext.Controller is AccesoController == false )
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }

                }
            }
            catch (Exception )
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
                
            }
           
        }
    }
}