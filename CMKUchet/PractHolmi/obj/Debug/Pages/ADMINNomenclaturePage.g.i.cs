﻿#pragma checksum "..\..\..\Pages\ADMINNomenclaturePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C8E908DC6420DE3F74544FD2A3FC18A1ABA24673665966A5E1A523B427BA06DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProkatHolm.Pages;
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


namespace ProkatHolm.Pages {
    
    
    /// <summary>
    /// ADMINNomenclaturePage
    /// </summary>
    public partial class ADMINNomenclaturePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSearch;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReset;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortComboBox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FiltComboBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGrid;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock x;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDel;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOtchet;
        
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
            System.Uri resourceLocater = new System.Uri("/ProkatHolm;component/pages/adminnomenclaturepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
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
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.BtnSearch.Click += new System.Windows.RoutedEventHandler(this.BtnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.SearchBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.SearchBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnReset = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.BtnReset.Click += new System.Windows.RoutedEventHandler(this.BtnReset_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SortComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 68 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.SortComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FiltComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 74 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.FiltComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FiltComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 79 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.DGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.DGrid.IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.DGrid_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.x = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnDel = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.BtnDel.Click += new System.Windows.RoutedEventHandler(this.BtnDel_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnOtchet = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\Pages\ADMINNomenclaturePage.xaml"
            this.BtnOtchet.Click += new System.Windows.RoutedEventHandler(this.BtnOtchet_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

