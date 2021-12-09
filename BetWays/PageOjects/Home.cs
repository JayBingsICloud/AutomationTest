using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;



namespace AutomationTest.PageOjects
{
    public class Home
    {
        private WebDriverWait wait;
        private IWebDriver driver;
        private static string  country = "";


        /// Xpaths<-------------------------------------------------------------------------
        string DropDownMenuButton = "//div[@class='four columns sidebar']//span[contains(text(), 'DropDown Menu')]";
        string DropDownListButton = "//select//option[@value='AGO']";
        string SelectDropdown = "//select/.";
        string SampleTestButton = "//*[@id='post-2715']/div[2]/div/div/div[2]/div[4]/ul/li[2]/a";
        string NameTextbox = "//input[@id = 'g2599-name']";
        string EmailTextbox = "//input[@id = 'g2599-email']";
        string WebsiteTextbox = "//input[@id = 'g2599-website']";
        string ExperienceWithYears = "//select[@id = 'g2599-experienceinyears']";
        string EducationCheckBox = "//input[@name = 'g2599-expertise[]']";
        string CommentSection = "//textarea[@id = 'contact-form-comment-g2599-comment']";
        string SubmitBtn = "//button[@type = 'submit']";
        string uploadPicture = "//input[@name = 'file-553']";
        string Iframe = "//iframe[@class='demo-frame lazyloaded']";
        string FromLocation = "//*[@id='gallery']/li[3]/img";
        string ToLocation = "//div[@id ='trash']";
        string navigateToDemoTesting = "//*[@id='wrapper']/div[1]/div[1]/div/div/div/div[1]/a[2]/span";
        string AdDismiss = "//div[@id=]";
        string EducationRadioBtn = "//input[@name='g2599-education']";


        /// Xpaths-------------------------------------------------------------------------->

        SeleniumWebDriver seleniumWebDriver = new SeleniumWebDriver();

        public Home(IWebDriver Driver)
        {
            this.driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }

        private IWebElement HomeText { get { return driver.FindElement(By.XPath("//h1[contains(text(), 'Drag And Drop')]")); } }

        public void go2Url(string url)
        {
              driver.Navigate().GoToUrl(url);
            driver.Navigate().Refresh();
        }
        public void Validate_LandingPage()
        {
                wait.Until(drv => HomeText.Displayed);
        }

        //Drag and drop into the trash
        public void dragAndDrop()
        {
            //Page takes long to fully load
            Thread.Sleep(1000);

            //switching to the frame for elements to be visible
            seleniumWebDriver.switchToFrame(By.XPath(Iframe));

            seleniumWebDriver.dragAndDRop(By.XPath(FromLocation), By.XPath(ToLocation));
            Thread.Sleep(2000);

            driver.SwitchTo().DefaultContent();

            Thread.Sleep(1000);

        }


        //Navigate to Dropdwon Menu and Select a country
        public void navigateToDropdownMenu(string country )
        {

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(DropDownMenuButton)));

            string timeExc = Log.GetTimestamp(DateTime.Now);

            seleniumWebDriver.Click(By.XPath(DropDownMenuButton));
            
            seleniumWebDriver.selectdropdownItemByNameValue(By.XPath(SelectDropdown), country);
            SeleniumWebDriver.TakeScreenshot(SeleniumWebDriver.Webdriver, string.Format("Image_{0}", "Clicked Dropdown Value" + timeExc));
            Thread.Sleep(1000);

        }

        //Navigate Sample and Populate data 
        public void navigateToSampleAndFillInInfo(string name,string email,string website,string experianceYears,string Education, string comment)
        {
            driver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/");
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(SampleTestButton)));
           
            seleniumWebDriver.Click(By.XPath(SampleTestButton));
            driver.Navigate().Refresh();
            seleniumWebDriver.Click(By.XPath(SampleTestButton));
            seleniumWebDriver.writeText(By.XPath(NameTextbox), name);
            seleniumWebDriver.clickTabKeyAfterElement(By.XPath(NameTextbox), By.XPath(EmailTextbox));
            seleniumWebDriver.writeText(By.XPath(EmailTextbox), email);
            seleniumWebDriver.writeText(By.XPath(WebsiteTextbox), website);
            seleniumWebDriver.selectdropdownItemByNameValue(By.XPath(ExperienceWithYears),experianceYears);
            seleniumWebDriver.Click(By.XPath(EducationCheckBox));
            seleniumWebDriver.Click(By.XPath(EducationRadioBtn));
            seleniumWebDriver.writeText(By.XPath(CommentSection), comment);
            seleniumWebDriver.Click(By.XPath(SubmitBtn));


        }





    }
}
