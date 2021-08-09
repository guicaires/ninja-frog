using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool doubleJump;

    private Animator anim;
    private Rigidbody2D rig;

    private int GROUND_LAYER = 8;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if (x != 0f)
        {
            anim.SetBool("walk", true);

            if (x > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(
                        new Vector2(0f, jumpForce),
                        ForceMode2D.Impulse
                    );
                    anim.SetBool("doubleJump", true);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("doubleJump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER)
        {
            isJumping = true;
        }
    }
}
