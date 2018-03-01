using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public bool isGameOver = false;
    public bool isChangeGravity = false;
    public float scrollSpeed = -6f;

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
    }

    public void Update(){
        if (isGameOver && (Input.GetMouseButtonDown(1) || Input.touchCount == 2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
