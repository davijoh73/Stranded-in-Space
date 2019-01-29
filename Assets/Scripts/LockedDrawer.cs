using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDrawer : MonoBehaviour {

    public AudioSource soundSource;
    public AudioClip lockedSound; //sound of the drawer opening and closing

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLockedDrawerClick()
    {
        //play audio sound of locked drawer
        soundSource.clip = lockedSound;
        soundSource.Play();
    }
}
