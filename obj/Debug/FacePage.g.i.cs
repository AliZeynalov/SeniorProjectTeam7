﻿#pragma checksum "..\..\FacePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D473047F335EA8411B19ACC3A0ABA71B"
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


namespace LightBuzz.Vituvius.Samples.WPF {
    
    
    /// <summary>
    /// FacePage
    /// </summary>
    public partial class FacePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pageTitle;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image camera;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse eyeLeft;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse eyeRight;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse cheekLeft;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse cheekRight;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse nose;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse mouth;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse chin;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\FacePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse forehead;
        
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
            System.Uri resourceLocater = new System.Uri("/LightBuzz.Vituvius.Samples.WPF;component/facepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FacePage.xaml"
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
            
            #line 9 "..\..\FacePage.xaml"
            ((LightBuzz.Vituvius.Samples.WPF.FacePage)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\FacePage.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pageTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 29 "..\..\FacePage.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_Checked);
            
            #line default
            #line hidden
            
            #line 29 "..\..\FacePage.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.ToggleButton_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.camera = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 7:
            this.eyeLeft = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 8:
            this.eyeRight = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 9:
            this.cheekLeft = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 10:
            this.cheekRight = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 11:
            this.nose = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 12:
            this.mouth = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 13:
            this.chin = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 14:
            this.forehead = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

