﻿#pragma checksum "..\..\..\Main\wndMain.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "419C7E78855CCB2671BFD34BEA888C0E20224CC1AEF2F6F889152B058DA5F291"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GroupProject.Main;
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


namespace GroupProject.Main {
    
    
    /// <summary>
    /// wndMain
    /// </summary>
    public partial class wndMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dvInvoice;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newInvoice;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteInvoice;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboInvoice;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboAddItems;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addItem;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox itemPrice;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboInvoiceItems;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteItem;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveInvoice;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox totalCostInput;
        
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
            System.Uri resourceLocater = new System.Uri("/GroupProject;component/main/wndmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Main\wndMain.xaml"
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
            
            #line 11 "..\..\..\Main\wndMain.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.searchForInvoice);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\Main\wndMain.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.updateItem);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dvInvoice = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.newInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Main\wndMain.xaml"
            this.newInvoice.Click += new System.Windows.RoutedEventHandler(this.newInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.deleteInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Main\wndMain.xaml"
            this.deleteInvoice.Click += new System.Windows.RoutedEventHandler(this.deleteInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboInvoice = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\Main\wndMain.xaml"
            this.comboInvoice.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboInvoice_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.comboAddItems = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\Main\wndMain.xaml"
            this.comboAddItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboAddItems_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.addItem = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Main\wndMain.xaml"
            this.addItem.Click += new System.Windows.RoutedEventHandler(this.addItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.itemPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.comboInvoiceItems = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.deleteItem = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Main\wndMain.xaml"
            this.deleteItem.Click += new System.Windows.RoutedEventHandler(this.deleteItem_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.saveInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Main\wndMain.xaml"
            this.saveInvoice.Click += new System.Windows.RoutedEventHandler(this.saveInvoice_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.totalCostInput = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

