using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float CharacterSpeed = 1.0f;
    private Vector2 InputDir;
    public Animator animator;
    public Rigidbody2D PlayerPhysics;
    public Vector2 WhereAmI;
    public Vector2 WhereTo;

    void Awake()
    {

        PlayerPhysics = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        float VertInput = Input.GetAxis("Vertical");
        float HorInput = Input.GetAxis("Horizontal");
        InputDir = new Vector2(HorInput, VertInput).normalized;
        
        if (HorInput < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (HorInput > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (WhereAmI != WhereTo)
        {
            animator.SetBool("Running", true);
        }else
        {
            animator.SetBool("Running", false);
        }

    }

    void FixedUpdate()
    {

        WhereAmI = PlayerPhysics.position;
        WhereTo = WhereAmI + (InputDir * CharacterSpeed) * Time.fixedDeltaTime;
        PlayerPhysics.MovePosition(WhereTo);

    }
}
