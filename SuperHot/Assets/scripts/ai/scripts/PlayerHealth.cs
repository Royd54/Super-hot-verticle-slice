using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 1;


    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
