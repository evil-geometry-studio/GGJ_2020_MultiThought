using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public enum StateGame{
    MainMenu, Paused, Choose_Side, GameOver, StartPlaying, Playing
}

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance;
    public static Game_Manager Instance { get => instance;}


    [Header("Game State")]
    public StateGame curState;
    [Header("General UI")]
    public GameObject[] theUIs;

    [Header("The players")]

    public PlayerController[] thePlayers;
    public int indexID = 0;
    int setID = 1;

    public TextMeshProUGUI timeTxt;

    [Header("UI controls")]
    public EventSystem eventSystem;

    public Button[] btnsSideSelection;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SelectSide(int indexBtn)
    {
        thePlayers[indexID].indexPlayerID = setID;
        thePlayers[indexID].SetIDPlayer();
        setID++;
        indexID++;
        if(indexID == thePlayers.Length)
        {
            curState = StateGame.StartPlaying;
            theUIs[1].SetActive(false); //UI of selection
            theUIs[2].SetActive(true);  //The HUD
        }
        else
            SelectUIButton(btnsSideSelection[indexBtn]);
    }

    //This method set the first button selected when a UI is enable and the player will press some button or navigate
    public void SelectUIButton(Button btnCurSelected)
    {
        //Debug.Log("Boton puesto");
        btnCurSelected.gameObject.SetActive(true);
        if(eventSystem.currentSelectedGameObject != null)
        {
            var previous = eventSystem.currentSelectedGameObject.GetComponent<Selectable>();
            if(previous != null)
            {
                previous.OnDeselect(null);
                eventSystem.SetSelectedGameObject(null);
            }
        }
        eventSystem.SetSelectedGameObject(btnCurSelected.gameObject);
        btnCurSelected.OnSelect(null);
    }
}
