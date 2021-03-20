using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float characterSpeed = 1.0f;
    public float dashSpeed = 10f;
    private Vector2 inputDir;
    public Animator animator;
    private Rigidbody2D playerPhysics;
    private Vector2 still = new Vector2(0, 0);

    void Awake()
    {

        playerPhysics = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // BASIC MOVEMENT STUFF
        float VertInput = Input.GetAxisRaw("Vertical");
        float HorInput = Input.GetAxisRaw("Horizontal");
        inputDir = new Vector2(HorInput, VertInput).normalized;
        if (HorInput < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (HorInput > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;

        }
        if (inputDir != still)
        {
            animator.SetBool("Running", true);
        }else
        {
            animator.SetBool("Running", false);
        }

        // DASH 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //want to move the pkayer the direction they are facing
            Debug.Log("Dashing");
            playerPhysics.MovePosition(playerPhysics.position + inputDir * characterSpeed);
        }

    }

    void FixedUpdate()
    {
        playerPhysics.MovePosition(playerPhysics.position + inputDir * dashSpeed * Time.fixedDeltaTime);

    }
}
