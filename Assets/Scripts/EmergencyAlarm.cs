using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyAlarm : MonoBehaviour {

    public GvrAudioSource alarm1, alarm2;
    public GameObject eLight1, eLight2, bridgeLight1, bridgeLight2, bridgeLight3, bridgeLight4, bridgeDoor;
    public Material eLightDark, bridgeLightLit, buttonLit, buttonDark;
    public GameObject eLight1Obj, eLight2Obj, bridgeLight1Obj, bridgeLight2Obj, buttonObj;
    Material[] eLightMats, bridgeLightMats, buttonMats;
    public GvrAudioSource soundSource;
    public AudioClip buttonPressSound;

    // Use this for initialization
    void Start () {

        //Start audio for alarm Klaxons

        //Grab the materials for each light object to be changed later
        eLightMats = eLight1Obj.GetComponent<Renderer>().materials;
        bridgeLightMats = bridgeLight1Obj.GetComponent<Renderer>().materials;
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

        //Turn on normal lighting
        eLight1.SetActive(false);
        eLight2.SetActive(false);
        bridgeLight1.SetActive(true);
        bridgeLight2.SetActive(true);
        bridgeLight3.SetActive(true);
        bridgeLight4.SetActive(true);

        //change materials for each light to match new state
        eLightMats[1] = eLightDark;
        bridgeLightMats[1] = bridgeLightLit;
        buttonMats[1] = buttonDark;
        buttonMats[0] = buttonLit;
        eLight1Obj.GetComponent<Renderer>().materials = eLightMats;
        eLight2Obj.GetComponent<Renderer>().materials = eLightMats;
        bridgeLight1Obj.GetComponent<Renderer>().materials = bridgeLightMats;
        bridgeLight2Obj.GetComponent<Renderer>().materials = bridgeLightMats;
        buttonObj.GetComponent<Renderer>().materials = buttonMats;

        //Disable emergency door lock
        bridgeDoor.GetComponent<RedDoor>().Alarm();
    }
}
