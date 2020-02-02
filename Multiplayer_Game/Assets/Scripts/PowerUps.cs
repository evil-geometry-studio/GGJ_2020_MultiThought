using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum TypePowerUp { PVel, Iman };
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
        if (Game_Manager_UI.Instance.curState != StateGame.Playing)
        {
            Destroy(this.gameObject, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") && PowerType == TypePowerUp.PVel)
        {
            StopAllCoroutines();
            p1.Speed = p1.maxSpeed;
            p2.Speed = p2.maxSpeed;
            StartCoroutine(Velocidad1());
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player2") && PowerType == TypePowerUp.PVel)
        {
            StopAllCoroutines();
            p1.Speed = p1.maxSpeed;
            p2.Speed = p2.maxSpeed;
            StartCoroutine(Velocidad2());
            Destroy(gameObject);
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

            Destroy(gameObject);
        }
    }
    IEnumerator Velocidad1()
    {
        p2.Speed  = 6f;
        yield return new WaitForSeconds(1f);
        p1.Speed = p1.maxSpeed;
        p2.Speed = p2.maxSpeed;
    }
    IEnumerator Velocidad2()
    {
        p1.Speed = 6f;
        yield return new WaitForSeconds(1f);
        p1.Speed = p1.maxSpeed;
        p2.Speed = p2.maxSpeed;
    }
}
