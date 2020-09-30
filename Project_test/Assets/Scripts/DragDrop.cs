using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IDragHandler, IPointerClickHandler
{
    public string letter;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] public Canvas canvas;

    public Vector3 spawnPos;

    public GameObject letterObject;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        spawnPos = this.transform.position;
    }
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnpointerDown");
        
        
    }
    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");


        letterObject = eventData.pointerDrag;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        letter = name;
        
        FindObjectOfType<AudioManager>().Play(name);
        
    }


    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        
    }
    public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag ");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("clicked on");
    }
    
    
}
