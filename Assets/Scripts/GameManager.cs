using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Security.Cryptography;
using CloudOnce;
using UnityEngine.SocialPlatforms;
using System;


public class GameManager : MonoBehaviour
{
    //Kod za RespawnTokena : #T
    //Count
    [Header("Level Managment")]
    private float BestTime = 0;
    private float PlayerBestTime = 0;
    public int CurrentLvl;
    public int UnlockedLvl;
    public int TokenCount;
    public int TotalLvlToken;
    public GameObject Token;
    //GUI skin
    //public GUISkin Skin;
    //Timer
    private float CurrentTimeFloat;
    public string CurrentTime;
    //Deaths
    public int Deaths;
    //Tokens
    public Transform TokenParent;
    public Vector3[] TokenSpawn; // #T
    public GameObject CompleteLevelMenu;

    //CameraTypes->tu stavljam sve tipove kamera.
    [Header("Camera")]
    public GameObject DefaultCam;
    public GameObject TwoDCam;
    public static bool StartBool;
    //Complete Level Menu

    [Header("Canvas Managment")]
    public TMPro.TMP_Text CT, BT,PBT; //CT-CurrentTime, BT-BestTime, PBT-PlayerBestTime
    public GameObject BetterTime, LvlCompletedText, TryFaster, BestOne, GettingBetter;
    public TMPro.VertexGradient CG;

    [Header("Loading Next Scene")]
    public FadeInOut FIO;

    private int achivementnagrade = 8;

    private AdManager AD;

    public float scoreLoad, playerscoreLoad;



    void FixedUpdate()
    {

        if (StartBool == false)
        {
            CurrentTime = string.Format("{0:0.00}", CurrentTimeFloat);
        }
        else if (StartBool == true)
        {
            CurrentTimeFloat += Time.deltaTime;
            CurrentTime = string.Format("{0:0.00}", CurrentTimeFloat);
        }
    }
    void Awake()
    {
        ////////////////////////////////////////////////////Cheats////////////////////////////////
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Money", 1000);
        //PlayerPrefs.SetInt("Level Completed",9);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        //////////////////////////////////////////////////////End Cheats////////////////////////////
        TryFaster.SetActive(false);
        LvlCompletedText.SetActive(false);
        CompleteLevelMenu.SetActive(false);
        BetterTime.SetActive(false);
        BestOne.SetActive(false);
        GettingBetter.SetActive(false);
        StartBool = false;
        CameraChange();
        TokenCount = 0;
        TotalLvlToken = TokenParent.childCount;
        Deaths = 0;
        if (LevelCounter.Lvl > 1)
        {
            CurrentLvl = LevelCounter.Lvl;
        }
        else
        {
            CurrentLvl = 1;
            LevelCounter.Lvl = 1;
        }
        PlayerBestTime = PlayerPrefs.GetFloat("Level " + CurrentLvl.ToString() + " Best Time");
        CurrentTimeFloat = 0;
        CurrentTime = string.Format("{0:0.00}", CurrentTimeFloat);
        TokenSpawn = new Vector3[TotalLvlToken]; // #T

        //Without Upgrades LvlCounter
        if (LevelCounter.WithoutUpgrades != 0 && CurrentLvl - 1 != LevelCounter.WithoutUpgrades)
        {
            LevelCounter.WithoutUpgrades = 0;
        }
        if (LevelCounter.WithoutDeaths != 0 && CurrentLvl - 1 != LevelCounter.WithoutDeaths)
        {
            LevelCounter.WithoutDeaths = 0;
        }
    }

    public void Start()
    {
        scoreLoad = -1;
        LoadScore(CurrentLvl); //mislim da je tu greska, Probati skriptu ClouOnceServices koristiti kao gameobject,jer ovako je ona staticna i mozda je u tome problem!
    }

