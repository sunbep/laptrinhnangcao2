using UnityEngine; 

public class Patroll : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemyTaget;
    [SerializeField] private Animator anim;

    [SerializeField] private Enemy_group Enemy_details;

    private float Speed;
    private float idleDuration;

    private bool MovingLeft = false;
    private float idleTimer;

    private void Start()
    {
        Speed = Enemy_details.Speed;
        idleDuration = Enemy_details.idleDuration;
    }
    private void Update()
    {
        if (MovingLeft)
        {
            if (enemyTaget.position.x >= leftEdge.position.x) MoveInDirection(-1);
            else
            {
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleDuration) MovingLeft = !MovingLeft;
                anim.SetBool("moving", false);
            }
        }
        else
        {
            if (enemyTaget.position.x <= rightEdge.position.x) MoveInDirection(1);
            else
            {
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleDuration) MovingLeft = !MovingLeft;
                anim.SetBool("moving", false);
            }
        }

    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        enemyTaget.localScale = new Vector2(Mathf.Abs(enemyTaget.localScale.x) * direction, enemyTaget.localScale.y);
        enemyTaget.position = new Vector2(enemyTaget.position.x + Time.deltaTime * direction * Speed, enemyTaget.position.y);
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);

    }
}
