using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Navigation.WPF
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public abstract string CurrentPage { get; }

        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        public void Set<TProp>(ref TProp prop, TProp val, [CallerMemberName] string member = default)
        {
            if (EqualityComparer<TProp>.Default.Equals(val, prop))
            {
                return;
            }

            prop = val;
            OnProp(member);
        }

        protected void OnProp(string member) => PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(member));
    }
}
