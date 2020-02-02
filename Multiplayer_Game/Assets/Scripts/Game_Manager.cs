using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance;
    public static Game_Manager Instance { get => instance;}

    [Header("light objects < score >")]
    public UnityEngine.Experimental.Rendering.LWRP.Light2D lightObj1;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D lightObj2;

    // outter radius (score)
    private float outerRadiusLimit = 0.0f;
    private float innerRadiusLimit = 10.0f;


    [Header("Player positions")]
    public GameObject[] player1Positions;
    public GameObject[] player2Positions;

    [Header("The Players")]
    public GameObject player1Obj;
    public GameObject player2Obj;

    public int scorePlayer1;
    public int scorePlayer2;
    public bool scoreBoolLight1;
    public bool scoreBoolLight2;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update(){
        
        modifyRadius();
        
    }

    public void SetPlayersConditions()
    {
        SetRandPositionPlayer1();
        SetRandPositionPlayer2();
        SpawnLight.Instance.SpawnObjLigth();
        TimeBack.Instance.SetTime();
    }

    public void SetRandPositionPlayer1()
    {
        int rand = Random.Range(0, player1Positions.Length);

        player1Obj.transform.position = player1Positions[rand].transform.position;
    }

    public void SetRandPositionPlayer2()
    {
        int rand = Random.Range(0, player2Positions.Length);

        player2Obj.transform.position = player2Positions[rand].transform.position;
    }


    public void scoreCount(int playerWhoScore){
        
        if(playerWhoScore == 1)
        {
            scorePlayer1++;
        }
        else
        {
            scorePlayer2++;
        }
    }

    public void modifyRadius()
    {
        if (scoreBoolLight1 == true)
        {
            outerRadiusLimit++;
            lightObj1.pointLightOuterRadius = Mathf.Lerp(lightObj1.pointLightOuterRadius, scorePlayer1, 0.01f * Time.time);

            if(lightObj1.pointLightOuterRadius >= scorePlayer1)
            {
                scoreBoolLight1 = false;
            }
        }
        else if (scoreBoolLight2 == true)
        {
            outerRadiusLimit++;
            lightObj2.pointLightOuterRadius = Mathf.Lerp(lightObj2.pointLightOuterRadius, scorePlayer2, 0.01f * Time.time);

            if (lightObj2.pointLightOuterRadius >= scorePlayer1)
            {
                scoreBoolLight2 = false;
            }
        }

    }

    public void Win()
    {
        if (scorePlayer1 > scorePlayer2 && TimeBack.Instance.curTime == 0)
        {
            TimeBack.Instance.txtWinner.text = "Angel WINS!";
        }
        else if (scorePlayer2 > scorePlayer1 && TimeBack.Instance.curTime == 0)
        {
            TimeBack.Instance.txtWinner.text = "Devil WINS!";
        }
        else
        {
            Draw();
        }
    }

    void Draw()
    {
        if (scorePlayer1 == 10)
        {
            TimeBack.Instance.txtWinner.text = "Angel WINS!";
            TimeBack.Instance.isGameOver();
        }
        else if (scorePlayer2 == 10)
        {
            TimeBack.Instance.txtWinner.text = "Devil WINS!";
            TimeBack.Instance.isGameOver();
        }
        else if (scorePlayer1 == scorePlayer2 && TimeBack.Instance.curTime == 0)
        {
            TimeBack.Instance.txtWinner.text = "It's a DRAW!";
            TimeBack.Instance.isGameOver();
        }
    }
}