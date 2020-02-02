using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeBack : MonoBehaviour
{
    private static TimeBack instance;
    public static TimeBack Instance { get => instance; }

    public TextMeshProUGUI txtTimeBack;

    public GameObject resultGame;
    public Button btnResult;
    public GameObject hud;

    public int curTime = 20;
    public float rateCount = 1f;
    float nextCount;


    [Header("Characters")]
    public Animator ctrlAngel;
    public Animator ctrlDiablo;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SetTime()
    {
        curTime = 20;
        txtTimeBack.text = curTime.ToString();
        ctrlAngel.Play("Idle_Angel");
        ctrlDiablo.Play("Idle_Angel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Manager_UI.Instance.curState == StateGame.Playing)
        {
            if (nextCount < Time.time && curTime > 0)
            {
                curTime--;
                txtTimeBack.text = curTime.ToString();
                nextCount = Time.time + rateCount;
            }

            if (curTime <= 0)
            {
                Game_Manager_UI.Instance.curState = StateGame.GameOver;
                resultGame.SetActive(true);
                Game_Manager_UI.Instance.SelectUIButton(btnResult);
                hud.SetActive(false);
                ctrlAngel.Play("Angel_Move");
                ctrlDiablo.Play("Angel_Move");
            }
        }
    }
}
