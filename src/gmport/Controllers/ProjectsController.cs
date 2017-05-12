using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using gmport.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace gmport.Controllers
{
    public class ProjectsController : Controller
    {
       
        public IActionResult GetRepos()
        {
            var theRepos = ghreq.GetRepos();
            return View(theRepos);
        } 

    }
}
