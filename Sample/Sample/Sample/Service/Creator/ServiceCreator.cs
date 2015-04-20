

using System;
namespace Sample.Service.Creator
{
    public class ServiceCreator
        
    {
        #region Methods

        public static T Get<T>()
            where T : class, new()
        {
            return new T();
        }

        public static T Get<T>(params object[] parameter)
            where T : class
        {
            return (T)Activator.CreateInstance(typeof(T), parameter);
        }

        #endregion
    }
}
