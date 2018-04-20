using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLabCrate : MonoBehaviour {

    public bool crateOpen = false; //determine if crate is already open
    public AudioSource soundSource; 
    public AudioClip crateSound; //sound of the crate opening
    public GameObject crateLid; //lid that will be rotated into open position
    private float x; //variable used to rotate the lid

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (crateOpen && x < 90f)
        {
            x += Time.deltaTime * 45f;
            crateLid.transform.rotation = Quaternion.Euler(x, 0, 0);
        }
    }

    public void OnCrateClick()
    {
        if (!crateOpen)
        {
            //Play audio clip of lid opening
            soundSource.clip = crateSound;
            soundSource.Play();
        }
        
        crateOpen = true;

    }
}
