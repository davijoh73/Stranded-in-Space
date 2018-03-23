using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyAlarm : MonoBehaviour {

    public AudioSource alarm1, alarm2;
    public GameObject bridgeDoor;
    public Material buttonLit, buttonDark;
    public GameObject buttonObj;
    Material[] buttonMats;
    public AudioSource soundSource;
    public AudioClip buttonPressSound;

    // Use this for initialization
    void Start () {

        //Start audio for alarm Klaxons

        //Grab the materials for each object that needs to be changed later
        buttonMats = buttonObj.GetComponent<Renderer>().materials;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ResetAlarm()
    {
        //Stop alarm audio
        alarm1.Stop();
        alarm2.Stop();

        //Play button press sound
        soundSource.clip = buttonPressSound;
        soundSource.Play();

        //change materials for button to match new state
        buttonMats[1] = buttonDark;
        buttonMats[0] = buttonLit;
        buttonObj.GetComponent<Renderer>().materials = buttonMats;

        //Disable emergency door lock
        bridgeDoor.GetComponent<BridgeDoor>().Unlock();
    }
}
