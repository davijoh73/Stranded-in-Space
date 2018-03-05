using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour 
{
    //The locked variable is used in the Unlock method to "unlock" the door
    public bool locked = true;
    public bool alarm = true;
    //Trigger used to open the door once it's unlocked
    public bool openDoor = false;
    //Sound clips used for when the door is locked, and when it's opened
    public GvrAudioSource soundSource;
    public AudioClip doorLocked;
    public AudioClip doorOpen;
    public GameObject accessDenied, accessGranted, nextSection;

    void Update() {
        //If door is unlocked and not fully raised, continue raising door
        if (openDoor && transform.position.y < 2.2f)
        {
            transform.Translate(0, 1.7f * Time.deltaTime, 0, Space.World);
        }
    }

    public void OnDoorClicked() {
        if (locked == false && alarm == false)
        {
            //Activate next section of ship previously hidden for performance improvement
            nextSection.SetActive(true);

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

    public void Alarm()
    {
        //Call this method when alarm system is disabled
        alarm = false;
    }
}
