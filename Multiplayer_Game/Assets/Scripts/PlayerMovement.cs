using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using GamepadInput;

public class PlayerMovement : MonoBehaviour
{
    //Important so we can get the correct Controls
    [SerializeField]
    int PlayerID;
    public GamePad.Index playerID;

    [SerializeField]
    float Speed;

    ControlsManager controlsManager;

    void Start()
    {
        //get the ControlManager in the scene
        controlsManager = FindObjectOfType<ControlsManager>();

        switch (PlayerID)
        {
            case 1:
                playerID = GamePad.Index.One;
                break;
            case 2:
                playerID = GamePad.Index.Two;
                break;
            default:
                playerID = GamePad.Index.Any;
                break;
        }
    }

    void Update()
    {
        /*if (Input.GetKey(controlsManager.GetKey(PlayerID, ControlKeys.LeftKey)))
        {
            this.gameObject.GetComponent<Transform>().Translate(Vector2.left * Speed * Time.deltaTime);
        }

        if (Input.GetKey(controlsManager.GetKey(PlayerID, ControlKeys.RightKey)))
        {
            this.gameObject.GetComponent<Transform>().Translate(Vector2.right * Speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(controlsManager.GetKey(PlayerID, ControlKeys.Action)))
        {
            Debug.Log( "" + PlayerID + " Action Fired");
        }*/

        if(GamePad.GetButtonDown(GamePad.Button.A, playerID))
        {
            Debug.Log("Player "+ playerID +"Presionaste botón A");
        }

        Vector2 axis = GamePad.GetAxis(GamePad.Axis.LeftStick, playerID);

        transform.Translate((axis.x * Speed * Time.deltaTime), 0f, (axis.y * Speed * Time.deltaTime));

        GamepadState state = GamePad.GetState(playerID);

        print("A: " + state.A);
    }
}
