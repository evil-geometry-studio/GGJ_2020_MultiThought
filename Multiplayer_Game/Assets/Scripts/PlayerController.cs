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

    public Rigidbody2D rbd2D;
    Vector2 axisLeftStick;

    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
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
        if (Game_Manager_UI.Instance.curState == StateGame.Playing)
        {
            /*if (GamePad.GetButtonDown(GamePad.Button.A, playerID))
                    {
                        Debug.Log("Player " + playerID + "Presionaste botón A");
                    }*/

            axisLeftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, playerID);

            transform.Translate(axisLeftStick * Speed * Time.deltaTime);
        }
    }
}
