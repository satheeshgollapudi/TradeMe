using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace MVPStudio.Framework.Extensions
{
    public static class WebElementExtension
    {
        /// <summary>
        /// Wait the element to be clickable
        /// <example>For example
        /// <code>
        /// Element.WaitForClickable(Driver);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="timeOutinSeconds"></param>
        public static void WaitForClickable(this IWebElement element, IWebDriver driver, int timeOutinSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Waiting for element to be clickable failed");
            }
        }

        /// <summary>
        /// Wait for element displayed
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="timeOutinSeconds"></param>
        public static void WaitForDisplayed(this IWebElement element, IWebDriver driver, int timeOutinSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                wait.Until(x => element.Displayed == true);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Waiting for element to display failed");
            }
        }

        /// <summary>
        /// Wait for the inner text of element loaded
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="timeOutinSeconds"></param>
        public static void WaitForTextLoaded(this IWebElement element, IWebDriver driver, int timeOutinSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                wait.Until(x => !string.IsNullOrEmpty(element.Text));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Wait for text loaded failed");
            }
        }

        /// <summary>
        /// Wait for menu item displayed and Select menu item from dropdown list
        /// <example>For example
        /// <code>
        /// DropdownMenu.SelectFromDropdownList("menu")
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="element">The parent element of menu item</param>
        /// <param name="driver"></param>
        /// <param name="menuItem"></param>
        public static void SelectFromDropdownList(this IWebElement element, IWebDriver driver, string menuItem)
        {
            try
            {
                var option = element.FindElement(By.XPath("//li[contains(.,'" + menuItem + "')]"));
                option.WaitForDisplayed(driver);
                option.Click();
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("The menu item doesn't exist in drop down list");
            }
        }

        /// <summary>
        /// Hover on element
        /// <example>For example
        /// <code>
        /// Element.Hover(Driver)
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        public static void Hover(this IWebElement element, IWebDriver driver)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        /// <summary>
        /// Clear and send Text to textbox or textarea
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text">The text to input to the control</param>
        public static void InputText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Get Inner Text of element
        /// if the text is loaded, return the text
        /// otherwise return String.Empty
        /// <example>
        /// Element.GetInnerText(Driver)
        /// </example>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="timeOutInSeconds"></param>
        /// <returns>text or String.Empty</returns>
        public static string GetInnerText(this IWebElement element, IWebDriver driver)
        {
            try
            {
                element.WaitForTextLoaded(driver);
                return element.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Check if the header has been expanded 
        /// if yes, do nothing
        /// if no, Expand the header
        /// <example>For example
        /// In Profile Page, each section has an expandable header.
        /// In order to view or edit the section, user need to expand the header first.
        /// <code>
        /// HeaderElement.ExpandHeader();
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="element"></param>
        public static void ExpandHeader(this IWebElement element)
        {
            if (element.GetAttribute("aria-expanded") == "false")
            {
                element.Click();
            }
        }

        /// <summary>
        /// Search data from a single page table by data set condition (columnNumber, columnValue), return row number
        /// if the data entry is found, return row number
        /// otherwise return 0, searching failed
        /// </summary>
        /// <param name="element">The table body element</param>
        /// <param name="driver"></param>
        /// <param name="dataset">key value pair dataset. Key is the column number, Value is the column value</param>
        /// <returns>row number or 0</returns>
        public static int SearchDataFromTable(this IWebElement element, IWebDriver driver, IDictionary<int, string> dataset)
        {
            IList<IWebElement> rows = element.FindElements(By.TagName("tr"));

            for (int i = 0; i < rows.Count; i++)
            {
                IList<IWebElement> columns = rows[i].FindElements(By.TagName("td"));
                int j = 0;
                foreach (KeyValuePair<int, string> kvp in dataset)
                {
                    int columnNumber = kvp.Key;
                    string columnValue = kvp.Value;
                    if (columns[columnNumber - 1].GetInnerText(driver) == columnValue)
                    {
                        j++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (j == dataset.Count)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Verify if the data entry exists in a single page table according to the data set condition
        /// if yes, return true
        /// otherwise return false
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="dataset"></param>
        /// <returns>true or false</returns>
        public static bool IsDataPresentInTable(this IWebElement element, IWebDriver driver, IDictionary<int, string> dataset)
        {
            if (element.SearchDataFromTable(driver, dataset) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // read the data from excel, select the checkbox based on the value -> Sunil

    }
}