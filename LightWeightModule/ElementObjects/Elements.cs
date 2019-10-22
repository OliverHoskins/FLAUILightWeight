using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSPAutomation.ElementObjects
{

    class TextBoxElement : BaseElement
    {
        private TextBox element;

        public TextBoxElement(Window window, IdentifierType idType, string id): base(window, idType, id)
        {
            element = baseElement.AsTextBox();
            Assert.IsNotNull(element);
        }

        public void TypeText(string text)
        {
            element.Enter(text);
            Assert.AreEqual(text, element.Text);
        }

        public void IsEmpty()
        {
            Assert.AreEqual("", element.Text);
        }

        public void hasText(string text)
        {
            Assert.AreEqual(text, element.Text);
        }
    }

    class ButtonElement : BaseElement
    {
        private Button element;

        public ButtonElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsButton();
            Assert.IsNotNull(element);
        }

        public void Click(string id = null, string xPath = null)
        {
            element.Invoke();
        }

        public void hasHelpText(string text)
        {
            Assert.AreEqual(text, element.HelpText);
        }
    }

    class CheckBoxElement : BaseElement
    {
        private CheckBox element;
       
        public CheckBoxElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsCheckBox();
            Assert.IsNotNull(element);
        }

        public void Toggle()
        {
            element.Toggle();
        }

        public void HasToggleState(ToggleState state)
        {
            Assert.AreEqual(state, element.ToggleState);
        }

        public void HasText(string text)
        {
            Assert.Equals(text, element.Text);
        }
    }

    class ComboBoxElement : BaseElement
    {

        private ComboBox element;
       
        public ComboBoxElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsComboBox();
            Assert.IsNotNull(element);
        }

        public void SelectItem(int row)
        {
            element.Select(row);
            var selectedItem = element.SelectedItem;
            Assert.IsTrue(selectedItem.IsSelected);
        }

        public void ItemHasText(int row, string text)
        {
            Assert.AreEqual(text, element.Items[row].Text);
        }
    }

    class GridElement : BaseElement
    {
        private Grid element;
       
        public GridElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsGrid();
            Assert.IsNotNull(element);
        }

        public void HasDimensions(int rows, int columns)
        {
            Assert.Equals(rows, element.RowCount);
            Assert.Equals(columns, element.ColumnCount);
        }

        public void HasColumnHeaderText(int column, string text)
        {
            var header = element.Header.Columns[column];
            Assert.AreEqual(text, header.Text);
        }

        public void CellHasText(int row, int column, string text)
        {
            var cell = element.Rows[row].Cells[column];
            var cellLabel = cell.AsLabel();
            Assert.Equals(text, cellLabel.Text);
        }

        public void Select(int row)
        {
            element.Select(row);
            Assert.IsNotNull(element.SelectedItems);
        }
    }

    class LabelElement : BaseElement
    {
        private Label element;
       
        public LabelElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsLabel();
            Assert.IsNotNull(element);
        }

        public void HasText(string text)
        {
            Assert.IsNotNull(element.Text);
            Assert.Equals(text, element.Text);
        } 
    }

    class ListBoxElement : BaseElement
    {
        private ListBox element;
       
        public ListBoxElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsListBox();
            Assert.IsNotNull(element);
        }

        public void HasLength(int rows)
        {   
            Assert.Equals(rows, element.Items.Length);
        }

        public void SelectItem(int row)
        {
            element.Items[row].Select();
            Assert.AreEqual(element.Items[row], element.SelectedItem);
        }

        public void SelectItem(string text)
        {
            element.Select(text);
            Assert.Equals(element.SelectedItem.Text, text);
        }

        public void ItemHasText(int row, string text)
        {
            Assert.Equals(text, element.Items[row].Text);
        }
    }

    class MenuElement : BaseElement
    {
        private Menu element;
       
        public MenuElement(Window window, IdentifierType idType, string id) : base(window, idType, id)
        {
            element = baseElement.AsMenu();
            Assert.IsNotNull(element);
        }

        public void HasSubMenuWithLength(int item, int length)
        {
            var subMenu = element.Items[item];
            Assert.IsNotNull(subMenu);
            Assert.Equals(subMenu.Items.Length, length);
        }

        public void HasLength(int length)
        {
            Assert.Equals(element.Items.Length, length);
        }

        public void HasItemWithText(int row, string text)
        {
            Assert.Equals(element.Items[row].Text, text);
        }

        public void HasSubMenuItemWithText(int subMenu, int  row, string text)
        {
            var subMenuItem = element.Items[subMenu].Items[row];
            Assert.IsNotNull(subMenuItem);
            Assert.Equals(subMenuItem.Text, text);
        }
    }
}
