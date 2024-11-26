using SakuyoTxtAdvApp.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

class SaveSystem :Singleton<SaveSystem>
{
    public SaveData? Data;
    public bool IsExist(string fileName) 
    {
        return File.Exists(Path.Combine(FileSystem.AppDataDirectory, fileName));
    }

    public void Delete(string fileName) 
    {
        if (File.Exists(fileName)) File.Delete(fileName);
    }

    public async void Load(string fileName) 
    {
        if (IsExist(fileName)) 
        {
            //DataContractJsonSerializer jf = new(typeof(SaveData));
            using FileStream file = File.Open(Path.Combine(FileSystem.AppDataDirectory, fileName), FileMode.Open);
            Data = await JsonSerializer.DeserializeAsync<SaveData>(file);
        }
    }

    public async void Save(string fileName) 
    {
        using FileStream file = File.Create(Path.Combine(FileSystem.AppDataDirectory, fileName));
        await JsonSerializer.SerializeAsync(file, Data);
        await file.DisposeAsync();
    }
}

class SaveData 
{
    public Player Player;
    public Stat Stat;
    public Config Config;
}