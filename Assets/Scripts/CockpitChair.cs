using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitChair : MonoBehaviour {

    //Trigger used to move the chair back if it's in flight mode
    public bool chairOpen = false;

    //Materials to change which button is lit after pressed
    public Material buttonLit1, buttonLit2, buttonDark1, buttonDark2;
    Material[] buttonMats;

    //Sound clips used for when the button is clicked
    public AudioSource soundSource;
    public AudioClip buttonPressSound;

    //Chair to move either forward or backwards
    public GameObject cockpitChair, buttonObj;

    void Start()
    {
        //Grab the materials for each button to be changed later
        buttonMats = buttonObj.GetComponent<Renderer>().materials;
    }

    void Update () {
        //If button is pressed and chair is in flight mode, move back to open cockpit
        if (chairOpen && cockpitChair.transform.position.z < 1.2f)
        {
            cockpitChair.transform.Translate(0, 0, 0.8f * Time.deltaTime, Space.World);
        }
        else if (!chairOpen && cockpitChair.transform.position.z > -0.8f)
        {
            cockpitChair.transform.Translate(0, 0, -0.8f * Time.deltaTime, Space.World);
        }
    }

    public void OnButtonClicked()
    {
        if (chairOpen == false)
        {
            //Trigger the chair to move away from the cockpit
            chairOpen = true;

            //Change which button is lit
            buttonMats[0] = buttonDark1;
            buttonMats[1] = buttonLit1;
            buttonObj.GetComponent<Renderer>().materials = buttonMats;

            //Play button sound
            soundSource.clip = buttonPressSound;
            soundSource.Play();

            //Initiate chair moving sound from chair game object
            cockpitChair.GetComponent<AudioSource>().Play();
        }
        else
        {
            //Trigger the chair to move back into flight mode
            chairOpen = false;

            //Change which button is lit
            buttonMats[1] = buttonDark2;
            buttonMats[0] = buttonLit2;
            buttonObj.GetComponent<Renderer>().materials = buttonMats;

            //Play button sound
            soundSource.clip = buttonPressSound;
            soundSource.Play();

            //Initiate chair moving sound from chair game object
            cockpitChair.GetComponent<AudioSource>().Play();
        }
    }
}
