﻿
using System;
using System.Collections.Generic;
using Nhom2vip.View;
using Nhom2vip.ViewModel;
using Xamarin.Forms;

namespace Nhom2vip.Model
{
    public class CategoryModel : BaseVM
    {
        public string Name { get; set; }
        private bool select;
        public bool Select
        {
            get { return select; }
            set { SetProperty(ref select, value); }
        }

    }
}
