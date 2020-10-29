using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
{
    public class RemoveIcuTest
    {
        Application application;
        Window window;
        public RemoveIcuTest()
        {
            application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

            window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

            var menu = window.Get<Button>("Menu");
            menu.Click();

            window.Get<Button>("RemoveICU").Click();
        }

        [Fact]
        public void TestExpectingICUToBeRemovedWhenCalledWithValidICU()
        {
            window.Get<ComboBox>("icuList").Select("TestIC2");

            window.Get<Button>("removeICU").Click();
            var label = window.Get<Label>("65535");
            Assert.Equal("ICU deleted successfully", label.Text);
            Window messageBox = window.MessageBox("");
            messageBox.Close();
            window.Close();
        }

        [Fact]
        public void TestExpectingRemoveIcuButtonToBeNotEnabledWhenIcuIdIsNotSelected()
        {
            var remove = window.Get<Button>("removeICU");
            Assert.False(remove.Enabled);
            window.Close();
        }
    }
}
