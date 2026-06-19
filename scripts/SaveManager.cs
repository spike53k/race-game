using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public int currentCar;
    public float bestTime;

    string path;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        path = Application.persistentDataPath + "/save.dat";
        Load();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);

        Data data = new Data();
        data.currentCar = currentCar;
        data.bestTime = bestTime;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (!File.Exists(path))
            return;

        FileStream file = File.Open(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();

        try
        {
            Data data = (Data)bf.Deserialize(file);

            currentCar = data.currentCar;
            bestTime = data.bestTime;
        }
        catch
        {
            Debug.LogWarning("Save file corrupted, resetting...");
            currentCar = 0;
            bestTime = 0;
        }

        file.Close();
    }
}

[System.Serializable]
class Data
{
    public int currentCar;
    public float bestTime;
}