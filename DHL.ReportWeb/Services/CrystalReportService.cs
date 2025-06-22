using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ApexflowERP.ReportWeb.Services
{
    public class CrystalReportService
    {
        public string GenerateReport(string reportName, Dictionary<string, object> parameters, string InitialCatalog, string selectionFormula = "")
        {
            ReportDocument rpdoc = new ReportDocument();
            string fullDownloadPath = string.Empty;

            try
            {
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Reports/{InitialCatalog}", reportName);
                if (!File.Exists(reportPath))
                    throw new FileNotFoundException($"Report file not found at {reportPath}");

                rpdoc.Load(reportPath);

                // Setup DB connection
                var conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                var sqlConStrBuilder = new SqlConnectionStringBuilder(conStr);

                foreach (IConnectionInfo dsc in rpdoc.DataSourceConnections)
                    dsc.SetLogon(sqlConStrBuilder.UserID, sqlConStrBuilder.Password);

                rpdoc.SetDatabaseLogon(
                    sqlConStrBuilder.UserID,
                    sqlConStrBuilder.Password,
                    sqlConStrBuilder.DataSource,
                    InitialCatalog
                );

                // Apply parameters
                foreach (var param in parameters)
                {
                    if (rpdoc.ParameterFields[param.Key] != null)
                    {
                        rpdoc.SetParameterValue(param.Key, param.Value);
                    }
                }

                // Apply selection formula if present
                if (!string.IsNullOrEmpty(selectionFormula))
                {
                    rpdoc.RecordSelectionFormula = selectionFormula;
                }

                // Ensure the Downloads folder exists
                string baseDownloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
                Directory.CreateDirectory(baseDownloadPath);

                string fileName = $"Temp_{Guid.NewGuid()}.pdf";
                fullDownloadPath = Path.Combine(baseDownloadPath, fileName);

                // Export report to PDF
                rpdoc.ExportToDisk(ExportFormatType.PortableDocFormat, fullDownloadPath);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (rpdoc != null && !string.IsNullOrEmpty(rpdoc.FileName))
                {
                    CloseReports(rpdoc);
                    rpdoc.Dispose();
                }
            }

            return fullDownloadPath;
        }

        private void CloseReports(ReportDocument reportDocument)
        {
            foreach (Section section in reportDocument.ReportDefinition.Sections)
            {
                foreach (ReportObject reportObject in section.ReportObjects)
                {
                    if (reportObject is SubreportObject subreport)
                    {
                        ReportDocument subReportDocument = subreport.OpenSubreport(subreport.SubreportName);
                        subReportDocument.Close();
                        subReportDocument.Dispose();
                    }
                }
            }

            reportDocument.Close();
        }
    }
}
