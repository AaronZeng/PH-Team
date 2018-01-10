using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update () 
    {
        if (Player.changeGravity && sr.IsVisibleFrom(Camera.main))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.gravityScale *= -1;
            sr.flipY = !sr.flipY;
            Player.changeGravity = false;
        }
    }
}
