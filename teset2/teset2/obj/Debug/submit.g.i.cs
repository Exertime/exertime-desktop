﻿#pragma checksum "..\..\submit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C1C6D57A60F314A64621EBAE9C4030688CC0AA76"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using teset2;


namespace teset2 {
    
    
    /// <summary>
    /// submit
    /// </summary>
    public partial class submit : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid contents;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock repetition;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tital;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Statistics;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Sub;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EX;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Rep;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/teset2;component/submit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\submit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.contents = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.repetition = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Tital = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Statistics = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\submit.xaml"
            this.Statistics.Click += new System.Windows.RoutedEventHandler(this.statistics);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Sub = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\submit.xaml"
            this.Sub.Click += new System.Windows.RoutedEventHandler(this.Submit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EX = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\submit.xaml"
            this.EX.Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Rep = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\submit.xaml"
            this.Rep.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.limitnumber);
            
            #line default
            #line hidden
            
            #line 14 "..\..\submit.xaml"
            this.Rep.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Rep_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

