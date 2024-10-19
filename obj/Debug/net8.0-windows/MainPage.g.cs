﻿#pragma checksum "..\..\..\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6FB334FBC92D6BC26ADDE68CB1D1AC08DA92A8A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Web.WebView2.Wpf;
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


namespace NovawerksApp {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border LeftMenu;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MainPageMenuItem;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ForumPageMenuItem;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NWASPageMenuItem;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SettingsButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border HelpSidebar;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Web.WebView2.Wpf.WebView2 HelpWebView;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ContentFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NovawerksApp;component/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 25 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 28 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.UndoMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 29 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RedoMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 32 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RefreshMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 35 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.LoginButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 40 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.HelpMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LeftMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.MainPageMenuItem = ((System.Windows.Controls.TextBlock)(target));
            
            #line 50 "..\..\..\MainPage.xaml"
            this.MainPageMenuItem.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ForumPageMenuItem = ((System.Windows.Controls.TextBlock)(target));
            
            #line 51 "..\..\..\MainPage.xaml"
            this.ForumPageMenuItem.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ForumPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.NWASPageMenuItem = ((System.Windows.Controls.TextBlock)(target));
            
            #line 52 "..\..\..\MainPage.xaml"
            this.NWASPageMenuItem.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NWASPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.SettingsButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\MainPage.xaml"
            this.SettingsButton.Click += new System.Windows.RoutedEventHandler(this.SettingsButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.HelpSidebar = ((System.Windows.Controls.Border)(target));
            return;
            case 14:
            
            #line 65 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseHelpSidebar_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.HelpWebView = ((Microsoft.Web.WebView2.Wpf.WebView2)(target));
            return;
            case 16:
            
            #line 87 "..\..\..\MainPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 101 "..\..\..\MainPage.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 18:
            this.ContentFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

