using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //skripta nije u upotrebi,već je integrirana u GameManageru (mislim-16.7.2019)-19.7.2019->ponovno je u upotrebi za PauseMenu
    public GameObject PauseMenuUI;
    public GameObject options, menu;
    
    public void ButtonClickPause()
    {
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
    }
    public void Resume()
    {
        GameObject tutorial = GameObject.Find("Tut");
        if (tutorial != null)
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void RestartLvl()
    {
        SceneManager.LoadScene(LevelCounter.Lvl);
        Time.timeScale = 1;
    }
    
    public void Menu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_menu");
    }
    public void Options() 
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void Back() 
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
}
