﻿#pragma checksum "..\..\..\ForumPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C6513DD9DC4DCDA18D2EBD7E09E15DD7DE9314CE"
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
    /// ForumPage
    /// </summary>
    public partial class ForumPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\ForumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border LeftMenu;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ForumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MainPageMenuItem;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\ForumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ForumPageMenuItem;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ForumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NWASPageMenuItem;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ForumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border HoverArea;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ForumPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Web.WebView2.Wpf.WebView2 ForumWebView;
        
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
            System.Uri resourceLocater = new System.Uri("/NovawerksApp;component/forumpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ForumPage.xaml"
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
            
            #line 21 "..\..\..\ForumPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LeftMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.MainPageMenuItem = ((System.Windows.Controls.TextBlock)(target));
            
            #line 29 "..\..\..\ForumPage.xaml"
            this.MainPageMenuItem.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ForumPageMenuItem = ((System.Windows.Controls.TextBlock)(target));
            
            #line 30 "..\..\..\ForumPage.xaml"
            this.ForumPageMenuItem.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ForumPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NWASPageMenuItem = ((System.Windows.Controls.TextBlock)(target));
            
            #line 31 "..\..\..\ForumPage.xaml"
            this.NWASPageMenuItem.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NWASPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HoverArea = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.ForumWebView = ((Microsoft.Web.WebView2.Wpf.WebView2)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

