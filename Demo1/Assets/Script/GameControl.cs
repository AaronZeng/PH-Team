using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

public class GameControl : MonoBehaviour {

    public Text realTimeText;
    public string positionString = "start";
    public static GameControl instance;
    public bool isGameOver = false;
    public bool isChangeGravity = false;
    public float scrollSpeed = -8f;

    public void Awake()
    {
        Input.multiTouchEnabled = true;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Input.gyro.enabled = true;
    }

    public void Update(){
        if (isGameOver && (Input.GetMouseButtonDown(1) || Input.touchCount == 2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
