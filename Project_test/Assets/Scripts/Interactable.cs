
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    public int ID;
    
    public bool isFocus = false;
    public Transform player;
    
    public bool hasInteracted = false;
    public AudioClip sound;
    private AudioSource interactionSound;

    public int iD { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public virtual void Interact()
    {
        //this method is meant to be overriden
        
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;

                if (sound != null) 
                    interactionSound.Play();
            }
        }
    }
    public void onFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;


        if (interactionSound == null && sound != null)
        {

            interactionSound = gameObject.AddComponent<AudioSource>();
            interactionSound.clip = sound;

            //will not loop audioSource
            interactionSound.loop = false;

            interactionSound.dopplerLevel = 0.0f;
            interactionSound.spatialBlend = 0.0f;
            interactionSound.volume = 1;
            interactionSound.playOnAwake = false;

        }
    }

    public void onDeFocused()
    {
        isFocus = false;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }


}
