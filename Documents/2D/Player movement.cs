using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngineInternal;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float jump_heigh = 1f;
    [SerializeField] float Attack2Cooldown = 0;
    private Rigidbody2D player;
    private Animator player_animation;

    bool Player_isGround;
    bool Fall_detect = false;
    bool Double_jump = false;

    private float speedIn = 0f;
    private float attack2CooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        player_animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedIn = speed * 2f;
        }
        else speedIn = speed;

        float HorizontalInput = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(HorizontalInput * speedIn, player.velocity.y);

        if (HorizontalInput > 0f ) transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        if (HorizontalInput < 0f ) transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);

        if (Input.GetKeyDown(KeyCode.Space) && (Player_isGround ^ Double_jump))
        {
            player.velocity = new Vector2(player.velocity.x, jump_heigh);
            player_animation.SetTrigger("Jump");
            Player_isGround = false;
            Double_jump = !Double_jump;
        }
        if (player.velocity.y < -2f)
        {
            Fall_detect = true;
            Player_isGround = false;
        }
        else Fall_detect = false;

        player_animation.SetBool("Player_run_check", HorizontalInput != 0f);
        player_animation.SetBool("Player_isGrounded", Player_isGround);
        player_animation.SetBool("Fall", Fall_detect);

        //attack movement

        attack2CooldownTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player_animation.SetBool("Attack1", true);
        }
        else player_animation.SetBool("Attack1", false);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (attack2CooldownTimer >= Attack2Cooldown)
            {
                player_animation.SetBool("Attack2", true);
                attack2CooldownTimer = 0;
            }
        }
        else player_animation.SetBool("Attack2", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground_map")
        {
            Player_isGround = true;
            Double_jump = false;
        }

    }
}
