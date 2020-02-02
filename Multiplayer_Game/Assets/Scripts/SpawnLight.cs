using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLight : MonoBehaviour
{

    private static SpawnLight instance;
    public static SpawnLight Instance { get => instance;}
    // Start is called before the first frame update
    public GameObject[] Spanwns;
    public GameObject Luz;

    public GameObject Powers;

    float timing = 0;

    void Start()
    {
        instance = this;
        StartCoroutine("Spawn");
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
    IEnumerator Spawn()
    {
        if()
    }

}
