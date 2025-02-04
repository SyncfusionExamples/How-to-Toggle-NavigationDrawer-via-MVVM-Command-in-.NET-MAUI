This article explains how to toggle the [.NET MAUI NavigationDrawer](https://www.syncfusion.com/maui-controls/maui-navigationdrawer) using `MVVM` commands in an application. Using commands instead of event handlers enhances modularity, testability, and maintains a clean separation between UI and logic.

**ViewModel**

Define a ViewModel with a property to track the drawer's state and a command to toggle it:
```
public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool _isDrawerOpen;
    public bool IsDrawerOpen
    {
        get => _isDrawerOpen;
        set
        {
            _isDrawerOpen = value;
            OnPropertyChanged(nameof(IsDrawerOpen));
        }
    }

    public ICommand ToggleDrawerCommand { get; }

    public MainPageViewModel()
    {
        ToggleDrawerCommand = new Command(ToggleDrawer);
    }

    private void ToggleDrawer()
    {
        IsDrawerOpen = !IsDrawerOpen;
    }
}
```

**Setting the BindingContext**

Ensure that the ViewModel is set as the BindingContext of the page:

```
<ContentPage.BindingContext>
    <local:MainPageViewModel/>
</ContentPage.BindingContext>
```

**XAML**

Bind the [IsOpen](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.NavigationDrawer.SfNavigationDrawer.html#Syncfusion_Maui_NavigationDrawer_SfNavigationDrawer_IsOpen) property of NavigationDrawer to `IsDrawerOpen` and the toggle command to an ImageButton in the XAML file:

```
<navigationdrawer:SfNavigationDrawer x:Name="navigationDrawer" IsOpen="{Binding IsDrawerOpen, Mode=TwoWay}">
    <navigationdrawer:SfNavigationDrawer.ContentView>
        <Grid x:Name="mainContentView" BackgroundColor="White" RowDefinitions="Auto,*">
            <HorizontalStackLayout BackgroundColor="#6750A4" Spacing="10" Padding="5,0,0,0">
                <ImageButton x:Name="hamburgerButton"
                             Source="hamburgericon.png"
                             Command="{Binding ToggleDrawerCommand}"/>
            </HorizontalStackLayout>
        </Grid>
    </navigationdrawer:SfNavigationDrawer.ContentView>
</navigationdrawer:SfNavigationDrawer>
```

By following these steps, you can toggle the NavigationDrawer using an MVVM command instead of event handlers, making your application more modular and testable.

**Output**

![MauiDrawer_Toggle.gif](https://support.syncfusion.com/kb/agent/attachment/article/19021/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjM1NDU1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.OU7ouAVTl3HVeej_bJYfzQW4RXuqHjZMs6I_TQ9p1uU)

**Requirements to run the demo**

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

**Troubleshooting:**

**Path too long exception** 

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.