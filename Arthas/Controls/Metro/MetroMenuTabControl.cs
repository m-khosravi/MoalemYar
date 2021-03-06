﻿/****************************** ghost1372.github.io ******************************\
*	Module Name:	MetroMenuTabControl.cs
*	Project:		Arthas
*	Copyright (C) 2017 Mahdi Hosseini, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Mahdi Hosseini <Mahdidvb72@gmail.com>,  2018, 3, 22, 05:54 ب.ظ
*
***********************************************************************************/

using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arthas.Controls.Metro
{
    public class MetroMenuTabControl : TabControl
    {
        public static readonly DependencyProperty TabPanelVerticalAlignmentProperty = ElementBase.Property<MetroMenuTabControl, VerticalAlignment>(nameof(TabPanelVerticalAlignmentProperty), VerticalAlignment.Top);
        public static readonly DependencyProperty OffsetProperty = ElementBase.Property<MetroMenuTabControl, Thickness>(nameof(OffsetProperty), new Thickness(0));
        public static readonly DependencyProperty IconModeProperty = ElementBase.Property<MetroMenuTabControl, bool>(nameof(IconModeProperty), false);

        public static RoutedUICommand IconModeClickCommand = ElementBase.Command<MetroMenuTabControl>(nameof(IconModeClickCommand));

        public VerticalAlignment TabPanelVerticalAlignment { get { return (VerticalAlignment)GetValue(TabPanelVerticalAlignmentProperty); } set { SetValue(TabPanelVerticalAlignmentProperty, value); } }
        public Thickness Offset { get { return (Thickness)GetValue(OffsetProperty); } set { SetValue(OffsetProperty, value); } }
        public bool IconMode { get { return (bool)GetValue(IconModeProperty); } set { SetValue(IconModeProperty, value); GoToState(); } }

        private void GoToState()
        {
            ElementBase.GoToState(this, IconMode ? "EnterIconMode" : "ExitIconMode");
        }

        private void SelectionState()
        {
            if (IconMode)
            {
                ElementBase.GoToState(this, "SelectionStartIconMode");
                ElementBase.GoToState(this, "SelectionEndIconMode");
            }
            else
            {
                ElementBase.GoToState(this, "SelectionStart");
                ElementBase.GoToState(this, "SelectionEnd");
            }
        }

        public MetroMenuTabControl()
        {
            Loaded += delegate { GoToState(); ElementBase.GoToState(this, IconMode ? "SelectionLoadedIconMode" : "SelectionLoaded"); };
            SelectionChanged += delegate (object sender, SelectionChangedEventArgs e) { if (e.Source is MetroMenuTabControl) { SelectionState(); } };
            CommandBindings.Add(new CommandBinding(IconModeClickCommand, delegate { IconMode = !IconMode; GoToState(); }));

            Utility.Refresh(this);
        }

        static MetroMenuTabControl()
        {
            ElementBase.DefaultStyle<MetroMenuTabControl>(DefaultStyleKeyProperty);
        }
    }
}