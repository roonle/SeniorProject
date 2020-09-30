using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject letterObject;
    
    public string letter;

    public bool dropped = false;
    // Start is called before the first frame update
   public void OnDrop(PointerEventData eventData){
       Debug.Log("OnDrop");
       
       letterObject = eventData.pointerDrag;
       letter = letterObject.GetComponent<DragDrop>().letter;
       dropped = true;
       if(eventData.pointerDrag != null){
           eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
           
       }
   }
   
}
