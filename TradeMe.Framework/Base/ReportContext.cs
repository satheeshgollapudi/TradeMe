using AventStack.ExtentReports.Reporter;
using TradeMe.Framework.Config;
using TradeMe.Framework.Helps;

namespace TradeMe.Framework.Base
{
    public class ReportContext
    {
        public static AventStack.ExtentReports.ExtentReports ExtendReport { get; set; }

        static ReportContext()
        {
            ExtendReport = new AventStack.ExtentReports.ExtentReports();
            var path = PathHelper.ToApplicationPath(Settings.ExtendReportPath);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ReportContext.ExtendReport.AttachReporter(htmlReporter);
        }
    }
}