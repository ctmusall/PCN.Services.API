using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    public class EmailsController : Controller
    {
        [HttpGet]
        public JsonResult GetAllEmails()
        {
            return new JsonResult(new List<object>
            {
                new {emailid = "0000000-000000", to = "clayton"},
                new {emailid = "0000000-000001", to = "jeff"}
            });
        }

    }
}