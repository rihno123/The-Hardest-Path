using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string googleplayID = "3310883";
    private string appleappID = "3310882";

    private static string InterstitialAD = "video";
    private string RewardAD = "rewardedVideo";

    public bool isTargetApple;
    public bool isTestAd;

    public AudioSource Muzika; 
    void Start()
    {
        Advertisement.AddListener(this);
        Platforma();
    }

    void Platforma()
    {
        if(isTargetApple)
        {
            Advertisement.Initialize(appleappID,isTestAd);
        }
        else
        {
            Advertisement.Initialize(googleplayID, isTestAd);
        }
    }

    public static void PlayInterstitialAd()
    {
        if(Advertisement.IsReady(InterstitialAD))
        {
            Advertisement.Show(InterstitialAD);
        }
        else
        {
            return;
        }
    }
    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady(RewardAD))
        {
            Advertisement.Show(RewardAD);
        }
        else
        {
            return;
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        if(placementId == RewardAD)
        {
            Muzika.volume = 0;
        }

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == RewardAD)
                {
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
                    Debug.Log("yes");
                }
                break;
        }

        if (placementId == RewardAD)
        {
            Muzika.volume = 1;
        }

    }
}
