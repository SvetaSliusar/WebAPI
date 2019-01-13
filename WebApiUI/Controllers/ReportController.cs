using BusinessAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiUI.Controllers
{
    public class ReportController : ApiController
    {
        IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public HttpResponseMessage Get()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            _reportService.GetFile().Save(responseMessage, "Report.xlsx");
            return responseMessage;
        }
    }
}
