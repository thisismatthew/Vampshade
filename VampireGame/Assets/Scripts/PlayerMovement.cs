using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float characterSpeed = 1.0f;
    public Vector2 inputDir;
    public Animator animator;
    private Rigidbody2D rb;
    public float dashSpeed;
    public GameObject TransformCloudEffect;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ENABLE MOVEMENT STUFF
        if (VampDefaultMotion())
        {
            GetMovementInput();
        }

        // ENABLE DASH
        if (Input.GetKeyDown(KeyCode.Space) && !VampStationary())
        {
            Instantiate(TransformCloudEffect, transform.position, transform.rotation);
            animator.Play("vamp_bat");
        }

    }

    void FixedUpdate()
    {
        //EXECUTE MOVEMENT & DASH PHYSICS
        if (VampDashing())
        {
            Debug.Log("dashing");
            rb.velocity = inputDir * dashSpeed;          
        }
        if(VampDefaultMotion())
        {
            rb.MovePosition(rb.position + inputDir * characterSpeed * Time.fixedDeltaTime);
            rb.velocity = Vector2.zero;
        }
        if (VampStationary())
        {
            rb.velocity = Vector2.zero;
        }
    }

    private bool VampStationary()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("vamp_die") 
            || animator.GetCurrentAnimatorStateInfo(0).IsName("vamp_coffin_in")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("vamp_coffin_out"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool VampDefaultMotion()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("vamp_run") 
            || animator.GetCurrentAnimatorStateInfo(0).IsName("vamp_idle"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool VampDashing()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("vamp_bat"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GetMovementInput()
    {
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
        if (inputDir != Vector2.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
