﻿#pragma checksum "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.54\Ui\ProjectSelector\ProjectSelectionControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0164D65F0AE7E2F55A11BF035C92FBAB"
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
    /// ProjectSelectionControl
    /// </summary>
    public partial class ProjectSelectionControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.54\Ui\ProjectSelector\ProjectSelectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MVC_default.Ui.ProjectSelector.ProjectSelectionControl ctlSelector;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.54\Ui\ProjectSelector\ProjectSelectionControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView trProjects;
        
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
            System.Uri resourceLocater = new System.Uri("/MVC_default;component/app_packages/visualstudio.extensibility.common.1.0.54/ui/p" +
                    "rojectselector/projectselectioncontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.54\Ui\ProjectSelector\ProjectSelectionControl.xaml"
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
            this.ctlSelector = ((MVC_default.Ui.ProjectSelector.ProjectSelectionControl)(target));
            return;
            case 2:
            this.trProjects = ((System.Windows.Controls.TreeView)(target));
            
            #line 24 "..\..\..\..\..\..\App_Packages\VisualStudio.Extensibility.Common.1.0.54\Ui\ProjectSelector\ProjectSelectionControl.xaml"
            this.trProjects.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.TrProjects_OnSelectedItemChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

