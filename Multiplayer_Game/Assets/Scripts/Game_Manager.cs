using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance;
    public static Game_Manager Instance { get => instance;}

    public UnityEngine.Experimental.Rendering.LWRP.Light2D lightObj1;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D lightObj2;

    private float outerRadiusLimit = 0.01f;
    private float innerRadiusLimit = 10.0f;


    [Header("Player positions")]
    public GameObject[] player1Positions;
    public GameObject[] player2Positions;

    [Header("The Players")]
    public GameObject player1Obj;
    public GameObject player2Obj;

    public int scorePlayer1;
    public int scorePlayer2;

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

    public void modifyRadius(){
        outerRadiusLimit++;
        lightObj1.pointLightOuterRadius = Mathf.Lerp(lightObj1.pointLightOuterRadius, outerRadiusLimit, 0.01f * Time.time);
    }

}

/*  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player 1 Colision");
            SpawnLight.Instance.SpawnObjLigth();
            Destroy(this.gameObject, 0f);// Object pooling
            
            Game_Manager.Instance.scoreCount(1);
        }

        if (other.CompareTag("Player2"))
        {
            Debug.Log("Player 2 Colision");
            SpawnLight.Instance.SpawnObjLigth();
            Destroy(this.gameObject, 0f);// Object pooling
            Game_Manager.Instance.scoreCount(2);

        }
    }*/