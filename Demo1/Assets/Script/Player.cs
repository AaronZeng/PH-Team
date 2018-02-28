using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GravityObject {
    private float upForce = 400f;
    private float cd = 2f;
    private float nextCd;

    // Update is called once per frame
    public new void Update()
    {
        checkObjectInScreen();

        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButtonDown(1)) && Time.time > nextCd)
        {
            nextCd = Time.time + cd;
            GameControl.instance.isChangeGravity = true;
        }

        if (checkPlayerDied()){
            GameControl.instance.isGameOver = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
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

    private bool checkPlayerDied()
    {
        if (gameObject.transform.parent == OutScreenGravityObject.tf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
