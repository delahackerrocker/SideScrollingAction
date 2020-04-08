using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    // variable to hold Mario sprite
    public GameObject goMario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses SPACE bar we'll make Mario Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("SPACE");
        }

        // If the player presses KeyPad6 then move Mario right
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            print("Keypad6 - Right");
        }

        // If the player presses KeyPad4 then move Mario left
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            print("Keypad4 - Left");
        }

        // If the player presses Keypad8 then move Mario Up
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            print("Keypad8 - Up");
        }

        // If the player presses Keypad2 then make Mario Crouch
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            print("Keypad2 - Crouch or down pipe");
        }
    }
}
