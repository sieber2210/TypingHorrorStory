using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGameData(CheckTyping checkTyping)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(checkTyping);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadGameData()
    {
        string path = Application.persistentDataPath + "/data.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void CreateSaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(1);

        formatter.Serialize(stream, data);
        stream.Close();
    }
}
