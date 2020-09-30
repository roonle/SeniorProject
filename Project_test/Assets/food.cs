using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class food : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    public Transform pizza;

    [SerializeField]
    private Canvas canvas;

    private RectTransform pep;

    private Vector2 startingpos;

    private Vector2 mousePos;

    private float x1, y1;

    private bool locked;

    // Start is called before the first frame update

    private void Awake()
    {
        pep = GetComponent<RectTransform>();
    }

    void Start()
    {
        startingpos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!locked)
        {
            mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //transform.position = new Vector2(mousePos.x - x1, mousePos.y - y1);
            pep.anchoredPosition += eventData.delta / canvas.scaleFactor;
            Debug.Log("dragging");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(transform.position.x - pizza.position.x) <= .5f && Mathf.Abs(transform.position.y - pizza.position.y) <= .5f)
        {
            transform.position = new Vector2(pizza.position.x, pizza.position.y);
            locked = true;
            Debug.Log("on pizza");
        }
        Debug.Log("drag end");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("drag begin");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!locked)
        {
            x1 = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            y1 = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
        Debug.Log("pointer down");
    }

}
