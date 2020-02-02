using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum TypePowerUp {PVel, Iman};
    public TypePowerUp PowerType;

    public PlayerController p1, p2;
    public LightController reference;


    void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();

        reference = GameObject.FindGameObjectWithTag("Ligth").GetComponent<LightController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1") && PowerType == TypePowerUp.PVel)
        {
            Debug.Log("Entre1");
            StartCoroutine("Velocidad1");
        }

        if(collision.gameObject.CompareTag("Player2") && PowerType == TypePowerUp.PVel)
        {
            StartCoroutine("Velocidad2");
            Debug.Log("Entre2");
        }

        if (collision.gameObject.CompareTag("Player1") && PowerType == TypePowerUp.Iman)
        {
            if (reference != null)
            {
                reference.iman = true;
                reference.playerPosition = p1.gameObject.transform.position;
                Debug.Log("Entre3");
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player2") && PowerType == TypePowerUp.Iman)
        {
            if (reference != null)
            {
                reference.iman = true;
                reference.playerPosition = p2.gameObject.transform.position;
                Debug.Log("Entre4");
            }
        }
    }
    IEnumerator Velocidad1()
    {
        p1.Speed += 3;
        p2.Speed -= 3f;
        yield return new WaitForSeconds(1.5f);
        p1.Speed -= 3f;
        p2.Speed += 3f;
    }
    IEnumerator Velocidad2()
    {
        p1.Speed -= 3f;
        p2.Speed += 3f;
        yield return new WaitForSeconds(1.5f);
        p1.Speed += 3f;
        p2.Speed -= 3f;
    }
}
