using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    private Savedata data = new Savedata();

    public void OnClickLoadData()
    {
        Load();
    }

    public void OnClickSaveData()
    {
        Save();
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/saves/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);

            data = (Savedata)bf.Deserialize(file);

            CopyLoadData();

            file.Close();

            SceneManager.LoadScene(SceneIndexes.WorldMap());
        }

        
    }

    public void Save()
    {
        if (!Directory.Exists(Application.dataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/saves");
        }
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");

        CopySaveData();

        bf.Serialize(file, data);

        file.Close();
    }

    public static SerVector3 Vector3ToSerVector3(Vector3 v3)
    {
        SerVector3 sv3 = new SerVector3
        {
            x = v3.x,
            y = v3.y,
            z = v3.z
        };

        return sv3;
    }

    public static Vector3 SerVector3ToVector3(SerVector3 sv3)
    {
        Vector3 v3 = new Vector3
        {
            x = sv3.x,
            y = sv3.y,
            z = sv3.z
        };

        return v3;
    }

    public void CopySaveData()
    {
        data.ResourcesCount = PlayerStatus.ResourcesCount;
        data.GoldCount = PlayerStatus.GoldCount;
        data.ShipPos = Vector3ToSerVector3(PlayerStatus.ShipPos);
        data.ShipHealthMax = PlayerStatus.ShipHealthMax;
        data.ShipHealthCurrent = PlayerStatus.ShipHealthCurrent;
        data.AmmoCount = PlayerStatus.AmmoCount;

        data.islandLocations = new List<SerVector3>();

        foreach (Vector3 v3 in IslandStats.IslandLocations)
        {
            data.islandLocations.Add(Vector3ToSerVector3(v3));
        }
        ///copy globals into save data here
    }

    public void CopyLoadData()
    {
        PlayerStatus.ResourcesCount = data.ResourcesCount;
        PlayerStatus.GoldCount = data.GoldCount;
        PlayerStatus.ShipPos = SerVector3ToVector3(data.ShipPos);
        PlayerStatus.ShipHealthMax = data.ShipHealthMax;
        PlayerStatus.ShipHealthCurrent = data.ShipHealthCurrent;
        PlayerStatus.AmmoCount = data.AmmoCount;

        IslandStats.IslandLocations = new List<Vector3>();

        foreach(SerVector3 sv3 in data.islandLocations)
        {
            IslandStats.IslandLocations.Add(SerVector3ToVector3(sv3));
        }
        
        //copy globals to globals from save data here
    }
}
[System.Serializable]
public class SerVector3
{
    public float x;
    public float y;
    public float z;
}

[System.Serializable]
public class Savedata
{
    //Player Stat Globals
    public  int ResourcesCount;
    public  int GoldCount;
    public SerVector3 ShipPos;
    public int ShipHealthMax;
    public int ShipHealthCurrent;
    public int AmmoCount;

    //Island stat globals

    public List<SerVector3> islandLocations;



}
