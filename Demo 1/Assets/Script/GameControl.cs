using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public bool gameOver = false;
    public float scrollSpeed = -6f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
    void Update()
    {
        PlayerDied();

        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayerDied()
    {
        if (Player.rb2d.position.y < -7.5f || Player.rb2d.position.y > 7.5f 
            || Player.rb2d.position.x < -9f || Player.rb2d.position.x > 9f)
        {
            gameOver = true;
        }
    }
}
