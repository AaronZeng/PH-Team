using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutScreenGravityObject : MonoBehaviour {
    public static Transform tf;

    public void Start(){
        tf = GetComponent<Transform>();
    }
}
