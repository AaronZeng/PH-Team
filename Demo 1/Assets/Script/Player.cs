using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public float upForce = 400f;

    public static Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = Vector2.zero;
            if (rb2d.gravityScale > 0)
            {
                rb2d.AddForce(new Vector2(0, upForce));
            }
            else
            {
                rb2d.AddForce(new Vector2(0, -upForce));
            }
        }
    }
}
