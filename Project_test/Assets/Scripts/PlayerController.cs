using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    private Camera cam;
    private PlayerMotor motor;
    public bool canMove;

    
    
    
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        canMove = true;
        

    }

    

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //when mouse clicks on map character will move there
            
            
            if (Physics.Raycast(ray, out hit, 100, movementMask) && canMove == true)
            {
                //Debug.Log();
                motor.moveToPoint(hit.point);
                removeFocus();
            }
        }
        
        //when right click is pressed on object focus on it
        if (Input.GetMouseButtonDown(1) && canMove == true) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    setFocus(interactable);
                }
            }
        }

        void setFocus(Interactable newFocus)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                {
                    focus.onDeFocused(); 
                }
                
                focus = newFocus;
                motor.followTarget(newFocus);
            }
            
            newFocus.onFocused(transform);
            
            
        }

        void removeFocus()
        {
            if (focus != null)
            {
                focus.onDeFocused();
            }
            
            focus = null;
            motor.stopFollowingTarget();
        }
    }
}