    public void CompleteLevel()
    {
        SaveGame();
        CT.text = ("Time\n<size=35>" + CurrentTime + "</size>");
        BT.text = ("Best Time\n <size=35>" + string.Format("{0:0.00}" + "</size>", BestTime));
        PBT.text = ("Your Best\n <size=35>" + string.Format("{0:0.00}" + "</size>", PlayerBestTime));
        CompleteLevelMenu.SetActive(true);
        //OGLASI
        int i = UnityEngine.Random.Range(0, 2);
        if (i == 0)
        {
            AdManager.PlayInterstitialAd();
        }
        
    }

    public void NextLevel() //Skripta za async loading lvl je u FadeInOut skripti
    {
        Time.timeScale = 1f;
        FIO.AO.allowSceneActivation = true;
    }
    void SaveGame()
    {
        if (scoreLoad >= 0)
        {
            BestTime = scoreLoad;
            if (scoreLoad == 0)
            {
                CT.colorGradient = CG;
                BT.colorGradient = CG;
                if(CurrentTimeFloat < PlayerBestTime)
                {
                    PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                    PBT.colorGradient = CG;
                    BetterTime.SetActive(true);
                }
                else if(CurrentTimeFloat >= PlayerBestTime && PlayerBestTime != 0)
                {
                    BetterTime.SetActive(true);
                    PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                }
                else
                {
                    PBT.colorGradient = CG;
                    PlayerBestTime = CurrentTimeFloat;
                    LvlCompletedText.SetActive(true);
                }

                SubScore(float.Parse(CurrentTime), CurrentLvl);
            }
            else if (CurrentTimeFloat < scoreLoad )
            {
                CT.colorGradient = CG;
                BT.colorGradient = CG;
                if (CurrentTimeFloat < PlayerBestTime)
                {
                    PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                    PBT.colorGradient = CG;
                    BetterTime.SetActive(true);
                }
                else if (CurrentTimeFloat >= PlayerBestTime && PlayerBestTime != 0)
                {
                    BetterTime.SetActive(true);
                    PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                }
                else
                {
                    PBT.colorGradient = CG;
                    PlayerBestTime = CurrentTimeFloat;
                    LvlCompletedText.SetActive(true);
                }

                PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                SubScore(float.Parse(CurrentTime), CurrentLvl);
            }
            else if (CurrentTimeFloat >= scoreLoad)
            {
                if (CurrentTimeFloat < PlayerBestTime)
                {
                    CT.colorGradient = CG;
                    PBT.colorGradient = CG;
                    PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                    GettingBetter.SetActive(true);
                    SubScore(float.Parse(CurrentTime), CurrentLvl);
                }
                else if (CurrentTimeFloat >= PlayerBestTime && PlayerBestTime != 0)
                {
                    TryFaster.SetActive(true);
                }
                else
                {
                    CT.colorGradient = CG;
                    PBT.colorGradient = CG;
                    PlayerBestTime = CurrentTimeFloat;
                    PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
                    LvlCompletedText.SetActive(true);
                    SubScore(float.Parse(CurrentTime), CurrentLvl);
                }
            }
        }
        else if(scoreLoad == -1)
        {
            BestTime = 0;
            if (PlayerBestTime == 0)
            {
                CT.colorGradient = CG;  
                PBT.colorGradient = CG;
                LvlCompletedText.SetActive(true);
                PlayerBestTime = CurrentTimeFloat;
                PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
            }
            else if (CurrentTimeFloat < PlayerBestTime)
            {
                CT.colorGradient = CG;
                PBT.colorGradient = CG;
                GettingBetter.SetActive(true);
                PlayerPrefs.SetFloat("Level " + CurrentLvl.ToString() + " Best Time", CurrentTimeFloat);
            }
            else if (CurrentTimeFloat >= PlayerBestTime)
            {
                TryFaster.SetActive(true);
            }
        }
        if (CurrentLvl + 1 > PlayerPrefs.GetInt("Level Completed") && CurrentLvl + 1 < 31)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 2);
            PlayerPrefs.SetInt("Level Completed", CurrentLvl + 1);
        }
        else if (CurrentLvl + 1 == 31)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5);
        }

        //Without Upgrades LvlCounter
        if (PlayerPrefs.GetInt("SpeedUpgrade") == 0 && PlayerPrefs.GetInt("SlowMotionUpgrade") == 0 && PlayerPrefs.GetInt("SlowEnemyUpgrade") == 0 &&
            PlayerPrefs.GetInt("SmallCubeUpgrade") == 0 && PlayerPrefs.GetInt("SmallEnemyUpgrade") == 0 && PlayerPrefs.GetInt("GhostUpgrade") == 0)
        {
            LevelCounter.WithoutUpgrades++;
        }
        else
        {
            LevelCounter.WithoutUpgrades = 0;
        }

        //Without Deaths LvlCounter
        if (Deaths == 0)
        {
            LevelCounter.WithoutDeaths++;
        }
        else
        {
            LevelCounter.WithoutDeaths = 0;
        }


        //---------------------------------------------------------------Achievements:
        //Levels Completed
        if (PlayerPrefs.GetInt("Level Completed") == 6 && PlayerPrefs.GetInt("Achievement 0") == 0)
        {
            PlayerPrefs.SetInt("Achievement 0", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl5.IsUnlocked)
            {
                Achievements.Lvl5.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Level Completed") == 11 && PlayerPrefs.GetInt("Achievement 1") == 0)
        {
            PlayerPrefs.SetInt("Achievement 1", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl10.IsUnlocked)
            {
                Achievements.Lvl10.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Level Completed") == 16 && PlayerPrefs.GetInt("Achievement 2") == 0)
        {
            PlayerPrefs.SetInt("Achievement 2", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl15.IsUnlocked)
            {
                Achievements.Lvl15.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Level Completed") == 21 && PlayerPrefs.GetInt("Achievement 3") == 0)
        {
            PlayerPrefs.SetInt("Achievement 3", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl20.IsUnlocked)
            {
                Achievements.Lvl20.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Level Completed") == 26 && PlayerPrefs.GetInt("Achievement 4") == 0)
        {
            PlayerPrefs.SetInt("Achievement 4", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl25.IsUnlocked)
            {
                Achievements.Lvl25.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Level Completed") == 31 && PlayerPrefs.GetInt("Achievement 5") == 0)
        {
            PlayerPrefs.SetInt("Achievement 5", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl30.IsUnlocked)
            {
                Achievements.Lvl30.Unlock();
            }
        }

        //Without upgrades in a row
        if (PlayerPrefs.GetInt("Achievement 6") == 0 && LevelCounter.WithoutUpgrades == 5)
        {
            PlayerPrefs.SetInt("Achievement 6", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl5wu.IsUnlocked)
            {
                Achievements.Lvl5wu.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 7") == 0 && LevelCounter.WithoutUpgrades == 10)
        {
            PlayerPrefs.SetInt("Achievement 7", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl10wu.IsUnlocked)
            {
                Achievements.Lvl10wu.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 8") == 0 && LevelCounter.WithoutUpgrades == 15)
        {
            PlayerPrefs.SetInt("Achievement 8", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl15wu.IsUnlocked)
            {
                Achievements.Lvl15wu.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 9") == 0 && LevelCounter.WithoutUpgrades == 20)
        {
            PlayerPrefs.SetInt("Achievement 9", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl20wu.IsUnlocked)
            {
                Achievements.Lvl20wu.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 10") == 0 && LevelCounter.WithoutUpgrades == 25)
        {
            PlayerPrefs.SetInt("Achievement 10", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl25wu.IsUnlocked)
            {
                Achievements.Lvl25wu.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 11") == 0 && LevelCounter.WithoutUpgrades == 30)
        {
            PlayerPrefs.SetInt("Achievement 11", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl30wu.IsUnlocked)
            {
                Achievements.Lvl30wu.Unlock();
            }
        }

        //without deaths in a row
        if (PlayerPrefs.GetInt("Achievement 12") == 0 && LevelCounter.WithoutDeaths == 5)
        {
            PlayerPrefs.SetInt("Achievement 12", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl5wd.IsUnlocked)
            {
                Achievements.Lvl5wd.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 13") == 0 && LevelCounter.WithoutDeaths == 10)
        {
            PlayerPrefs.SetInt("Achievement 13", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl10wd.IsUnlocked)
            {
                Achievements.Lvl10wd.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 14") == 0 && LevelCounter.WithoutDeaths == 15)
        {
            PlayerPrefs.SetInt("Achievement 14", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl15wd.IsUnlocked)
            {
                Achievements.Lvl15wd.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 15") == 0 && LevelCounter.WithoutDeaths == 20)
        {
            PlayerPrefs.SetInt("Achievement 15", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl20wd.IsUnlocked)
            {
                Achievements.Lvl20wd.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 16") == 0 && LevelCounter.WithoutDeaths == 25)
        {
            PlayerPrefs.SetInt("Achievement 16", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl25wd.IsUnlocked)
            {
                Achievements.Lvl25wd.Unlock();
            }
        }
        if (PlayerPrefs.GetInt("Achievement 17") == 0 && LevelCounter.WithoutDeaths == 30)
        {
            PlayerPrefs.SetInt("Achievement 17", 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + achivementnagrade);
            if (!Achievements.Lvl30wd.IsUnlocked)
            {
                Achievements.Lvl30wd.Unlock();
            }
        }
    }
    public void AddToken(Vector3 T)
    {
        TokenSpawn[TokenCount] = T; // #T
        TokenCount++;
    }
    public void CameraChange()
    {
        if (PlayerPrefs.GetInt("Camera") == 1)
        {
            DefaultCam.SetActive(false);
            TwoDCam.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Camera") == 0)
        {
            TwoDCam.SetActive(false);
            DefaultCam.SetActive(true);
        }
        else
        {
            TwoDCam.SetActive(false);
            DefaultCam.SetActive(true);
        }
    }

     public void LoadScore(int lvl)
     {
            try
            {
                if (lvl == 1)
                {
                    Leaderboards.Lvl1.LoadScores(scores => { scoreLoad = scoref(scores); });

                }
                else if (lvl == 2)
                {
                    Leaderboards.Lvl2.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 3)
                {
                    Leaderboards.Lvl3.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 4)
                {
                    Leaderboards.Lvl4.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 5)
                {
                    Leaderboards.Lvl5.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 6)
                {
                    Leaderboards.Lvl6.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 7)
                {
                    Leaderboards.Lvl7.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 8)
                {
                    Leaderboards.Lvl8.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 9)
                {
                    Leaderboards.Lvl9.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 10)
                {
                    Leaderboards.Lvl10.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 11)
                {
                    Leaderboards.Lvl11.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 12)
                {
                    Leaderboards.Lvl12.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 13)
                {
                    Leaderboards.Lvl13.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 14)
                {
                    Leaderboards.Lvl14.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 15)
                {
                    Leaderboards.Lvl15.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 16)
                {
                    Leaderboards.Lvl16.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 17)
                {
                    Leaderboards.Lvl17.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 18)
                {
                    Leaderboards.Lvl18.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 19)
                {
                    Leaderboards.Lvl19.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 20)
                {
                    Leaderboards.Lvl20.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 21)
                {
                    Leaderboards.Lvl21.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 22)
                {
                    Leaderboards.Lvl22.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 23)
                {
                    Leaderboards.Lvl23.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 24)
                {
                    Leaderboards.Lvl24.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 25)
                {
                    Leaderboards.Lvl25.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 26)
                {
                    Leaderboards.Lvl26.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 27)
                {
                    Leaderboards.Lvl27.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 28)
                {
                    Leaderboards.Lvl28.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 29)
                {
                    Leaderboards.Lvl29.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
                else if (lvl == 30)
                {
                    Leaderboards.Lvl30.LoadScores(scores => { scoreLoad = scoref(scores); });
                }
            }
            catch (Exception e)
            {
                scoreLoad = -1;
            }
        
     } 
     public float scoref(IScore[] scores)
     {
         float score = 0;

         if (scores.Length > 0)
         {
            foreach (IScore scoree in scores)
            {
                 if (scoree.rank == 1 )
                 {
                    score = float.Parse(scoree.formattedValue) /100;
                    break;
                 }

             }
        }
         else
         {
            //no score found
             score = 0;
         }

        return score;
     }

    public void SubScore(float time, int lvl)
    {
        time = time * 100;
  
            if (lvl == 1)
            {
               Leaderboards.Lvl1.SubmitScore((long)time);
            }
            else if (lvl == 2)
            {
               Leaderboards.Lvl2.SubmitScore((long)time);
            }
            else if (lvl == 3)
            {
               Leaderboards.Lvl3.SubmitScore((long)time);
            }
            else if (lvl == 4)
            {
               Leaderboards.Lvl4.SubmitScore((long)time);
            }
            else if (lvl == 5)
            {
               Leaderboards.Lvl5.SubmitScore((long)time);
            }
            else if (lvl == 6)
            {
               Leaderboards.Lvl6.SubmitScore((long)time);
            }
            else if (lvl == 7)
            {
               Leaderboards.Lvl7.SubmitScore((long)time);
            }
            else if (lvl == 8)
            {
               Leaderboards.Lvl8.SubmitScore((long)time);
            }
            else if (lvl == 9)
            {
               Leaderboards.Lvl9.SubmitScore((long)time);
            }
            else if (lvl == 10)
            {
               Leaderboards.Lvl10.SubmitScore((long)time);
            }
            else if (lvl == 11)
            {
               Leaderboards.Lvl11.SubmitScore((long)time);
            }
            else if (lvl == 12)
            {
               Leaderboards.Lvl12.SubmitScore((long)time);
            }
            else if (lvl == 13)
            {
               Leaderboards.Lvl13.SubmitScore((long)time);
            }
            else if (lvl == 14)
            {
               Leaderboards.Lvl14.SubmitScore((long)time);
            }
            else if (lvl == 15)
            {
               Leaderboards.Lvl15.SubmitScore((long)time);
            }
            else if (lvl == 16)
            {
               Leaderboards.Lvl16.SubmitScore((long)time);
            }
            else if (lvl == 17)
            {
               Leaderboards.Lvl17.SubmitScore((long)time);
            }
            else if (lvl == 18)
            {
               Leaderboards.Lvl18.SubmitScore((long)time);
            }
            else if (lvl == 19)
            {
               Leaderboards.Lvl19.SubmitScore((long)time);
            }
            else if (lvl == 20)
            {
               Leaderboards.Lvl20.SubmitScore((long)time);
            }
            else if (lvl == 21)
            {
               Leaderboards.Lvl21.SubmitScore((long)time);
            }
            else if (lvl == 22)
            {
               Leaderboards.Lvl22.SubmitScore((long)time);
            }
            else if (lvl == 23)
            {
               Leaderboards.Lvl23.SubmitScore((long)time);
            }
            else if (lvl == 24)
            {
               Leaderboards.Lvl24.SubmitScore((long)time);
            }
            else if (lvl == 25)
            {
               Leaderboards.Lvl25.SubmitScore((long)time);
            }
            else if (lvl == 26)
            {
               Leaderboards.Lvl26.SubmitScore((long)time);
            }
            else if (lvl == 27)
            {
               Leaderboards.Lvl27.SubmitScore((long)time);
            }
            else if (lvl == 28)
            {
               Leaderboards.Lvl28.SubmitScore((long)time);
            }
            else if (lvl == 29)
            {
               Leaderboards.Lvl29.SubmitScore((long)time);
            }
            else if (lvl == 30)
            {
               Leaderboards.Lvl30.SubmitScore((long)time);
            }
        
    }
}
