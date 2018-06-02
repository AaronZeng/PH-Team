using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InScreenGravityObject : MonoBehaviour {
    public static Transform tf;

    public void Start(){
        tf = GetComponent<Transform>();
    }

    public void Update(){
        if (GameControl.instance.isChangeGravity){
            gravityChange();
            GameControl.instance.isChangeGravity = false;
        }
    }

    private void gravityChange(){
        foreach (Transform child in transform){
            Rigidbody2D rb2d = child.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer sr = child.gameObject.GetComponent<SpriteRenderer>();
            Transform tfChild = child.gameObject.GetComponent<Transform>();
            rb2d.velocity = Vector2.zero;
            rb2d.gravityScale *= -1;
            sr.flipY = !sr.flipY;
            //tfChild.Rotate(0,0,180f);
        }
    }
}
