using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class EyesMovement : MonoBehaviour
{
    public GamePad.Index playerID;
    Vector2 axisLeftStick;
    public float Speed;

    void Update()
    {
        if (Game_Manager_UI.Instance.curState == StateGame.Playing)
        {

            axisLeftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, playerID);

            transform.Translate(axisLeftStick * Speed * Time.deltaTime);
        }
    }
}
