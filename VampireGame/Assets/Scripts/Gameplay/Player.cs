using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    //should probably make sure that the vamp can't be in negative shadows... 
    public int shaded = 0;
    public int layerColliderCounter = 0;
    public HealthBar healthBar;
    public int LightIntensity = 10;
    private Color startColor;
    private Renderer spriteRenderer;
    public Color shadedColor;
    public bool day = true;
    public Vector2 levelStart;
    private Animator animator;
    public Animator transitionWipeAnimator;
    public List<Renderer> shadowRenderers;
    public PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        levelStart = transform.position;
        spriteRenderer = GetComponent<Renderer>();
        startColor = spriteRenderer.material.GetColor("_Color");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
        shadowRenderers = new List<Renderer>();
        foreach (GameObject shadow in GameObject.FindGameObjectsWithTag("shadow"))
        {
            shadowRenderers.Add(shadow.GetComponent<Renderer>());
        }


       
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (healthBar == null || transitionWipeAnimator == null)
            {
                //Find the healthbar, and the animator and set us as the ref
                GameObject hpBar = GameObject.FindGameObjectWithTag("HealthBar");
                healthBar = hpBar.GetComponent<HealthBar>();
                GameObject wipeAnim = GameObject.FindGameObjectWithTag("TransitionAnimator");
                transitionWipeAnimator = wipeAnim.GetComponent<Animator>();
            }

            //TODO better layer sorting for objects that are close to one another. 
            //spriteRenderer.sortingOrder = (int)transform.position.y;

            if (day)
            {
                CheckShade();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Fire2"))
            {
                if (day)
                {
                    day = false;
                    transitionWipeAnimator.Play("day_to_night");
                }
                else
                {
                    day = true;
                    transitionWipeAnimator.Play("night_to_day");
                }
                ToggleShadows(day);
                Debug.Log("Sleeptime");
                animator.Play("vamp_coffin_in");
            }
        }
    }

    private void CheckShade()
    {
        if (shaded <= 0)
        {
            //ouch sunlight!
            if (currentHealth > 0)
                currentHealth -= Time.deltaTime * LightIntensity;
            spriteRenderer.material.SetColor("_Color", startColor);
        }
        else
        {
            //be shaded
            spriteRenderer.material.SetColor("_Color", shadedColor);
            if (currentHealth < maxHealth)
                currentHealth += Time.deltaTime * LightIntensity;
        }

        healthBar.SetHealth((int)currentHealth);

        if (currentHealth <= 0)
        {
            animator.Play("vamp_die");
            currentHealth += 5;
        }
    }
    
    private void DiurnalTransition()
    {
        transform.position = levelStart;
        //set the level to be day or night
        animator.Play("vamp_coffin_out");
    }

    private void ToggleShadows(bool condition)
    {
        foreach (Renderer renderer in shadowRenderers)
        {
            renderer.enabled = condition;
        }
    }
}
