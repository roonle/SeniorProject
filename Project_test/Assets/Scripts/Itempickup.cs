
using UnityEngine;

public class Itempickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        itempickUp();
        
    }

    void itempickUp()
    {
        Debug.Log("Pick up item " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }
    
}
