using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public float speed = 20f;

    public float rateCount = 0.5f;
    float nextCount;


    public Vector2 playerPosition;
    Vector2 curPosition;

    public bool iman = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextCount < Time.time)
        {
            curPosition = SpawnLight.Instance.RandPositionWayPoint();
            nextCount = Time.time + rateCount;

            if (iman)
            {
                StartCoroutine("MetodoIman");
            }
        }

        transform.position = Vector2.MoveTowards(this.transform.position, curPosition, speed * Time.deltaTime);
    }

    IEnumerator MetodoIman()
    {
        curPosition = playerPosition;
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Debug.Log("Colisiono");
            SpawnLight.Instance.SpawnObjLigth();
            Destroy(this.gameObject, 0f);// Object pooling
            //Mandar puntuación

        }
    }
}
