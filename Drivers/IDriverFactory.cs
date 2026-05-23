using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ReqnRollProjectArchitecture.Drivers
{
    #region IDriverFactory
    internal interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }
    #endregion  IDriverFactory
}
