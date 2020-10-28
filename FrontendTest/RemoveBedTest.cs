﻿using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace FrontendTest
{
    public class RemoveBedTest
    {
        [Fact]
        public void TestExpectingICUToBeRemovedWhenCalledWithValidICU()
        {
            Application application = Application.Launch(@"C:\Users\ALIRAZA\Documents\GitHub\DummyRepository\alert-to-care-s21b1\Frontend\bin\Debug\netcoreapp3.1\Frontend.exe");

            Window window = application.GetWindow("Hospital ICU management", InitializeOption.NoCache);

            Button menu = window.Get<Button>("Menu");
            menu.Click();

            window.Get<Button>("RemoveBed").Click();

            window.Get<ComboBox>("icuList").Select("TestIC1");

            window.Get<ComboBox>("bedList").Select("TestIC1L03");

            window.Get<Button>("removeBed").Click();
            var label = window.Get<Label>("65535");
            Assert.Equal("Bed Removed from ICU", label.Text);
            Window messageBox = window.MessageBox("");
            messageBox.Close();
            window.Close();
        }

    }
}
