using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Inventory : MonoBehaviour
{
    #region Singleton
    
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("warning more than one instance of inventory");
            return;
        }
        instance = this;
    }

    #endregion

    public List<Item> items;
    private List<object> saveItems;
   /* void Start()
    {
        List<object> data = SaveSystem.loadInventory();

        if (data != null)
        {
            items = new List<Item>();
            for (int i = 0; i < data.Count; i++)
            {
                items.Add((Item)data[i]);
            }
        }
        else
        {
            items = new List<Item>();
        }
    }*/

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    //public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("no more room");
                return false;
            }
            items.Add(item);
            
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    /*public void saveInventory()
    {
        saveItems = new List<object>();

        for (int i = 0; i < items.Count; i++)
        {
            saveItems.Add(items[i]);
        }
        SaveSystem.saveInventory(saveItems);
    }*/

    public void Remove(Item item)
    {
        items.Remove(item);
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
