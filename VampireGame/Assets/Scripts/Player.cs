using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public bool shaded = false;
    public HealthBar healthBar;
    public int LightIntensity = 10;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
    }

    private void Update()
    {
        if (!shaded)
        {
            currentHealth -= Time.deltaTime * LightIntensity;
            healthBar.SetHealth((int)currentHealth);
        }
    }

}
