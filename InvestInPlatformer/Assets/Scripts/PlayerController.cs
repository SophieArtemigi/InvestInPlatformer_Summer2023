using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] Rigidbody2D rb;

    float moveX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }


    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    private void FixedUpdate() // executes on the frame after update
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
    
 
}
