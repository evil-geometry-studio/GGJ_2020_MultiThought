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

    void Start()
    {
        instance = this;
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

}
