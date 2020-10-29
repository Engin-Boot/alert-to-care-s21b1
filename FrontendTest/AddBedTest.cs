using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
{
    public class AddBedTest
    {
        Application application;
        Window window;
        public AddBedTest()
        {
            application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

            window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

            var menu = window.Get<Button>("Menu");
            menu.Click();

            window.Get<Button>("AddBed").Click();
        }

        [Fact]
        public void TestExpectingBedToBeAddedWhenCalledWithValidIcuId()
        {
            window.Get<ComboBox>("icuList").Select("TestIC1");
           
            window.Get<Button>("addBed").Click();
            var label = window.Get<Label>("65535");
            Assert.Equal("Bed added to ICU", label.Text);
            Window messageBox = window.MessageBox("");
            messageBox.Close();

            window.Close();
        }

        [Fact]
        public void TestExpectingAddBedButtonToBeNotEnabledWhenIcuIdIsNotSelected()
        {
            Button add =window.Get<Button>("addBed");
            Assert.False(add.Enabled);
            window.Close();
        }
    }
}
