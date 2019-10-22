using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSPAutomation.ElementObjects
{

    enum IdentifierType
    {
        automationId,
        xPath,
        name,
        text
    }

    class BaseElement
    {
        private Window popup;
        public Window window;
        public AutomationElement baseElement;
        

        public BaseElement(Window window, IdentifierType idType, string id)
        {
            this.window = window;
            GetElement(idType, id);
        }

        /** In the event that the element var goes stale,
         * re-call ths meathod, 
         * or re-declare the element within the test **/
        private void GetElement(IdentifierType idType, string id)
        {
            switch (idType)
            {
                case IdentifierType.automationId:
                    baseElement = window.FindFirstDescendant(cf => cf.ByAutomationId(id));
                    break;
                case IdentifierType.xPath:
                    baseElement = window.FindFirstByXPath(id);
                    break;
                case IdentifierType.name:
                    baseElement = window.FindFirstDescendant(cf => cf.ByName(id));
                    break;
                case IdentifierType.text:
                    baseElement = window.FindFirstDescendant(cf => cf.ByText(id));
                    break;
            }
        }

        public AutomationElement getPopupItem(string id = null, string xPath = null)
        {
            getPopup();

            if (id == null)
            {
                return popup.FindFirstDescendant(cf => cf.ByAutomationId(id));
            }
            else
            {
                return popup.FindFirstByXPath(xPath);
            }
        }

        private void getPopup()
        {
            Wait.UntilInputIsProcessed();
            popup = window.Popup;
            Assert.IsNotNull(popup);
        }
    }
}
