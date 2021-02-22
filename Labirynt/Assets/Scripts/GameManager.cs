using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int timeToEnd;


    bool ifPaused = false;
    bool ifEndGame = false;
    bool ifWin = false;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        InvokeRepeating("Timer", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ifPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Timer()
    {
        timeToEnd--;

        if(timeToEnd <= 0)
        {
            ifEndGame = true;
            timeToEnd = 0;
        }
        if (ifEndGame)
        {
            EndGame();
        }

        Debug.Log("Time: " + timeToEnd + " s");
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        ifPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        ifPaused = false;
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        CancelInvoke("Timer");
        Time.timeScale = 0f;
        if (ifWin)
        {
            Debug.Log("YOU WON");
        }
        else
        {
            Debug.Log("YOU LOSE");
        }

    }

}
