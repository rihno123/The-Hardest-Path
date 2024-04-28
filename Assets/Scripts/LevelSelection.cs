using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Animator Animator;
    public GameObject[] Levels;
    private int lvl;
    public CanvasGroup CG;
    public MainMenu MM;
    private AsyncOperation AO;
    //private static int LastLevel = 9;

    private void Start() 
    {
        CG = GetComponent<CanvasGroup>();
        for(int i=0; i<PlayerPrefs.GetInt("Level Completed"); i++)
        {
            Levels[i].SetActive(true);
        }
       /* 
       for(int i=LastLevel; i>=PlayerPrefs.GetInt("Level Completed"); i--)
        {
            Levels[i].SetActive(false);
        }
        */
    }
    public void FadeOut(int i)
    {
        lvl = i;
        Animator.SetTrigger("FadeOutLvl");
        AO = SceneManager.LoadSceneAsync(i);
        AO.allowSceneActivation = false; 
    }    
    public void LevelSelect()
    {
        AO.allowSceneActivation = true;
        LevelCounter.Lvl = lvl;
    }
    public void BackButton()
    {
        Animator.SetTrigger("FadeInLvlSelect");      
    }
    private void GoBack()
    {
        MM.BackLevelSelect();
    }
}
