using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public GameObject GameplayUI, PauseUI;
    public GameObject player;
    private bool Paused;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one gameController in the scene");
        }
        else
        {
            instance = this;
        }

        

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape))|| Input.GetKeyDown(KeyCode.P))
        {
            Paused = !Paused;
            
        }

        PauseMenu();
    }

    public void Resume()
    {
        Paused = !Paused;
    }


    void PauseMenu()
    {
        if (Paused)
        {

            Cursor.lockState = CursorLockMode.Confined;
            GameplayUI.GetComponent<Canvas>().enabled = false;
            PauseUI.GetComponent<Canvas>().enabled = true;
            Cursor.visible = true;
            Time.timeScale = 0;


        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GameplayUI.GetComponent<Canvas>().enabled = true;
            PauseUI.GetComponent<Canvas>().enabled = false;
        }
    }

    public void closeGame()
    {
        Application.Quit();
    }

}
