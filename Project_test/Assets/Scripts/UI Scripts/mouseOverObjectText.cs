using UnityEngine.UI;
using UnityEngine;

public class mouseOverObjectText : MonoBehaviour
{

    private Camera cam;
    public Text ObjectName;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 100);

        if (hit.transform != null)//if mouse is over game object
        {
            if (hit.transform.gameObject.tag == "Interactable")//if object is interactable
            {

                ObjectName.text = hit.transform.gameObject.name;
                ObjectName.transform.SetPositionAndRotation(Input.mousePosition, Quaternion.identity);
            }
            else
            {
                ObjectName.text = "";
            }
        }


    }
}
