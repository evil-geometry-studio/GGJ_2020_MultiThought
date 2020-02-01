using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance;
    public static Game_Manager Instance { get => instance;}


    [Header("Player positions")]
    public GameObject[] player1Positions;
    public GameObject[] player2Positions;

    [Header("The Players")]
    public GameObject player1Obj;
    public GameObject player2Obj;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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

}
