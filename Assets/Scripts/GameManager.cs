using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //zmienna do singletona
    public static GameManager instance;

    public int timeToEnd;
    public bool isGamePaused = false;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        InvokeRepeating(/*nazwa IDENTYCZNA jak nazwa metody*/"Stopper", /*za ile zacząć */ 1, /*co ile powtarzać */ 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //jeżeli gra jest zatrzymana to wznów, jeżeli wznowiona to zatrzymaj
            TogglePause();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && isGamePaused)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void Stopper()
    {
        timeToEnd--; // odejmij 1 od timeToEnd
        if (timeToEnd < 0)
        {
            EndGame();
        }
        Debug.Log("Time: " + timeToEnd + " s");
    }

    private void TogglePause()
    {
        if(isGamePaused)
        {
            Debug.Log("Resume game");
            Time.timeScale = 1f;
            isGamePaused = false;
        }
        else
        {
            Debug.Log("Pause game");
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }

    private void EndGame()
    {
        CancelInvoke("Stopper");
        if(win)
        {
            Debug.Log("You won");
            //TODO: wyświetl faktyczny napis na ekranie
        }
        else
        {
            Debug.Log("You lost");
            //TODO: wyświetl faktyczny napis na ekranie
        }
    }

}
