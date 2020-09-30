using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Chad_interaction : Interactable
{
    public Text chat;
    public string text;
    Camera cam;

    public delegate void InteractedDelegate(Chad_interaction chad);

    public static event InteractedDelegate InteractEvent;
    
    private void Start()
    {
        cam = Camera.main;
        ID = 0;
    }

    public override void Interact()
    {
        base.Interact();
        talk();
        if (InteractEvent != null)
        {
            InteractEvent.Invoke(this);
        }
        
        
    }

    public void LateUpdate()
    {
        //chat.transform.SetPositionAndRotation(transform.parent.position, Quaternion.identity);
       Vector2 pos = cam.WorldToScreenPoint(interactionTransform.position);
       chat.transform.SetPositionAndRotation(pos, Quaternion.identity);
    }

    void talk()
    {
        
        chat.gameObject.SetActive(true);
        chat.text = (gameObject.name + ": "+ text);
        StartCoroutine("waitToDrop");
        
    }

     IEnumerator waitToDrop()
    {
        yield return new WaitForSeconds(5);
        chat.text = "";
        chat.gameObject.SetActive(false);

    }



}
