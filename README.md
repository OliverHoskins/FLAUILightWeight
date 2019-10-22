# FLAUILightWeight
The aim of this module is to create a lightweight solution and test structure to testing Windows applications using the FlaUI framework.
There is currently two files for this project: 
- BaseElement.cs
- Element.cs 

additional files to add: 
- BasePage.cs
- ExamplePage.cs

# BaseElement.cs 
This is the class which all other Elements will inherit from. Its contains an element getter which returns a FlaUI AutomationElement.
The getter is used within the constuctor of each of the Element classes to get the relevant element for that class 
e.g. LableElement will get a AutomationElement.Label 

# Element.cs
Currently only the following Automation Elements have a LightWeight solution. 
These being: 
- TextBox
- Button 
- CheckBox
- ComboBox
- Grid
- Label
- ListBox
- Menu

Leaving the Remaining automation elements: 
- PopUp
- ProgressBar
- RadioButton
- Slider
- Table
- Tab 
- Tree 

# Declaring Elements
To declare an Element to be acted apon and asserted against follow the below example: 

    example :
          var myLabel = new LabelElement(window, IdentifierType.text, "MatchingText")

Each Element take a maximum of three values a Window, IdentifierType and a matching string (composition depending on the IdentifierType used to select the element)
