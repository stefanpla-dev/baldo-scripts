using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    private Animator anim;
    public bool upsideDown;
    private PlayerMovement movementScript;
    [SerializeField] private AudioClip gravitySwap;

    private void Start()
    {
        // Get the animator component as well as the player movement script.
        anim = GetComponent<Animator>();
        movementScript = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        // Can only utilize grvity swapping if the player is still alive. Specification due to a hilarious bug.
        if (movementScript.isAlive == true)
        {
            //Flip the player, and the effects of gravity, upside down when the player presses the W and S keys. 
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Play the jump animation (slight stretching of the character) as well as its sound when this happens.
                SoundManager.instance.PlaySound(gravitySwap);
                Physics2D.gravity = new Vector2(0f,9.81f);
                transform.eulerAngles = new Vector3(180,0,0);
                anim.SetTrigger("jump");
                upsideDown = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                SoundManager.instance.PlaySound(gravitySwap);
                Physics2D.gravity = new Vector2(0f,-9.81f);
                transform.eulerAngles = new Vector3(0,0,0);
                anim.SetTrigger("jump");
                upsideDown = false;
            }
        }
    }
}
