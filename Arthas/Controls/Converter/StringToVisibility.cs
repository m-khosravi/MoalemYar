﻿/****************************** ghost1372.github.io ******************************\
*	Module Name:	StringToVisibility.cs
*	Project:		Arthas
*	Copyright (C) 2017 Mahdi Hosseini, All rights reserved.
*	This software may be modified and distributed under the terms of the MIT license.  See LICENSE file for details.
*
*	Written by Mahdi Hosseini <Mahdidvb72@gmail.com>,  2018, 3, 22, 05:54 ب.ظ
*
***********************************************************************************/

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Arthas.Controls.Converter
{
    public class StringToVisibility : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return value == null || value.ToString() == "" ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}