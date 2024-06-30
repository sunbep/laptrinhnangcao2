using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    public bool dead = false;
    public float currentHealth { get; private set; }
    private Animator anim;

    private void Awake()
    {
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
            anim.SetTrigger("Die");
            GetComponent<Playermovement>().enabled = false;
            dead = true;
        }
    }
    public void AddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > startingHealth) currentHealth = startingHealth;
        if (currentHealth < 0) currentHealth = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) { currentHealth = startingHealth; }
    }
}
