﻿#pragma checksum "..\..\..\P_CustomerProfile.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09222327468C39574A3281F69E21D9DD76B6AC98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HMSApp;
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


namespace HMSApp {
    
    
    /// <summary>
    /// P_CustomerProfile
    /// </summary>
    public partial class P_CustomerProfile : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\P_CustomerProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFullName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\P_CustomerProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTelephone;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\P_CustomerProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\P_CustomerProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBirthday;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\P_CustomerProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateProfile;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\P_CustomerProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChangePassword;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HMSApp;component/p_customerprofile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\P_CustomerProfile.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbFullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbTelephone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbBirthday = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnUpdateProfile = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\P_CustomerProfile.xaml"
            this.btnUpdateProfile.Click += new System.Windows.RoutedEventHandler(this.btn_UpdateProfile);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnChangePassword = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\P_CustomerProfile.xaml"
            this.btnChangePassword.Click += new System.Windows.RoutedEventHandler(this.btn_ChangePassword);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

