using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
        startColor = spriteRenderer.material.GetColor("_Color");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
    }

    private void Update()
    {
        //spriteRenderer.sortingOrder = (int)((transform.position.x + transform.position.y));

        if (shaded <= 0)
        {
            //ouch sunlight!
            currentHealth -= Time.deltaTime * LightIntensity;
            healthBar.SetHealth((int)currentHealth);
            spriteRenderer.material.SetColor("_Color", startColor);
        }
        else
        {
            //be shaded
            spriteRenderer.material.SetColor("_Color", shadedColor);

        }
    }

}
