using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
    {
        public class AddIcuTest
        {

            [Fact]
            public void TestExpectingValidIcuToBeAddedWhenCalledWithValidIcuDetails()
            {

                Application application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

                Window window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

                Button menu = window.Get<Button>("Menu");
                menu.Click();

                window.Get<Button>("AddICU").Click();

                window.Get<TextBox>("icuId").SetValue("TestIC10");
                window.Get<TextBox>("maxBeds").SetValue("12");
                window.Get<ComboBox>("LayoutList").Select("U-Layout");
                window.Get<Button>("addIcu").Click();
                var label = window.Get<Label>("65535");
                Assert.Equal("ICU added successfully", label.Text);
                Window messageBox = window.MessageBox("");
                messageBox.Close();
                window.Close();
            }
    }

}
