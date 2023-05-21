using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10F;
    GameManager gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

                PlayBoingSound();
            }
        }


    }

    void PlayBoingSound()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gm.PlaySound("boing");
    }
}
