using TradeMe.Framework.Config;
using TradeMe.Framework.Helps.Excel;

namespace TradeMe.Framework.Base
{
    public class FrameworkInitializeHook
    {
        public void InitializeSettings()
        {
            ConfigReader.InitializeFrameworkSettings();

            ExcelUtil.InitExcelData();

            _ = new ReportContext();
        }

    }
}
