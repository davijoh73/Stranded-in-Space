using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject FoodGenLight, oatmealBowl;
    public ParticleSystem FoodGenParticle;
    public Material button1Dark, button2Dark;
    public GameObject buttonObj;
    Material[] buttonMats;
    public AudioSource buttonSoundSource, foodGenSoundSource;
    public AudioClip buttonPressSound;
    private int buttonToggle=0;

    // Use this for initialization
    void Start()
    {

        //Start audio for alarm Klaxons

        //Grab the materials for each object that need to be changed later
        buttonMats = buttonObj.GetComponent<Renderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (buttonToggle == 0)
        {
            LightsOn();
            buttonToggle += 1;
        }
        else if (buttonToggle == 1)
        {
            MakeFood();
            buttonToggle += 1;
        }
        else
        {
            Finished();
        }
    }

    public void LightsOn()
    {
        //Sound when light comes on???

        //Play button press sound
        buttonSoundSource.clip = buttonPressSound;
        buttonSoundSource.Play();

        //change materials for button to match new state
        buttonMats[1] = button1Dark;
        buttonObj.GetComponent<Renderer>().materials = buttonMats;

        //Turn on the mystical food generator light
        FoodGenLight.SetActive(true);

    }

    public void MakeFood()
    {
        //Play sounds
        foodGenSoundSource.Play();
        buttonSoundSource.Play();

        //Change material for second button to make it dark
        buttonMats[0] = button2Dark;
        buttonObj.GetComponent<Renderer>().materials = buttonMats;

        //Initiate particle effect here and bring bowl of oatmeal into existence (fade in?)
        FoodGenParticle.Play();
        oatmealBowl.SetActive(true);

    }

    public void Finished()
    {
        //Nothing left to do, just play the button sound
        buttonSoundSource.Play();
    }
}
