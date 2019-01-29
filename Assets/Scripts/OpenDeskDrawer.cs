using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDeskDrawer : MonoBehaviour {

    public bool drawerOpen = false; //boolean variable to know if drawer is open or closed
    public AudioSource soundSource;
    public AudioClip drawerSound; //sound of the drawer opening and closing
    public GameObject deskDrawer; //drawer object that will be opened and closed

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(drawerOpen && deskDrawer.transform.position.z > 29.79f)
        {
            deskDrawer.transform.Translate(0f, 0f, -0.7f * Time.deltaTime, Space.World);
        }
        else if(!drawerOpen && deskDrawer.transform.position.z < 30.26f)
        {
            deskDrawer.transform.Translate(0f, 0f, 0.7f * Time.deltaTime, Space.World);
        }

        Debug.Log("X position: " + deskDrawer.transform.position.x + " Y position: " + deskDrawer.transform.position.y + " Z position: " + deskDrawer.transform.position.z);
    }

    public void OnDrawerClick()
    {
        //play audio sound of drawer opening/closing
        soundSource.clip = drawerSound;
        soundSource.Play();
        if (drawerOpen)
        {
            drawerOpen = false;
        }
        else
        {
            drawerOpen = true;
        }
    }
}
