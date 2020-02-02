using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using GamepadInput;


public enum StateGame
{
    MainMenu, Paused, Choose_Side, GameOver, StartPlaying, Playing
}

public class Game_Manager_UI : MonoBehaviour
{
    private static Game_Manager_UI instance;
    public static Game_Manager_UI Instance { get => instance; }


    [Header("Game State")]
    public StateGame curState;
    [Header("General UI")]
    public GameObject[] theUIs;

    [Header("The players")]

    public PlayerController[] thePlayers;
    public int indexID = 0;
    int setID = 1;
    public TextMeshProUGUI txtCountBack;


    public TextMeshProUGUI timeTxt;

    [Header("UI controls")]
    public EventSystem eventSystem;

    public Button[] btnsSideSelection;

    public Button[] btnsUI;

    public JoystickDetection control;

    public Camera mainCamera;
    public bool zoomIn = false, zoomOut = false;
    public int zoomSpeed = 8;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update() 
    {
        if(zoomIn)
            ZoomIn_Out(-1);
        if(zoomOut)
            ZoomIn_Out(1);
    }

    public void ZoomIn_Out(int Dir)
    {
        mainCamera.orthographicSize += zoomSpeed * Dir * Time.deltaTime;
            if(zoomIn && mainCamera.orthographicSize <= 11f)
            {
                zoomIn=false;
                mainCamera.orthographicSize = 11;
            }
            if(zoomOut &&  mainCamera.orthographicSize >= 20f)
            {
                zoomOut=false;
                mainCamera.orthographicSize= 20f;
            }
    }

    public void SelectSide(int indexBtn)
    {
        thePlayers[indexID].indexPlayerID = setID;
        //SetControllers(indexBtn);
        //thePlayers[indexID].playerID = 
        //thePlayers[indexID].SetIDPlayer();
        setID++;
        //indexID++;

        curState = StateGame.StartPlaying;
        theUIs[1].SetActive(false); //UI of selection
        theUIs[2].SetActive(true);  //The HUD
        StartCoroutine(CountBackToStart());
        
        /*if (indexID == thePlayers.Length)
        {
            curState = StateGame.StartPlaying;
            theUIs[1].SetActive(false); //UI of selection
            theUIs[2].SetActive(true);  //The HUD
            StartCoroutine(CountBackToStart());
        }
        else
            SelectUIButton(btnsSideSelection[indexBtn]);*/
    }

    /*void SetControllers(int indexBtn)
    {
        if (Input.GetButtonDown("Submit") && control.names[0].Length == 19)
        {
            Debug.Log("Control de play es uno");
            thePlayers[indexBtn].playerID = GamePad.Index.One;
            thePlayers[indexBtn+1].playerID = GamePad.Index.Two;
            return;
        }
        
        if (Input.GetButtonDown("Submit") && control.names[0].Length == 33)
        {
            Debug.Log("Control de xbox es uno");
            thePlayers[indexBtn].playerID = GamePad.Index.One;
            thePlayers[indexBtn+1].playerID = GamePad.Index.Two;
            
        }

        if (Input.GetButtonDown("Submit") && control.names[1].Length == 19)
        {
            Debug.Log("Control de play es dos");
            thePlayers[indexBtn].playerID = GamePad.Index.One;
            thePlayers[indexBtn+1].playerID = GamePad.Index.Two;
            return;
        }
        
        if (Input.GetButtonDown("Submit") && control.names[1].Length == 33)
        {
            Debug.Log("Control de xbox es uno");
            thePlayers[indexBtn].playerID = GamePad.Index.One;
            thePlayers[indexBtn+1].playerID = GamePad.Index.Two;
            return;
        }
    }*/

    IEnumerator CountBackToStart()
    {
        int count = 3;
        while (count > 0)
        {
            yield return new WaitForSeconds(1f);
            txtCountBack.text = count.ToString();
            count--;
        }
        yield return new WaitForSeconds(1f);
        Game_Manager.Instance.SetPlayersConditions();
        curState = StateGame.Playing;
        txtCountBack.gameObject.SetActive(false);
    }

    //This method set the first button selected when a UI is enable and the player will press some button or navigate
    public void SelectUIButton(Button btnCurSelected)
    {
        //Debug.Log("Boton puesto");
        btnCurSelected.gameObject.SetActive(true);
        if (eventSystem.currentSelectedGameObject != null)
        {
            var previous = eventSystem.currentSelectedGameObject.GetComponent<Selectable>();
            if (previous != null)
            {
                previous.OnDeselect(null);
                eventSystem.SetSelectedGameObject(null);
            }
        }
        eventSystem.SetSelectedGameObject(btnCurSelected.gameObject);
        btnCurSelected.OnSelect(null);
    }

    public void StartGame()
    {
        curState = StateGame.StartPlaying;
        SelectUIButton(btnsSideSelection[0]);
        zoomIn = true;
        StartCoroutine(CountBackToStart());
    }

    public void MainMenu()
    {
        curState = StateGame.MainMenu;
        SelectUIButton(btnsUI[0]);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
