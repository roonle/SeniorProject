using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using Object = System.Object;

public static class SaveSystem 
{
   public static void SavePlayer(Player player){

       BinaryFormatter formatter = new BinaryFormatter();

       string path = Application.persistentDataPath + "/player.data";
       FileStream playerStream = new FileStream(path,FileMode.Create);

       PlayerData data = new PlayerData(player);

       formatter.Serialize(playerStream, data);
       playerStream.Close();

   }
   public static PlayerData LoadPlayer(){

       string path = Application.persistentDataPath + "/player.data";

       if(File.Exists(path))
       {
           BinaryFormatter formatter = new BinaryFormatter();
           FileStream playerStream = new FileStream(path,FileMode.Open);
           PlayerData data = formatter.Deserialize(playerStream) as PlayerData;
           playerStream.Close();

           return data;

       } else
       {

           Debug.LogError("Save file not found in" + path);
           return null;
       }

   }
   
   public static void saveQuestInventory(List<SavedQuest> list)
   {
       BinaryFormatter formatter = new BinaryFormatter();
       
       string path = Application.persistentDataPath + "/QuestInventory.data"; 
       FileStream playerStream = new FileStream(path,FileMode.Create);

       formatter.Serialize(playerStream,list);
       Debug.Log("how many quest were saved " + list.Count);
       playerStream.Close();
   }
   public static List<SavedQuest> loadQuestInventory(){

       string path = Application.persistentDataPath + "/QuestInventory.data";

       if(File.Exists(path))
       {
           List<SavedQuest> list = new List<SavedQuest>();
           BinaryFormatter formatter = new BinaryFormatter();
           FileStream playerStream = new FileStream(path,FileMode.Open);
           list = formatter.Deserialize(playerStream) as List<SavedQuest>;
           playerStream.Close();

           return list;

       } else
       {
           Debug.LogError("Save file not found in" + path);
           return null;
       }

   }
   
   public static void saveInventory(List<object> list)
   {
       BinaryFormatter formatter = new BinaryFormatter();
       
       string path = Application.persistentDataPath + "/Inventory.data"; 
       FileStream playerStream = new FileStream(path,FileMode.Create);
       var json = JsonUtility.ToJson(list);

       formatter.Serialize(playerStream,json);
       playerStream.Close();
   }

   public static List<object> loadInventory()
   {
       string path = Application.persistentDataPath + "/Inventory.data";

       if (File.Exists(path))
       {
           BinaryFormatter formatter = new BinaryFormatter();
           FileStream playerStream = new FileStream(path, FileMode.Open); 
           List<object> data = formatter.Deserialize(playerStream) as List<object>;
           playerStream.Close();
           return data;
       }
       else
       {
           Debug.LogError("No Save File For inventory found in " + path);
           return null;
       }
   }

   
}
