using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertCrewDoor : MonoBehaviour
{
    //Trigger used to open the door
    public bool openDoor = false;
    //Timer variable that counts down before door closes again
    public static float doorTimer = 5;
    //Sound clips used for when the door is opened
    public AudioSource soundSource;
    public AudioClip doorOpen;
    //The two halves of the door that move when the door opens
    public GameObject leftSide, rightSide;

    void Update()
    {
        //If door is unlocked and not fully open, continue opening
        if (openDoor && leftSide.transform.position.z < 33.052f)
        {
            leftSide.transform.Translate(-0.8f * Time.deltaTime, 0, 0);
            rightSide.transform.Translate(0.8f * Time.deltaTime, 0, 0);
            //Debug.Log("Current position of leftSide: " + leftSide.transform.position.z);
        }
        //Once timer variable reaches zero, close door
        else if (doorTimer <= 0 && leftSide.transform.position.z > 32.46975)
        {
            leftSide.transform.Translate(0.8f * Time.deltaTime, 0, 0);
            rightSide.transform.Translate(-0.8f * Time.deltaTime, 0, 0);

            //Play audio clip of door opening/closing (only play if it is not already playing, so that it only plays once during close sequence)
            if (!soundSource.isPlaying)
            {
                soundSource.clip = doorOpen;
                soundSource.Play();
            }
        }
        //Decrement timer before door close and set openDoor variable back to false
        else
        {
            doorTimer -= Time.deltaTime;
            openDoor = false;
        }

    }

    public void OnDoorClicked()
    {
        //Trigger the door to open via animation script and play opening door sound
        openDoor = true;
        doorTimer = 5; //reset door timer

        //Play audio clip of door opening/closing
        soundSource.clip = doorOpen;
        soundSource.Play();

    }


}
