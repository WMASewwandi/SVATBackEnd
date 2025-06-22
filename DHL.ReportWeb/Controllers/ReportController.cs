using ApexflowERP.ReportWeb.Services;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Services.Description;

namespace ApexflowERP.ReportWeb.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Ping()
        {
            return "Web API is working!";
        }

        [HttpGet]
        [Route("PrintDocuments")]
        public HttpResponseMessage PrintDocuments([FromUri] string InitialCatalog, string documentNumber, string reportName, string warehouseId, string currentUser)
        {
            var service = new CrystalReportService();
            var parameters = new Dictionary<string, object>
            {
                { "DocumentNumber", documentNumber },
                { "WarehouseId", warehouseId },
                { "CurrentUser", currentUser }
            };


            string filePath = service.GenerateReport(reportName, parameters, InitialCatalog);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(File.ReadAllBytes(filePath))
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
            {
                FileName = Path.GetFileName(filePath)
            };

            return result;
        }
    }
}
