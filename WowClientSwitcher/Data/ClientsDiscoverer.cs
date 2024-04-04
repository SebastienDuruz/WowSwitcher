using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WowClientSwitcher.Data;

public class ClientsDiscoverer
{
    public List<Process> WowProcesses { get; private set; } = new();

    public void RefreshProcessList()
    {
        WowProcesses.Clear();
        foreach (Process process in Process.GetProcesses())
        {
            if (process.MainWindowHandle == IntPtr.Zero)
                continue;
            if (process.MainWindowTitle.ToLower().Equals(SettingsReader.GetInstance.UserSettingsValues.WowClientIdentifier.ToLower()))
                WowProcesses.Add(process);
        }
    }
}