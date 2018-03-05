using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour 
{
    //Create a reference to the Door
    public GameObject theDoor;
    public static bool keyCollected = false;
    public GvrAudioSource soundSource;
    public AudioClip keyCardSound;

    void Update()
	{

	}

	public void OnKeyClicked()
	{
        // Call the Unlock() method on the Door
        theDoor.GetComponent<RedDoor>().Unlock();
        // Set the Key Collected Variable to true
        keyCollected = true;
        // Destroy the key. Check the Unity documentation on how to use Destroy
        Destroy(gameObject, 0.2f);
        //Play sound to indicate key card being collected
        soundSource.clip = keyCardSound;
        soundSource.Play();
    }

}
