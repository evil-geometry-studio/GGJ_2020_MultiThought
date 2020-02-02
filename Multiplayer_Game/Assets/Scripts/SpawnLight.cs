using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLight : MonoBehaviour
{

    private static SpawnLight instance;
    public static SpawnLight Instance { get => instance;}
    public Game_Manager_UI gameMan;
    // Start is called before the first frame update
    public GameObject[] Spanwns;
    public GameObject Luz;

    public GameObject Powers;

    float timing = 0;

    void Start()
    {
        instance = this;
    }

    public void SpawnPower()
    {
        int rand = Random.Range(0, 20);
        if(rand < 10)
        {
            Powers.GetComponent<PowerUps>().PowerType = PowerUps.TypePowerUp.PVel;
        }
        else
        {
            Powers.GetComponent<PowerUps>().PowerType = PowerUps.TypePowerUp.Iman;
        }
        Instantiate(Powers, RandPositionWayPoint(), Quaternion.identity);
        timing += 5;
        if(timing >= 5 && timing <= 20)
        {
            StartCoroutine("Spawn");
        }
    }

    public void SpawnObjLigth()
    {
        Instantiate(Luz, RandPositionWayPoint(), Quaternion.identity);
    }

    public Vector2 RandPositionWayPoint()
    {
        int rand = Random.Range(0, 25);
        return Spanwns[rand].transform.position;

    }
    public IEnumerator Spawn()
    {
        if (Game_Manager_UI.Instance.curState == StateGame.Playing)
        {
            yield return new WaitForSeconds(5f);
            SpawnPower();
        }
    }
}
