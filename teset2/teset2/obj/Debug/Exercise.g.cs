﻿#pragma checksum "..\..\Exercise.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11B9E05112719D48A010D9437C26928800448254"
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
    /// Exercise
    /// </summary>
    public partial class Exercise : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Remind;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MinuteArea;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MinuteSplitSecond;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SecondArea;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stop;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cont;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Exercise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finish;
        
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
            System.Uri resourceLocater = new System.Uri("/teset2;component/exercise.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Exercise.xaml"
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
            this.Remind = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.MinuteArea = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.MinuteSplitSecond = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SecondArea = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.stop = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Exercise.xaml"
            this.stop.Click += new System.Windows.RoutedEventHandler(this.Stop);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cont = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Exercise.xaml"
            this.cont.Click += new System.Windows.RoutedEventHandler(this.Continue);
            
            #line default
            #line hidden
            return;
            case 7:
            this.finish = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Exercise.xaml"
            this.finish.Click += new System.Windows.RoutedEventHandler(this.Finish);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

