using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Enemy_group MeleeEnemy_details;


    private float attackCooldown;
    private float range;
    private float distance;
    private int damage;
    private int criticalDamage;

    private float cooldownTimer = Mathf.Infinity;
    private int randomAttack;

    private Animator anim;

    private Health playerHealth;

    private Patroll enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<Patroll>();
    }
    private void Start()
    {
        attackCooldown = MeleeEnemy_details.attackCooldown;
        range = MeleeEnemy_details.detectRange;
        distance = MeleeEnemy_details.detectDistance;
        damage = MeleeEnemy_details.damage;
        criticalDamage = MeleeEnemy_details.criticalDamage;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //attack only player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //attack
                if (!playerHealth.dead)
                {
                    cooldownTimer = 0;
                    if (randomAttack <= 3) anim.SetTrigger("Attack1");
                    else anim.SetTrigger("Attack2");
                }
            }
        }

        if(enemyPatrol != null) enemyPatrol.enabled = !PlayerInSight();
        
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capsuleCollider.bounds.center + transform.right * distance * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), 
            new Vector3(capsuleCollider.bounds.size.x * range, capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer); 
        
        if (hit.collider != null) playerHealth = hit.collider.GetComponent<Health>();
        
        return (hit.collider != null);
    }
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            //Damage player health
            randomAttack = Random.Range(0, 10);
            if (randomAttack <= 3) playerHealth.TakeDamage(damage);
            else playerHealth.TakeDamage(criticalDamage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(capsuleCollider.bounds.center + transform.right * distance * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), 
            new Vector3(capsuleCollider.bounds.size.x * range, capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z));
    }
}
