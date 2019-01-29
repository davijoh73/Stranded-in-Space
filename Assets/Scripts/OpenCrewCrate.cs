using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCrewCrate : MonoBehaviour
{

    public bool crateOpen = false; //determine if crate is already open
    public AudioSource soundSource;
    public AudioClip crateSound; //sound of the crate opening
    public GameObject crateLid; //lid that will be rotated into open position
    private float x; //variable used to rotate the lid

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (crateOpen && x < 90f)
        {
            x += Time.deltaTime * 45f;
            //-195 is to adjust for the position of the crate in world space - quaternion operates in world space
            crateLid.transform.rotation = Quaternion.Euler(x, -195, 0);
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
