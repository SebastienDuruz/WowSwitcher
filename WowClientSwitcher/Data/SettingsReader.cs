using System;
using System.IO;
using Newtonsoft.Json;
using WowClientSwitcher.Data.Models;

namespace WowClientSwitcher.Data;

public sealed class SettingsReader
{
    private static SettingsReader _instance = null;
    private string FolderPath { get; } =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
    private string ConfigFileName { get; } = "settings.json";
    private string FullConfigPath { get; }
    public UserSettings UserSettingsValues { get; private set; }

    public static SettingsReader GetInstance
    {
        get
        {
            if (_instance == null)
                _instance = new SettingsReader();
            return _instance;
        }
    }

    private SettingsReader()
    {
        if(!Directory.Exists(Path.Combine(FolderPath, StaticData.APPLICATION_NAME)))
            Directory.CreateDirectory(Path.Combine(FolderPath, StaticData.APPLICATION_NAME));
        FullConfigPath = Path.Combine(Path.Combine(FolderPath, StaticData.APPLICATION_NAME), ConfigFileName);
        ReadUserSettings();
    }
    
    public void ReadUserSettings()
    {
        if(File.Exists(FullConfigPath))
        {
            try
            {
                UserSettingsValues = JsonConvert.DeserializeObject<UserSettings>(File.ReadAllText(FullConfigPath));
            }
            catch (Exception ex)
            {
                // Reset the settings by recreating a file
                WriteUserSettings();
                UserSettingsValues = new UserSettings();
            }
        }
        else
        {
            UserSettingsValues = new UserSettings();
            WriteUserSettings();
        }
    }
    
    public void WriteUserSettings()
    {
        try
        {
            File.WriteAllText(FullConfigPath, JsonConvert.SerializeObject(UserSettingsValues));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}