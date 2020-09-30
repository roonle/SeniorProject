using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonCamera : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public GameObject player;

    public Transform Obstruction;
    float zoomSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void LateUpdate()
    {
        CamControl();
        ViewObstructed();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //SceneManager.LoadScene("Pause");
        }
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -35, 60);
        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        if ( ! Input.GetKey(KeyCode.Tab) )
        {
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    void ViewObstructed()
    {
        Transform lastObj = Obstruction;//should probably get rid of this

        RaycastHit hit;

        //checks if anything is colliding with cam
        if( Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f) )
        {
            //if the thing colliding is NOT the player
            if(hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;//store the thing being collided with

                //tell that objects renderer to ONLY render the shadows of that object!
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                //if distance between obstruction and cam pos is greater than 3
                // and if distance between cam position and target position is greater than 1.5
                // then zoom the camera
                if(Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {

                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

                //zooms camera back out
                if(Vector3.Distance(transform.position, Target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }


            //should probably get rid of this
            if(lastObj != Obstruction)
            {
                lastObj.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }
    }


}
