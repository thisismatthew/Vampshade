using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    //should probably make sure that the vamp can't be in negative shadows... 
    public int shaded = 0;
    public HealthBar healthBar;
    public int LightIntensity = 10;
    private Color startColor;
    public Color shadedColor;

    void Start()
    {
        startColor = GetComponent<Renderer>().material.GetColor("_Color");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
    }

    private void Update()
    {
        if (shaded > 0)
        {
            currentHealth -= Time.deltaTime * LightIntensity;
            healthBar.SetHealth((int)currentHealth);
            //be shaded
            GetComponent<Renderer>().material.SetColor("_Color", shadedColor);
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_Color", startColor);
        }
    }

}
