using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
{
    public class AddPatientTest
    {
        [Fact]
        public void TestExpectingPatientToBeAddedWhenCalledWithValidPatientDetails()
        {

            Application application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

            Window window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

            Button menu = window.Get<Button>("Menu");
            menu.Click();

            window.Get<Button>("AddPatient").Click();

            window.Get<ComboBox>("icuIdList").Select("TestIC1");
            window.Get<ComboBox>("bedIdList").Select("TestIC1U01");
            window.Get<TextBox>("name").SetValue("Tom");
            window.Get<TextBox>("age").SetValue("18");
            window.Get<TextBox>("address").SetValue("Pune");
            window.Get<ComboBox>("genderList").Select("Male");
            window.Get<TextBox>("contact").SetValue("9595010888");
            window.Get<Button>("addPatient").Click();
            var label = window.Get<Label>("65535");
            Assert.Equal("Patient added to the bed", label.Text);
            Window messageBox = window.MessageBox("");
            messageBox.Close();
            window.Close();
        }
    }
}
