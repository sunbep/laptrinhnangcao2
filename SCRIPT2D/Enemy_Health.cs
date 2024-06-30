using System;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private Enemy_group Enemy_details;
    [SerializeField] private Rigidbody2D rigid_body;
    private float startingHealth;
    public bool dead = false;
    public float currentHealth { get; private set; }
    private Animator anim;


    private void Awake()
    {
        startingHealth = Enemy_details.startingHealth;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > startingHealth) currentHealth = startingHealth;
        if (currentHealth < 0) currentHealth = 0;

        if (currentHealth > 0)
        {
            // take hurt
            anim.SetTrigger("Hurt");
        }
        else
        {
            // go dead
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponentInParent<Patroll>().enabled = false;
                GetComponent<MeleeEnemy>().enabled = false;
                rigid_body.simulated = false;
                dead = true;

            }
        }
    }
}
