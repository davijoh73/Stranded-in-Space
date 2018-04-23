using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletFlush : MonoBehaviour
{

    public bool isFlushed = false; //determine if toilet has already been flushed
    public AudioSource soundSource, buttonSoundSource;
    public AudioClip soundEffect, buttonPressSound; //sound clip(s) to be used
    public Material button1Dark, button2Lit;
    public GameObject buttonObj, toiletFullStatus, toiletReadyStatus;
    Material[] buttonMats;

    // Use this for initialization
    void Start()
    {
        //Grab the materials for each object that need to be changed later
        buttonMats = buttonObj.GetComponent<Renderer>().materials;
    }

    public void OnToiletFlush()
    {
        if (!isFlushed)
        {
            //Play button press sound
            buttonSoundSource.clip = buttonPressSound;
            buttonSoundSource.Play();

            //Play audio clip w/ sound effect
            soundSource.clip = soundEffect;
            soundSource.Play();

            //change materials for button to match new state
            buttonMats[0] = button2Lit;
            buttonMats[1] = button1Dark;
            buttonObj.GetComponent<Renderer>().materials = buttonMats;

            //Update the status screen on the Toilet console
            toiletFullStatus.SetActive(false);
            toiletReadyStatus.SetActive(true);
        }
        if (isFlushed)
        {
            //Play button press sound
            buttonSoundSource.clip = buttonPressSound;
            buttonSoundSource.Play();
        }

        isFlushed = true;

    }
}
