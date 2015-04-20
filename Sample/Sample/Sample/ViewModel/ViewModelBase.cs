

using Sample.Page.Interface;
using Sample.ViewModel.Interface;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace Sample.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
    {

        #region Properties

        public INavigation Navigation { get; private set; }

        public IMessage Message { get; set; }

        #endregion

        #region Constructor

        public ViewModelBase(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        protected void RaisedPropertyChanged<PropertyType>(Expression<Func<PropertyType>> property)
        {
            var memberExpression = property.Body as MemberExpression;
            var propertyInfo = memberExpression.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }

        #endregion

    }
}
