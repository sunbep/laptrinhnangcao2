
using UnityEngine;

public class HealCollect : MonoBehaviour
{
    [SerializeField] private int healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide with object");
        if (collision.tag == "Player")
        {
            Debug.Log("collide with player");
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);

        }
    }
}

