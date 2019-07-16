using System.Diagnostics;
using System.Globalization;
using System.Windows;
using SciChart.Charting.Visuals;

namespace TelemetryGUI
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SciChartSurface.SetRuntimeLicenseKey(@"
                            <LicenseContract>
  <Customer>Jonkoping University</Customer>
  <OrderId>EDUCATIONAL-USE-0102</OrderId>
  <LicenseCount>1</LicenseCount>
  <IsTrialLicense>false</IsTrialLicense>
  <SupportExpires>06/30/2019 00:00:00</SupportExpires>
  <ProductCode>SC-WPF-2D-PRO</ProductCode>
  <KeyCode>lwABAQEAAAAoVlS5DTDVAQEAdABDdXN0b21lcj1Kb25rb3BpbmcgVW5pdmVyc2l0eTtPcmRlcklkPUVEVUNBVElPTkFMLVVTRS0wMTAyO1N1YnNjcmlwdGlvblZhbGlkVG89MzAtSnVuLTIwMTk7UHJvZHVjdENvZGU9U0MtV1BGLTJELVBST3bg3c1h8GBQWT3XK8Meflee7jq7gqmUDhBk4Bet4+WBERC3mfROknENx5JIAveZ5Q==</KeyCode>
</LicenseContract>
");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (Debugger.IsAttached)
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        }
    }
}