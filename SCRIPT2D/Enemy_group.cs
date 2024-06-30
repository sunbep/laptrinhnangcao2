using UnityEngine;

public class Enemy_group : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Details")]
    [SerializeField] public int damage;
    [SerializeField] public int criticalDamage;
    [SerializeField] public float startingHealth;
    [SerializeField] public float attackCooldown;
    [SerializeField] public float detectRange;
    [SerializeField] public float detectDistance;

    [Header ("Patrolling")]
    [SerializeField] public float Speed;
    [SerializeField] public float idleDuration;
}
