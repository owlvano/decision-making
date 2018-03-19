﻿#pragma checksum "..\..\..\Views\InputView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8BC24DCB56241E7B65FC2892FE8691C6"
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
using DecisionMaking.Constants;
using DecisionMaking.ViewModels;
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
using System.Windows.Interactivity;
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
    /// InputView
    /// </summary>
    public partial class InputView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label supply_label;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DataGrid2DLibrary.DataGrid2D supply_dataGrid2D;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label demand_label;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DataGrid2DLibrary.DataGrid2D demand_dataGrid2D;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox mode_listbox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button calculate_Btn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit_Btn;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label fuzzy_matrix_label;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DataGrid2DLibrary.DataGrid2D fuzzy_matrix_dataGrid2D;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label matrix_label;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\InputView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DataGrid2DLibrary.DataGrid2D matrix_dataGrid2D;
        
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
            System.Uri resourceLocater = new System.Uri("/DecisionMaking;component/views/inputview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\InputView.xaml"
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
            this.supply_label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.supply_dataGrid2D = ((DataGrid2DLibrary.DataGrid2D)(target));
            return;
            case 3:
            this.demand_label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.demand_dataGrid2D = ((DataGrid2DLibrary.DataGrid2D)(target));
            return;
            case 5:
            this.mode_listbox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.calculate_Btn = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.exit_Btn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.fuzzy_matrix_label = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.fuzzy_matrix_dataGrid2D = ((DataGrid2DLibrary.DataGrid2D)(target));
            return;
            case 10:
            this.matrix_label = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.matrix_dataGrid2D = ((DataGrid2DLibrary.DataGrid2D)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

