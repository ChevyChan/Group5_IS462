using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public GameObject IntroScreen;
    // Start is called before the first frame update
    void Start()
    {
        //Disable screen when the user first interact with the program
        IntroScreen.active = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //Interaction function goes here
        //After clicking on the earth globe, make the intro screen active
    }
}
