using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AutomationTest.PageOjects;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomationTest
{
   public class Log
    {
        public static string images = "";
        private static ExtentTest TestFeature;
        private static ExtentTest scenario;
        private static ExtentReports ExtentReports;
        private static ExtentHtmlReporter hmtlreport;
        public static ExtentReports extent;
        public static ExtentTest test;
        static string  Path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\netcoreapp3.1", "");
        private static string extentHtmlPath = string.Format(@"{0}\Output\Report\Report.html",Path);

        

        public static void LogResults( string step, string stepStatus)
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 13);  // creates a number between 1 and 12

            String timeStamp = GetTimestamp(DateTime.Now); //get time stamp from now
            images = images + timeStamp;
            var screenshotspath = string.Format(@"{0}\Output\Report\images\{1}", Path, string.Format("Image_{0}.jpg", images));
            Utils.CreateDir(string.Format(@"{0}Output\Report\images", Path));
            string details = string.Format("<p style='font-size:15px'>{0}</p><br>", step);

            SeleniumWebDriver.TakeScreenshot(SeleniumWebDriver.Webdriver, string.Format("Image_{0}", images));

            switch (stepStatus)
            {
                case "Fail":
                   
                    scenario.Log(Status.Fail, details, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotspath).Build());
                    break;

                case "Warning":
                    scenario.Log(Status.Warning, details, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotspath).Build());
                    break;

                case "Pass":
                    scenario.Log(Status.Pass, details, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotspath).Build());
                    break;

            }

        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
        public static void CreateScenarionNode(String s)
        {
            scenario = TestFeature.CreateNode(s);
        }


        public static void CreateTestFeature(string s)
        {
            TestFeature = ExtentReports.CreateTest(s);
        }

        public static void flush()
        {
            ExtentReports.Flush();
        }

        public static void initExtentReport(string OSVersion, string Environment)
        {
            hmtlreport = new ExtentHtmlReporter(extentHtmlPath);
            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(hmtlreport);
            ExtentReports.AddSystemInfo("OS version", OSVersion);
            ExtentReports.AddSystemInfo("Environmet ", Environment);

        }
    }
}
