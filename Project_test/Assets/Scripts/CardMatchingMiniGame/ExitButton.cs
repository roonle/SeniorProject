using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private string targetText;
    public Color highlight = Color.blue;

    public void OnMouseExit()
    {
        SpriteRenderer img = GetComponent<SpriteRenderer>();
        if (img != null)
        {
            img.color = Color.white;
            
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.4f,0.4f,01.0f);
    }

    public void OnMouseOver()
    {
        SpriteRenderer img = GetComponent<SpriteRenderer>();
        if (img != null)
        {
            img.color = highlight;
            
        }
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.3f,0.3f,1.0f);
        if (target != null)
        {
            target.SendMessage(targetText);
        }
    }
}
