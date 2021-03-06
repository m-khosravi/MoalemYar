﻿/****************************** ghost1372.github.io ******************************\
*	Module Name:	MetroTabControl.cs
*	Project:		Arthas
*	Copyright (C) 2017 Mahdi Hosseini, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Mahdi Hosseini <Mahdidvb72@gmail.com>,  2018, 3, 22, 05:54 ب.ظ
*
***********************************************************************************/

using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroTabControl : TabControl
    {
        private void SelectionState()
        {
            ElementBase.GoToState(this, "SelectionStart");
            ElementBase.GoToState(this, "SelectionEnd");
        }

        public MetroTabControl()
        {
            Loaded += delegate { ElementBase.GoToState(this, "SelectionLoaded"); };
            SelectionChanged += delegate (object sender, SelectionChangedEventArgs e) { if (e.Source is MetroTabControl) { SelectionState(); } };
            Utility.Refresh(this);
        }

        static MetroTabControl()
        {
            ElementBase.DefaultStyle<MetroTabControl>(DefaultStyleKeyProperty);
        }
    }
}