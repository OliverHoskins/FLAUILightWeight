using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using NUnit.Framework;
using System.Collections.Generic;

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

        public void Toggle(ToggleState state)
        {
            element.ToggleState = state;
            HasToggleState(state);
        }

        public void HasToggleState(ToggleState state)
        {
            Assert.AreEqual(state, element.ToggleState);
        }

        public void HasText(string text)
        {
            Assert.AreEqual(text, element.Text);
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
            Assert.IsNotNull(element.SelectedItem);
            Assert.IsTrue(selectedItem.IsSelected);
        }

        public void SelectItem(string text)
        {
            element.Select(text);
            var selectedItem = element.SelectedItem;
            Assert.IsNotNull(element.SelectedItem);
            Assert.IsTrue(selectedItem.IsSelected);
            Assert.AreEqual(text, element.SelectedItem.Text);
        }

        public void EditText(string text)
        {
            element.EditableText = text;
            Assert.IsNotNull(element.SelectedItem);
            Assert.AreEqual(text, element.SelectedItem.Text);
        }

        public void Expand()
        {
            element.Expand();
            Assert.AreEqual(element.ExpandCollapseState, ExpandCollapseState.Expanded);
        }

        public void Collapse()
        {
            element.Collapse();
            Assert.AreEqual(element.ExpandCollapseState, ExpandCollapseState.Collapsed);
        }

        public void SelectedItemHasText(string text)
        {
            Assert.IsNotNull(element.SelectedItem);
            Assert.AreEqual(text, element.SelectedItem.Text);
        }

        public void clickItem(int row)
        {
            element.Items[row].Click();
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
            Assert.AreEqual(rows, element.RowCount);
            Assert.AreEqual(columns, element.ColumnCount);
        }

        public void HasColumnHeaderText(int column, string text)
        {
            var header = element.Header.Columns[column];
            Assert.IsNotNull(header);
            Assert.AreEqual(text, header.Text);
        }

        public void RowHasText(int row, List<string> textList)
        {
            var cells = element.Rows[row].Cells;

            for (int i = 0; i < cells.Length; i++)
            {
                Assert.NotNull(cells[i]);
                Assert.AreEqual(textList[i], cells[i].Value);
            }
        }

        public void CellHasText(int row, int column, string text)
        {
            var cell = element.Rows[row].Cells[column];
            var cellLabel = cell.AsLabel();
            Assert.AreEqual(text, cellLabel.Text);
        }

        public void Select(int row)
        {
            element.Select(row);
            Assert.IsNotNull(element.SelectedItems);
        }

        public void Select(int row, string text)
        {
            element.Select(row, text);
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
            Assert.AreEqual(text, element.Text);
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

        public void hasNoSelectedItem()
        {
            Assert.IsNull(element.SelectedItems);
        }

        public void HasLength(int rows)
        {   
            Assert.AreEqual(rows, element.Items.Length);
        }

        public void SelectItem(int row, string hasText)
        {
            element.Items[row].Select();
            Assert.AreEqual(element.Items[row], element.SelectedItem);
            Assert.AreEqual(element.SelectedItem.Text, hasText);
        }

        public void SelectItem(int row)
        {
            element.Items[row].Select();
            Assert.AreEqual(element.Items[row], element.SelectedItem);   
        }

        public void SelectItem(string text)
        {
            element.Select(text);
            Assert.AreEqual(element.SelectedItem.Text, text);
        }

        public void ItemHasText(int row, string text)
        {
            Assert.AreEqual(text, element.Items[row].Text);
        }
    }

    class MenuElement : BaseElement
    {
        private Menu element;
        private MenuItem subElement;
        private MenuItem subSubElement;
       
        public MenuElement(Window window, IdentifierType idType, string id = null) : base(window, idType, id)
        {
            element = baseElement.AsMenu();
            Assert.IsNotNull(element);
        }

        public void getSubMenu(int item)
        {
            subElement = element.Items[item];
            Assert.IsNotNull(subElement);
        }

        public void getSubMenu(string item)
        {
            subElement = element.Items[item];
            Assert.IsNotNull(subElement);
        }

        public void getSubSubMenu(int item)
        {
            subSubElement = subElement.Items[item];
            Assert.IsNotNull(subSubElement);
        }

        public void getSubSubMenu(string item)
        {
            subSubElement = subElement.Items[item];
            Assert.IsNotNull(subSubElement);
        }


        public void HasSubMenuWithLength(int item, int length)
        {
            var subMenu = element.Items[item];
            Assert.IsNotNull(subMenu);
            Assert.AreEqual(subMenu.Items.Length, length);
        }

        public void HasSubSubMenuWithLength(int item, int subitem, int length)
        {
            var subMenu = element.Items[item].Items[subitem];
            Assert.IsNotNull(subMenu);
            Assert.AreEqual(subMenu.Items.Length, length);
        }

        public void HasLength(int length)
        {
            Assert.AreEqual(element.Items.Length, length);
        }

        public void HasItemWithText(int item, string text)
        {
            Assert.AreEqual(element.Items[item].Text, text);
        }

        public void HasSubItemWithText(int item, int  subItem, string text)
        {
            var subMenuItem = element.Items[item].Items[subItem];
            Assert.IsNotNull(subMenuItem);
            Assert.AreEqual(subMenuItem.Text, text);
        }

        public void HasSubSubItemWithText(int item, int subItem, int subSubItem, string text)
        {
            var subSubMenuItem = element.Items[item].Items[subItem].Items[subSubItem];
            Assert.IsNotNull(subSubMenuItem);
            Assert.AreEqual(subSubMenuItem.Text, text);
        }
    }
}
