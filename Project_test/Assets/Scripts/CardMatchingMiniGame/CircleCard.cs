using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCard : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject CardBack;
    private int _id;

    public void OnMouseDown()
    {
        if (CardBack.activeSelf && gameManager.canReveal())
        {
            CardBack.SetActive(false);
            gameManager.revealedCard(this);
        }
    }

    public int id
    {
        get {
            return _id;
        }
    }

    public void changeImage(int id, Sprite img)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = img;
    }

    public void unreveal()
    {
        CardBack.SetActive(true);
    }
    
    
}
