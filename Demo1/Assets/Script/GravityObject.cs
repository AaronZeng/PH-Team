using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : GameObject {

    protected SpriteRenderer sr;

    // Use this for initialization
    public void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}

    public void Update(){
        checkObjectInScreen();
    }

    protected void checkObjectInScreen(){
        if (sr.IsVisibleFrom(Camera.main))
        {
            gameObject.transform.SetParent(InScreenGravityObject.tf);
        }
        else {
            gameObject.transform.SetParent(OutScreenGravityObject.tf);
        }
    }
}
