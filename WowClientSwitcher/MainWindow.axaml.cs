using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using WowClientSwitcher.Data;

namespace WowClientSwitcher;

public partial class MainWindow : Window
{
    private StackPanel _clientsGrid;
    private DispatcherTimer _timer;
    private readonly ClientsDiscoverer _clients = new ClientsDiscoverer();
    private List<Button> _clientsButtons = new List<Button>();
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    
    public MainWindow()
    {
        InitializeComponent();
        this.Opened += OnInitialized;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        _clientsGrid = this.FindControl<StackPanel>("clientsGrid");
    }

    private void OnInitialized(object? sender, EventArgs e)
    {
        InitializeTimer();
    }
    
    private void InitializeTimer()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(5);
        _timer.Tick += async (sender, e) => await RefreshWowClients();
        _timer.Start();
    }
    
    private Task RefreshWowClients()
    {
        _clients.RefreshProcessList();
        foreach(Button client in _clientsButtons)
            _clientsGrid.Children.Remove(client);
        _clientsButtons.Clear();

        for (int i = 0; i < _clients.WowProcesses.Count; ++i)
        {
            Button clientButton = new Button()
            {
                Padding = new Thickness(
                    SettingsReader.GetInstance.UserSettingsValues.PaddingX, 
                    SettingsReader.GetInstance.UserSettingsValues.PaddingY),
                Content = $"Client {i + 1}",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            clientButton.Click += ClientButtonOnClick;
            _clientsButtons.Add(clientButton);
        }
        _clientsGrid.Children.AddRange(_clientsButtons);
        return Task.CompletedTask;
    }

    private void ClientButtonOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            string clientNumber = ((string)((Button)sender).Content).Split(" ")[1];
            int clientIndex = int.Parse(clientNumber) - 1;
            SetForegroundWindow(_clients.WowProcesses[clientIndex].MainWindowHandle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        this.BeginMoveDrag(e);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}