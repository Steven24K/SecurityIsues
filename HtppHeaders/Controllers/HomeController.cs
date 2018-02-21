using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtppHeaders.Models;

namespace HtppHeaders.Controllers
{
    public class HomeController : Controller
    {
        private HeaderContext Context;
        public HomeController(HeaderContext context){
            this.Context = context;
        }
        public IActionResult Index()
        {
            //for(int i=0; i<4; i++)Response.Cookies.Append("Cookie" + i.ToString() ,i.ToString() );

            var CurrentAgent = Request.Headers.Where(h => h.Key == "User-Agent").First().Value;

            this.Context.HttpHeaders.Add(new HeaderStore{
                UserAgent = CurrentAgent
            });

            this.Context.SaveChanges();

            ViewData["counter"] = this.Context.HttpHeaders.Count();

            ViewData["currentAgentcounter"] = this.Context.HttpHeaders.Where(h => h.UserAgent == CurrentAgent).Count();

            ViewData["DetailHeaders"] = Request.Headers;


            ViewData["responseheaders"] = Response.Headers;

            return View();
        }

        public IActionResult About()
        {
            return View((from headers in this.Context.HttpHeaders orderby headers.RequestDate descending select headers).ToList());
        }

        public IActionResult Contact(string user = null)
        {             
            if(user != null){
                this.Context.HttpHeaders.Add(new HeaderStore{UserAgent = user});
                this.Context.SaveChanges();
                return RedirectToAction(nameof(About));
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
