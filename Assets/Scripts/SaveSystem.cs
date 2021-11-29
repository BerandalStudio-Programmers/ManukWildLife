using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem
{

    public static void SavePlayer(PlayerMovement player){

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved");

    }

    public static PlayerData LoadPlayer(){

        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {  
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            
            Debug.Log("Loaded");
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
            
        }else{

            Debug.LogError("Save is not al ready" + path);
            return null;

        }

    }

}
