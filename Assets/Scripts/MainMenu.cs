using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GUISkin Skin;
    public AudioClip[] AudioClip2;
    public GameObject options,menu,playmenu,levelselectbutton,levelselect,shop;
    public GameObject[] achievements;
    private AudioSource au;
    public AdvancementsScript AS;
    public GameObject[] AchText;
    //public LevelSelection LS;

    private void Awake()
    {
        for (int k = 0; k < AchText.Length; k++)
        {
            AchText[k].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Level Completed") == false)
        {
            PlayerPrefs.SetInt("gold", 0);
            PlayerPrefs.SetInt("Level Completed", 1);
        }
        if (PlayerPrefs.HasKey("SpeedUpgrade") == false)
        {
            PlayerPrefs.SetInt("SpeedUpgrade", 0);
            PlayerPrefs.SetInt("MaxSpeedUpgrade", 0);
            PlayerPrefs.SetInt("SlowMotionUpgrade", 0);
            PlayerPrefs.SetInt("MaxSlowMotionUpgrade", 0);
            PlayerPrefs.SetInt("SlowEnemyUpgrade", 0);
            PlayerPrefs.SetInt("MaxSlowEnemyUpgrade", 0);
            PlayerPrefs.SetInt("SmallCubeUpgrade", 0);
            PlayerPrefs.SetInt("MaxSmallCubeUpgrade", 0);
            PlayerPrefs.SetInt("SmallEnemyUpgrade", 0);
            PlayerPrefs.SetInt("MaxSmallEnemyUpgrade", 0);
            PlayerPrefs.SetInt("GhostUpgrade", 0);
            PlayerPrefs.SetInt("MaxGhostUpgrade", 0);
        }
        if (PlayerPrefs.HasKey("Money") == false)
        {
            PlayerPrefs.SetInt("Money", 0);
        }

        if (PlayerPrefs.HasKey("Launched") == false)
        {
            for (int i = 0; i < AS.NumOfAdv; i++)
            {
                PlayerPrefs.SetInt("Achievement " + i.ToString(), 0);
            }
            PlayerPrefs.SetInt("Launched", 1);
        }

        ///////// promjenit ovaj if() -----------> mozda
        int p = Random.Range(0, AchText.Length);
        if(PlayerPrefs.GetInt("gold") < 1)
        {
            p = 0;
            PlayerPrefs.SetInt("gold", 1);
        }
        for(int l = 0;l<AchText.Length;l++)
        {
            if(p == l)
            {
                AchText[l].SetActive(true);
            }
        }
    }
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Level Completed", 30);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Time.timeScale = 1;
        au = GetComponent<AudioSource>();
        PlaySound();
    }

    private void PlaySound()
    {
        int i = Random.Range(0, AudioClip2.Length);
        au.clip = AudioClip2[i];
        au.Play();
    }
  /*  public void NewGame()
    {
        LevelCounter.Lvl = 1;
        SceneManager.LoadScene(1);
    } Nalazi se u NewGameScript Skripti*/
    public void Quit()
    {
        Application.Quit();
    }
    public void Options() 
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void BackOptions() {
        options.SetActive(false);
        menu.SetActive(true);
    }
    public void LevelSelect()
    {
            playmenu.SetActive(false);
            levelselect.SetActive(true);
    }
    public void BackLevelSelect()
    {
        levelselect.SetActive(false);
        playmenu.SetActive(true);
        //LS.CG.alpha = 1;
    }
    public void PlayMenu()
    {   if (PlayerPrefs.GetInt("Level Completed") == 1)
        {
            menu.SetActive(false);
            playmenu.SetActive(true);
            levelselectbutton.SetActive(false);
        }
    else
        {
            menu.SetActive(false);
            playmenu.SetActive(true);
            levelselectbutton.SetActive(true);
        }
    }
    public void BackPlay() 
    {
        playmenu.SetActive(false);
        menu.SetActive(true);
    }
    public void BackShop() 
    {
        shop.SetActive(false);
        menu.SetActive(true);
    }   
    public void Shop() 
    {
        menu.SetActive(false);
        shop.SetActive(true);
    }
    public void BackAchievements() 
    {
        achievements[0].SetActive(false);
        menu.SetActive(true);
    }   
    public void Achievements() 
    {
        menu.SetActive(false);
        achievements[0].SetActive(true);
    }
    public void AchievementsPagesBack(int i) 
    {
        achievements[i].SetActive(false);
        achievements[i-1].SetActive(true);
    }
    public void AchievementsPagesForward(int i) 
    {
        achievements[i].SetActive(false);
        achievements[i+1].SetActive(true);
    }
}
