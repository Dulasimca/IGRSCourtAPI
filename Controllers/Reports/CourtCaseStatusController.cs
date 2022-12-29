using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Controllers.Reports
{
    [ApiController]
    public class CourtCaseStatusController : Controller
    {
        [HttpGet]
        [Route("api/[controller]/GetCourtCasetatus")]
        public IActionResult Get()
        {
            return View();
        }
    }
}
