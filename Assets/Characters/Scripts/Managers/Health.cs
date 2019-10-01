using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;

    private Animator anim;
    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
    currentHealth += amount;
    Debug.Log("healthdecreasingdafatfasdf"); 
    float currentHealthPct = (float)currentHealth / (float)maxHealth;
    OnHealthPctChanged(currentHealthPct);
    }
    
    void Update()
    {
        Die();
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            anim.SetInteger("Transition", 9);
        }
    }
}
