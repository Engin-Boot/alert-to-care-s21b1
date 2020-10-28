﻿#pragma checksum "..\..\..\MenuControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61E8188E7EC2905152D08569C6BE5E1BAFE88B82"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Frontend;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Frontend {
    
    
    /// <summary>
    /// MenuControl
    /// </summary>
    public partial class MenuControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\MenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddICU;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\MenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBed;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\MenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddPatient;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\MenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveICU;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveBed;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\MenuControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Discharge;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Frontend;V1.0.0.0;component/menucontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MenuControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddICU = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\MenuControl.xaml"
            this.AddICU.Click += new System.Windows.RoutedEventHandler(this.AddIcuItem_Selected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddBed = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\MenuControl.xaml"
            this.AddBed.Click += new System.Windows.RoutedEventHandler(this.AddBedItem_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddPatient = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\MenuControl.xaml"
            this.AddPatient.Click += new System.Windows.RoutedEventHandler(this.AddPatientItem_Selected);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RemoveICU = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\MenuControl.xaml"
            this.RemoveICU.Click += new System.Windows.RoutedEventHandler(this.DeleteIcuItem_Selected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RemoveBed = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\MenuControl.xaml"
            this.RemoveBed.Click += new System.Windows.RoutedEventHandler(this.DeleteBedItem_Selected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Discharge = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\MenuControl.xaml"
            this.Discharge.Click += new System.Windows.RoutedEventHandler(this.DeletePatientItem_Selected);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
