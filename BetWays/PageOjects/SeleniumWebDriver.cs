using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;


namespace AutomationTest.PageOjects
{
    public class SeleniumWebDriver
    {
        public static IWebDriver Webdriver;
        static string pathToIcoFile = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\netcoreapp3.1", "");
        static string Path = pathToIcoFile + @"\Output";
        public static int screenshotcount = 0;


        public static void Launchbrowser(string browser)
        {
            Exception error = null;
            try
            {
                switch (browser)
                {
                    case "CHROME":
                        var chromeOptions = new ChromeOptions();

                        chromeOptions.AddArgument("--disable-popup-blocking");


                        chromeOptions.AcceptInsecureCertificates = true;
                        Webdriver = new ChromeDriver(chromeOptions);

                        Webdriver.Manage().Window.Maximize();
                        break;

                    default:
                        throw new Exception(string.Format("{0} is not Configured!!", browser));

                }
            }
            catch (Exception e)
            {
                throw;

            }
        }

        //Click Method
        public void Click(By elementLocation)
        {
            Webdriver.FindElement(elementLocation).Click();
        }

        //Write Text
        public void writeText(By elementLocation, String text)
        {

            Webdriver.FindElement(elementLocation).SendKeys(text);
        }

        //*************************Used to click tab key********************************************************************
        public void clickTabKeyAfterElement(By elementAtFocus, By emptyPageSpaceXpath)
        {
            Actions actions = new Actions(Webdriver);
            actions.Click((Webdriver.FindElement(elementAtFocus))).SendKeys(Keys.Tab).Build().Perform();
            Webdriver.FindElement((emptyPageSpaceXpath)).Click();
            Thread.Sleep(3000);
        }

        //Read Text
        public String readText(By elementLocation)
        {
            var wait1 = new OpenQA.Selenium.Support.UI.WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
            return wait1.Until(Webdriver => Webdriver.FindElement(elementLocation).Text);
        }

        public void switchToFrame(By elementLocation)
        {
            //Switching the frame in order for elements to be visible 
            Webdriver.SwitchTo().Frame(Webdriver.FindElement(elementLocation));
        }

        public void dragAndDRop(By elementLocationFrom, By elementLocationTo)
        {
            // Actions class method to drag and drop
            Actions builder = new Actions(Webdriver);
            var from = Webdriver.FindElement(elementLocationFrom);
            var to = Webdriver.FindElement(elementLocationTo);
            //Perform drag and drop
            builder.DragAndDrop(from, to).Perform();
            Thread.Sleep(2000);
        }

        //Read Attributes
        public String readAttribute(By elementLocation)
        {
            return Webdriver.FindElement(elementLocation).GetAttribute("title");
        }

        //Clear Method
        public void clearTextField(By elementLocation)
        {
            Webdriver.FindElement(elementLocation).Clear();
        }

        /**Used select dropdown item by Name */
        public void selectdropdownItemByNameValue(By elementLocation, String text)
        {
            //"select by value"

            SelectElement selectByValue = new SelectElement(Webdriver.FindElement(elementLocation));
            selectByValue.SelectByValue(text);
        }
        public void waitForElementToBeVisible(By elementLocation)
        {
            /** Purpose:
             *Explicit wait ;We can tell the tool to wait only till the Condition satisfy.*/
            var wait = new WebDriverWait(Webdriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("content-section")));
        }

        public static void waitForPageToBeReady_2()
        {   /** Purpose:
     *This loop will rotate for 100 times to check If page Is ready after every 1 second.
     *You can modify it if you wants to Increase or decrease wait time.*/
            IJavaScriptExecutor js = (IJavaScriptExecutor)Webdriver;
            for (int i = 0; i < 400; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (ThreadInterruptedException e) { }
                //To check page ready state.
                if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
                {
                    break;
                }
            }
        }

       
     

        public static void close()
            {
                if (Webdriver != null)
                {
                    Webdriver.Quit();
                }

            }

            public static void TakeScreenshot(IWebDriver drvr, string imagename)
            {
                Screenshot screenshot = ((ITakesScreenshot)drvr).GetScreenshot();
                screenshot.SaveAsFile(string.Format(@"{0}\Report\images\{1}.jpg", Path, imagename), ScreenshotImageFormat.Png);
            }
        }
    }



