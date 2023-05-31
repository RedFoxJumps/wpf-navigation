using System.Collections.Generic;

namespace Navigation.WPF;

public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; }

    void RegisterRoute(string route, ViewModelBase viewModel);

    void Navigate(string route);
}

public class NavigationService : ViewModelBase, INavigationService
{
    protected Dictionary<string, ViewModelBase> NavigationStore = new ();

    private ViewModelBase _current;
    public ViewModelBase CurrentViewModel
    {
        get => _current;
        protected set => Set(ref _current, value);
    }

    public override string CurrentPage => throw new System.NotImplementedException();

    public void Navigate(string route)
    {
        if (!NavigationStore.ContainsKey(route))
        {
            return;
        }

        CurrentViewModel = NavigationStore[route];
    }

    public void RegisterRoute(string route, ViewModelBase viewModel)
    {
        NavigationStore[route] = viewModel;
    }
}
