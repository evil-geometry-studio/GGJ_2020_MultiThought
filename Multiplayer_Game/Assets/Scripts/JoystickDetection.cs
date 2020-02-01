using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDetection : MonoBehaviour {

    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;

    public bool ps4JoystickConnected = false;
    public bool xboxJoystickConnected = false;
    public bool pcInputs = false;

    public static JoystickDetection instance;

    public string[] names;

    // Use this for initialization
    void Start ()
    {
        instance = this;

        names = new string[Input.GetJoystickNames().Length];

        names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);
            //print(names[x]);
            if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                //ShowDebugsGame.Instance.AddText("Input: ", "Ps4 controller is connected");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //ShowDebugsGame.Instance.AddText("Input: ", "Xbox controller is connected");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }

        if (Xbox_One_Controller == 1)
        {
            //do something
            xboxJoystickConnected = true;
            ps4JoystickConnected = false;
        }
        else if (PS4_Controller == 1)
        {
            //do something
            xboxJoystickConnected = false;
            ps4JoystickConnected = true;
        }
        else
        {
            // there is no controllers
            //ShowDebugsGame.Instance.AddText("Input: ", "keyboard");
            pcInputs = true;        //This only to show feedback about controls when there is not controllers
        }
    }
}
