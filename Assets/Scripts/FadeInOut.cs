using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public PauseMenu PS;
    public GameManager GM;
    public Animator Animator;
    public AsyncOperation AO;

    public void FadeOutNextLvl()
    {
        Animator.SetTrigger("TriggerNextLvl"); 
        if(GM.CurrentLvl < 30)
        {
            LevelCounter.Lvl++;
            AO = SceneManager.LoadSceneAsync(LevelCounter.Lvl);
            AO.allowSceneActivation = false;
        }
        else //Kraj igre ---> Napraviti nesto umjesto ovog!!
        {
            LevelCounter.Lvl = 0;
            Time.timeScale = 1f;
            AO = SceneManager.LoadSceneAsync("Main_menu");
            AO.allowSceneActivation = false;
        }
    }

    public void NextLevelGM()
    {
        GM.NextLevel();
    }    

    public void FadeOutMenu()
    {
        Animator.SetTrigger("TriggerMenu"); 
    }
    
    public void Menu()
    {
        PS.Menu();
    }
}
