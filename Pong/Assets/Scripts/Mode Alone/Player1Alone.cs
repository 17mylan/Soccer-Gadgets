using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Alone : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        racketDirection = new Vector2(0, directionY).normalized;
        animator.SetFloat("Speed", Mathf.Abs(directionY));
    }
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
