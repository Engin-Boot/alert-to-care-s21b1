using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
    {
        public class AddIcuTest
        {
            Application application;
            Window window;
            public AddIcuTest()
            {
                application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

                window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

                var menu = window.Get<Button>("Menu");
                menu.Click();

                window.Get<Button>("AddICU").Click();
            }

            [Fact]
            public void TestExpectingIcuToBeAddedWhenCalledWithValidIcuDetails()
            {
                window.Get<TextBox>("icuId").SetValue("TestIC7");
                window.Get<TextBox>("maxBeds").SetValue("12");
                window.Get<ComboBox>("LayoutList").Select("U-Layout");
                window.Get<Button>("addIcu").Click();
                var label = window.Get<Label>("65535");
                Assert.Equal("ICU added successfully", label.Text);
                Window messageBox = window.MessageBox("");
                messageBox.Close();
                window.Close();
            }

            [Fact]
            public void TestExpectingAddIcuButtonToBeNotEnabledWhenCalledWithInvalidIcuId()
            {
                window.Get<TextBox>("icuId").SetValue("TestIC1");
                window.Get<TextBox>("maxBeds").SetValue("12");
                window.Get<ComboBox>("LayoutList").Select("U-Layout");
                Button add = window.Get<Button>("addIcu");
                Assert.False(add.Enabled);
                window.Close();
            }

            [Fact]
            public void TestExpectingAddIcuButtonToBeNotEnabledWhenCalledWithInvalidMaxBedsinIcu()
            {

                window.Get<TextBox>("icuId").SetValue("TestIC14");
                window.Get<TextBox>("maxBeds").SetValue("abc");
                window.Get<ComboBox>("LayoutList").Select("L-Layout");
                Button add = window.Get<Button>("addIcu");
                Assert.False(add.Enabled);
                window.Close();
            }
            [Fact]
            public void TestExpectingAddIcuButtonToBeNotEnabledWhenIcuLayoutIsNotSelected()
            {

                window.Get<TextBox>("icuId").SetValue("TestIC14");
                window.Get<TextBox>("maxBeds").SetValue("14");
                Button add = window.Get<Button>("addIcu");
                Assert.False(add.Enabled);
                window.Close();
            }
        }
}
