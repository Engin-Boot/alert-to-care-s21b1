using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
{
    public class MainPageTest
    {
        Application application;
        Window window;
        public MainPageTest()
        {
            application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

            window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

        }

        [Fact]
        void TestExpectingCorrectIcuDetailsWhenIcuIsSelected()
        {
            window.Get<ComboBox>("icuComboBox").Select("TestIC1");
            var icuIdTextBox = window.Get<TextBox>("icuId");
            Assert.Equal("TestIC1", icuIdTextBox.Text);
            Assert.Equal("14", window.Get<TextBox>("maxBeds").Text);
            window.Get<Button>("TestIC1L01");
            window.Close();
        }

    }
}
