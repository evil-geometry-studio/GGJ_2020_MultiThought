using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerController : MonoBehaviour
{
    //Important so we can get the correct Controls
    public int indexPlayerID;
    public GamePad.Index playerID;

    public float Speed;

    void Start()
    {

    }

    public void SetIDPlayer()
    {
        switch (indexPlayerID)
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
        if (Game_Manager.Instance.curState == StateGame.Playing)
        {
            /*if (GamePad.GetButtonDown(GamePad.Button.A, playerID))
                    {
                        Debug.Log("Player " + playerID + "Presionaste botón A");
                    }*/

            Vector2 axis = GamePad.GetAxis(GamePad.Axis.LeftStick, playerID);

            transform.Translate(axis * Speed * Time.deltaTime);
        }



    }
}
