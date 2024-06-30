using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int Damage1;
    [SerializeField] private int Damage2;

    [SerializeField] private Collider2D SwordCollider;

    private int DamageToEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) DamageToEnemy = Damage1;
        if (Input.GetKeyDown(KeyCode.Mouse1)) DamageToEnemy = Damage2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log(collision.tag + " " + collision.GetComponent<Enemy_Health>().currentHealth);
            collision.GetComponent<Enemy_Health>().TakeDamage(DamageToEnemy);
            //if (Input.GetKeyDown(KeyCode.Mouse1)) collision.GetComponent<Enemy_Health>().TakeDamage(Damage2);

        }
    }
}
