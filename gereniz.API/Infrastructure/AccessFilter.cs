using System;
using System.Linq;
using gereniz.Database.Entities;
using gereniz.Database.Entities.DomainContext;
using gereniz.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace gereniz.API.Infrastructure
{
    public class AccessFilter : Attribute ,IActionFilter
    {
        private string _user;

        public AccessFilter(String user)
        {
            _user = user;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //kullanıcı Admin ise Product bilgilerine ait Product/Index sayfasına yönlendir.
            if (_user == "Admin")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Product", Action = "Add" }));
                return;
            }
            return;
        }
    }
}
