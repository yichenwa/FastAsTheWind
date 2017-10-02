using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Baseitem : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAsset/Items.json"));
        ConstructItemDataBase();

        Debug.Log(GetItemByID(1).Description);
    }

    public Item GetItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDataBase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["power"],
                                  (int)itemData[i]["ammo"], itemData[i]["description"].ToString(), (bool)itemData[i]["stackable"]));
        }
    }
}
    public class Item{
        public int ID { get; set; }
        public string Title { get; set; }
        public int Power { get; set; }
        public int Ammo { get; set; }
        public string Description { get; set; }
        public bool Stackable { get; set; }

        public Item(int id, string title, int power, int ammo, string description, bool stackable){
            this.ID = id;
            this.Title = title;
            this.Power = Power;
            this.Ammo = ammo;
            this.Description = description;
            this.Stackable = stackable;
        }

        public Item(){
            this.ID = -1;
        }
    }

