using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Name";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void use()
    {
        //use item
        
        Debug.Log("useing " + name);
    }
}
