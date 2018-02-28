using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : GameObject {

	// Use this for initialization
    public void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
	}

    public void Update(){
        if (GameControl.instance.isGameOver){
            scrollingStop();
        }
    }

    private void scrollingStop(){
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Vector4(255, 0, 0, 1);
        rb2d.velocity = Vector2.zero;
    }
}
