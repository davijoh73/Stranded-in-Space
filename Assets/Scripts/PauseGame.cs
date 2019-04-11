using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public GameObject pauseScreen;
    private float longPressTimer = 3;
    public bool gamePaused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Detect if user holds down button for at least 3 seconds
        if (Input.GetMouseButton(0) && longPressTimer > 0)
        {
            longPressTimer -= Time.deltaTime;
        }
        else
        {
            longPressTimer = 3;
        }

        //If button is depressed for at least 3 seconds, 
        //and game isn't already paused, pause the game
        if (longPressTimer <= 0 && !gamePaused)
        {
            gamePaused = true;
            Debug.Log("Game is paused");
        }

        //Game will be unpaused via resume button on pause screen

    }
}
