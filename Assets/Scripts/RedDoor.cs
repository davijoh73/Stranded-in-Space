using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour 
{
    //The locked variable is used in the Unlock method to "unlock" the door
    public bool locked = false;
    //Trigger used to open the door once it's unlocked
    public bool openDoor = false;
    //Sound clips used for when the door is locked, and when it's opened
    public AudioSource soundSource;
    public AudioClip doorLocked;
    public AudioClip doorOpen;
    public GameObject topHalf, bottomHalf, accessDenied, accessGranted;

    void Update() {
        //If door is unlocked and not fully raised, continue raising door
        if (openDoor && topHalf.transform.position.y < 1.34f)
        {
            topHalf.transform.Translate(0, 1.5f * Time.deltaTime, 0, Space.World);
            bottomHalf.transform.Translate(0, -1.5f * Time.deltaTime, 0, Space.World);
        }
    }

    public void OnDoorClicked() {
        if (locked == false)
        {

            //Change the message on the access panel
            accessDenied.SetActive(false);
            accessGranted.SetActive(true);
            
            //Trigger the door to open via animation script and play opening door sound
            openDoor = true;
            soundSource.clip = doorOpen;
            soundSource.Play();
        }
        else
        {
            //Play locked door audio clip
            soundSource.clip = doorLocked;
            soundSource.Play();
        }
    }

    public void Unlock()
    {
        //Call this method to unlock the door
        locked = false;
    }

}
