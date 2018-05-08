using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GravityObject {
    private float upForce = 400f;
    private float cd = 2f;
    private float nextCd;
    private float gyroOne;
    private float gyroTwo;
    private float gyroThree;
    private List<float> gyroList = new List<float>();

    // Update is called once per frame
    public new void Update()
    {
        checkObjectInScreen();

        gyroListRefresh();
        GameControl.instance.realTimeText.text = GameControl.instance.positionString;

        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButtonDown(1) || checkTurnOver()) && Time.time > nextCd)
        {
            nextCd = Time.time + cd;
            GameControl.instance.isChangeGravity = true;
            GameControl.instance.realTimeText.text = GameControl.instance.positionString + "\nchange the gravity";
        }

        if (checkPlayerDied()){
            GameControl.instance.isGameOver = true;
            GameControl.instance.realTimeText.text = GameControl.instance.positionString + "\ndie";
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
            GameControl.instance.realTimeText.text = GameControl.instance.positionString + "\njump";
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

    private void gyroListRefresh(){
        gyroList.Add(Input.gyro.attitude.y);
        if (gyroList.Count > 41)
        {
            gyroList.Remove(0);
        }
        print(gyroList.Count);
    }

    private bool checkTurnOver(){
        if (Time.frameCount > 40 )
        {
            gyroThree = gyroList[40];
            gyroTwo = gyroList[20];
            gyroOne = gyroList[0];
            GameControl.instance.positionString = "gyro datas: " + gyroOne + " " + gyroTwo + " " + gyroThree;

            if ((gyroTwo - gyroThree < -0.3) && (gyroOne - gyroTwo > 0.3))
            {
                return true;
            }
        }
        return false;
    }
}
