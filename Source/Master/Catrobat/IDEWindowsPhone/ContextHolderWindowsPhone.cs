﻿using Catrobat.Core;
using Catrobat.IDEWindowsPhone.ViewModel.Main;
using Microsoft.Practices.ServiceLocation;

namespace Catrobat.IDEWindowsPhone
{
    public class ContextHolderWindowsPhone : IContextHolder
    {
        public CatrobatContext GetContext()
        {
            var mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            return mainViewModel.Context;
        }
    }
}