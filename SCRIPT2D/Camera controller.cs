
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    [SerializeField] private float Camera_speed = 2f;
    public Transform player;
    private int left_right;

    [SerializeField] private float offset_x = 2f;
    [SerializeField] private float offset_y = 2f;

    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if ((player.position.x > -8f && player.position.x < 6f) && (player.position.y > -43f && player.position.y < -36f))
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-1.2f, -39.3f, -10f), ref velocity, Camera_speed);
            //this.transform.position = new Vector3(-1.2f, -39.3f, -10f);
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x + offset_x, player.position.y + offset_y, -10f), ref velocity, Camera_speed);
                left_right = 1;
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {
               transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x - offset_x, player.position.y + offset_y, -10f), ref velocity, Camera_speed);
                left_right = -1;
            }
            if (Input.GetAxis("Vertical") < 0f)
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, player.position.y - 2 * offset_y, -10f), ref velocity, Camera_speed);

            else
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x + left_right*offset_x, player.position.y + offset_y, -10f), ref velocity, Camera_speed);

        }
    }
}
