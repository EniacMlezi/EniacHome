﻿#pragma checksum "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "36BE54920C107CFD271B79871C3B7C9B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MVC_default.Ui.ProjectSelector;
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


namespace MVC_default.Ui.ProjectSelector {
    
    
    /// <summary>
    /// ProjectSelectionWindow
    /// </summary>
    public partial class ProjectSelectionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tText;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateFolder;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MVC_default.Ui.ProjectSelector.ProjectSelectionControl selector;
        
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
            System.Uri resourceLocater = new System.Uri("/MVC_default;component/app_packages/visualstudio.extensibility.common.1.0.55/ui/p" +
                    "rojectselector/projectselectionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.tText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnCreateFolder = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
            this.btnCreateFolder.Click += new System.Windows.RoutedEventHandler(this.btnCreateFolder_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
            this.btnOk.Click += new System.Windows.RoutedEventHandler(this.btnOk_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.55\Ui\ProjectSelector\ProjectSelectionWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.selector = ((MVC_default.Ui.ProjectSelector.ProjectSelectionControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

