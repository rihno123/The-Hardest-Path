using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{
    private AsyncOperation AO;
    public Animator Animator;

    public void FadeOut()
    {
        Animator.SetTrigger("FadeOut");
        AO = SceneManager.LoadSceneAsync(1);
        AO.allowSceneActivation = false; 
    }    
    
    public void NewGame()
    {
        LevelCounter.Lvl = 1;
        AO.allowSceneActivation = true; 
    }

}
