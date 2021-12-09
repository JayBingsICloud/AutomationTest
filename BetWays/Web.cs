using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTest.PageOjects
{
    public class Web
    {
        public static Home HomeScreen
        {
            get { return new Home(SeleniumWebDriver.Webdriver); }
        }
           
    }
}
