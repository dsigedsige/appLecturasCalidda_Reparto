using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaliddaReparto.Web.Controllers
{
    public class ControlPreventivoController : Controller
    {
        //
        // GET: /ControlPreventivo/

        public ActionResult control_index()
        {
            return View();
        }
        public ActionResult controlMasivo_index()
        {
            return View();
        }

    }
}
