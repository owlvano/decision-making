﻿#pragma checksum "..\..\..\Views\FuzzyCriteriasTabView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8BCE8E0AA99C1F8AF4CC148726ACFEB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DataGrid2DLibrary;
using System;
using System.Diagnostics;
using System.Globalization;
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


namespace DecisionMaking.Views {
    
    
    /// <summary>
    /// FuzzyCriteriasTabView
    /// </summary>
    public partial class FuzzyCriteriasTabView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label add_Value_Label;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox add_Value_TextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox criteria_Listbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button calculate_Btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label wins_Label;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DataGrid2DLibrary.DataGrid2D wins_DataGrid2D;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label result_Label;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DataGrid2DLibrary.DataGrid2D result_DataGrid2D;
        
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
            System.Uri resourceLocater = new System.Uri("/DecisionMaking;component/views/fuzzycriteriastabview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\FuzzyCriteriasTabView.xaml"
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
            this.add_Value_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.add_Value_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.criteria_Listbox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.calculate_Btn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.wins_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.wins_DataGrid2D = ((DataGrid2DLibrary.DataGrid2D)(target));
            return;
            case 7:
            this.result_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.result_DataGrid2D = ((DataGrid2DLibrary.DataGrid2D)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

