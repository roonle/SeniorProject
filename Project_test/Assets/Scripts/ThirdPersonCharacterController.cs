using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

    public float Speed;
    //public AnimatorControllerParameter AnimState;
    
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        int AnimState = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //run animation
                AnimState = 2;
                Speed = 9;

            }
            else
            {
                //walk animation
                AnimState = 1;
                Speed = 4;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Speed = 3;
        }
        else
        {
            //idle animation
            AnimState = 0;
            Speed = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            AnimState = 4;
        }


        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(hor, 0f, vert) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        animator.SetInteger("condition", AnimState);

    }
}
