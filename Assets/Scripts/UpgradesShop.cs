using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpgradesShop : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject[] Pages; 
    public TMPro.TMP_Text UpgradedSpeedText,UpgradedSlowMotion,UpgradedSlowEnemy,UpgradedSmallCube,UpgradedSmallEnemyText,UpgradedGhostText;
    public TMPro.TMP_Text[] Money;
    public TMPro.TMP_Text[] Price;
    public GameObject[] Coin;
    private Vector2 deltasize = new Vector2(50, 50);
    public float frameTime;
 
   /*  void Awake()
    {
        //PlayerPrefs.SetInt("SpeedUpgrade",0);
    } */

    void Start()
    {
        frameTime = Time.time;
        //PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") + 1000);
    }

    void FixedUpdate()
    {
        if (Time.time - frameTime >= 0.75)
        {
            UpgradedSmallCube.text = PlayerPrefs.GetInt("SmallCubeUpgrade").ToString() + "/5";
            UpgradedSlowEnemy.text = PlayerPrefs.GetInt("SlowEnemyUpgrade").ToString() + "/5";
            UpgradedSlowMotion.text = PlayerPrefs.GetInt("SlowMotionUpgrade").ToString() + "/5";
            UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString() + "/5";
            UpgradedSmallEnemyText.text = PlayerPrefs.GetInt("SmallEnemyUpgrade").ToString() + "/5";
            UpgradedGhostText.text = PlayerPrefs.GetInt("GhostUpgrade").ToString() + "/5";
            for (int i = 0; i < Money.Length; i++)
            {
                Money[i].text = PlayerPrefs.GetInt("Money").ToString();
            }
            //Speed Upgrade
            if (PlayerPrefs.GetInt("MaxSpeedUpgrade") == 0)
            {
                Price[0].text = "1";
            }
            else if (PlayerPrefs.GetInt("MaxSpeedUpgrade") < 5)
            {
                Price[0].text = (PlayerPrefs.GetInt("MaxSpeedUpgrade") * 2).ToString();
                //Price[0].rectTransform.sizeDelta = deltasize;
            }
            else
            {
                if (Price[0].text != "Max")
                {
                    Coin[0].SetActive(false);
                    Price[0].text = "Max";
                    Price[0].rectTransform.anchoredPosition += new Vector2(30, 0);
                    // Price[0].rectTransform.sizeDelta = deltasize;
                }
            }
            //Slow Motion Upgrade
            if (PlayerPrefs.GetInt("MaxSlowMotionUpgrade") == 0)
            {
                Price[1].text = "3";
            }
            else if (PlayerPrefs.GetInt("MaxSlowMotionUpgrade") < 5)
            {
                Price[1].text = ((PlayerPrefs.GetInt("MaxSlowMotionUpgrade") + 1) * 3).ToString();
                //Price[1].rectTransform.sizeDelta = deltasize;
            }
            else
            {
                if (Price[1].text != "Max")
                {
                    Coin[1].SetActive(false);
                    Price[1].text = "Max";
                    Price[1].rectTransform.anchoredPosition += new Vector2(30, 0);
                    //Price[1].rectTransform.sizeDelta = deltasize;
                }
            }
            //Slow Enemy Upgrade
            if (PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") == 0)
            {
                Price[2].text = "2";
            }
            else if (PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") < 5)
            {
                Price[2].text = ((PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") + 1) * 2).ToString();
                //Price[2].rectTransform.sizeDelta = deltasize;
            }
            else
            {
                if (Price[2].text != "Max")
                {
                    Coin[2].SetActive(false);
                    Price[2].text = "Max";
                    Price[2].rectTransform.anchoredPosition += new Vector2(30, 0);
                    //Price[2].rectTransform.sizeDelta = deltasize;
                }
            }
            //Small Cube Upgrade
            if (PlayerPrefs.GetInt("MaxSmallCubeUpgrade") == 0)
            {
                Price[3].text = "1";
            }
            else if (PlayerPrefs.GetInt("MaxSmallCubeUpgrade") < 5)
            {
                Price[3].text = (PlayerPrefs.GetInt("MaxSmallCubeUpgrade") * 2).ToString();
                //Price[3].rectTransform.sizeDelta = deltasize;
            }
            else
            {
                if (Price[3].text != "Max")
                {
                    Coin[3].SetActive(false);
                    Price[3].text = "Max";
                    Price[3].rectTransform.anchoredPosition += new Vector2(30, 0);
                    //Price[3].rectTransform.sizeDelta = deltasize;
                }
            }
            //Small Enemy Upgrade
            if (PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") == 0)
            {
                Price[4].text = "2";
            }
            else if (PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") < 5)
            {
                Price[4].text = ((PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") + 1) * 2).ToString();
                //Price[4].rectTransform.sizeDelta = deltasize;
            }
            else
            {
                if (Price[4].text != "Max")
                {
                    Coin[4].SetActive(false);
                    Price[4].text = "Max";
                    Price[4].rectTransform.anchoredPosition += new Vector2(30, 0);
                    // Price[4].rectTransform.sizeDelta = deltasize;
                }
            }
            //Ghost Upgrade
            if (PlayerPrefs.GetInt("MaxGhostUpgrade") == 0)
            {
                Price[5].text = "10";
            }
            else if (PlayerPrefs.GetInt("MaxGhostUpgrade") < 5)
            {
                Price[5].text = ((PlayerPrefs.GetInt("MaxGhostUpgrade") + 4) * 3).ToString();
                //Price[5].rectTransform.sizeDelta = deltasize;
            }
            else
            {
                if (Price[5].text != "Max")
                {
                    Coin[5].SetActive(false);
                    Price[5].text = "Max";
                    Price[5].rectTransform.anchoredPosition += new Vector2(30, 0);
                    //Price[5].rectTransform.sizeDelta = deltasize;
                }
            }
            frameTime = Time.time;
        }
    }

    //speed upgrade start:
    public void BuySpeed()
    {
        if(PlayerPrefs.GetInt("Money") >= 1 && PlayerPrefs.GetInt("MaxSpeedUpgrade") == 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 1);
           // Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSpeedUpgrade",PlayerPrefs.GetInt("MaxSpeedUpgrade") + 1);
            PlayerPrefs.SetInt("SpeedUpgrade",PlayerPrefs.GetInt("SpeedUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        else if(PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("MaxSpeedUpgrade")*2 && PlayerPrefs.GetInt("MaxSpeedUpgrade") < 5 && PlayerPrefs.GetInt("MaxSpeedUpgrade") != 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("MaxSpeedUpgrade")*2);
            //Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSpeedUpgrade",PlayerPrefs.GetInt("MaxSpeedUpgrade") + 1);
            PlayerPrefs.SetInt("SpeedUpgrade",PlayerPrefs.GetInt("SpeedUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
    }

    public void ModifySpeedPlus()
    {
        if(PlayerPrefs.GetInt("SpeedUpgrade") < 5 && PlayerPrefs.GetInt("SpeedUpgrade") < PlayerPrefs.GetInt("MaxSpeedUpgrade"))
        {
            PlayerPrefs.SetInt("SpeedUpgrade",PlayerPrefs.GetInt("SpeedUpgrade") + 1);
        }
    }

    public void ModifySpeedMinus()
    {
        if(PlayerPrefs.GetInt("SpeedUpgrade") > 0)
        {
            PlayerPrefs.SetInt("SpeedUpgrade",PlayerPrefs.GetInt("SpeedUpgrade") - 1);
        }
    }
    //speed upgrade end

    //Slow Motion upgrade start
    public void BuySlowMotion()
    {
        if(PlayerPrefs.GetInt("Money") >= 3 && PlayerPrefs.GetInt("MaxSlowMotionUpgrade") == 0 )
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 3);
           // Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSlowMotionUpgrade",PlayerPrefs.GetInt("MaxSlowMotionUpgrade") + 1);
            PlayerPrefs.SetInt("SlowMotionUpgrade",PlayerPrefs.GetInt("SlowMotionUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        else if(PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("MaxSlowMotionUpgrade")*3 && PlayerPrefs.GetInt("MaxSlowMotionUpgrade") < 5 && PlayerPrefs.GetInt("MaxSlowMotionUpgrade") != 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - ((PlayerPrefs.GetInt("MaxSlowMotionUpgrade") + 1) * 3));
            //Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSlowMotionUpgrade",PlayerPrefs.GetInt("MaxSlowMotionUpgrade") + 1);
            PlayerPrefs.SetInt("SlowMotionUpgrade",PlayerPrefs.GetInt("SlowMotionUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
    }

    public void ModifySlowMotionPlus()
    {
        if(PlayerPrefs.GetInt("SlowMotionUpgrade") < 5 && PlayerPrefs.GetInt("SlowMotionUpgrade") < PlayerPrefs.GetInt("MaxSlowMotionUpgrade"))
        {
            PlayerPrefs.SetInt("SlowMotionUpgrade",PlayerPrefs.GetInt("SlowMotionUpgrade") + 1);
        }
    }

    public void ModifySlowMotionMinus()
    {
        if(PlayerPrefs.GetInt("SlowMotionUpgrade") > 0)
        {
            PlayerPrefs.SetInt("SlowMotionUpgrade",PlayerPrefs.GetInt("SlowMotionUpgrade") - 1);
        }
    }
    //Slow Motion upgrade end
    //Slow Enemy upgrade start
 public void BuySlowEnemy()
    {
        if(PlayerPrefs.GetInt("Money") >= 1 && PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") == 0 )
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 2);
           // Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSlowEnemyUpgrade",PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") + 1);
            PlayerPrefs.SetInt("SlowEnemyUpgrade",PlayerPrefs.GetInt("SlowEnemyUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        else if(PlayerPrefs.GetInt("Money") >= (PlayerPrefs.GetInt("MaxSlowEnemyUpgrade")+1)*2 && PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") < 5 && PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") != 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - (PlayerPrefs.GetInt("MaxSlowEnemyUpgrade")+1)*2);
            //Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSlowEnemyUpgrade",PlayerPrefs.GetInt("MaxSlowEnemyUpgrade") + 1);
            PlayerPrefs.SetInt("SlowEnemyUpgrade",PlayerPrefs.GetInt("SlowEnemyUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        //Napomena!!!! Ako mijenjam cijenu ovoga onda moram ovo prilagodit novoj cijeni 10 je cijena zadnjeg upgrade,a 12 cijena nepostojeceg 6 upgrade-a
    }

    public void ModifySlowEnemyPlus()
    {
        if(PlayerPrefs.GetInt("SlowEnemyUpgrade") < 5 && PlayerPrefs.GetInt("SlowEnemyUpgrade") < PlayerPrefs.GetInt("MaxSlowEnemyUpgrade"))
        {
            PlayerPrefs.SetInt("SlowEnemyUpgrade",PlayerPrefs.GetInt("SlowEnemyUpgrade") + 1);
        }
    }

    public void ModifySlowEnemyMinus()
    {
        if(PlayerPrefs.GetInt("SlowEnemyUpgrade") > 0)
        {
            PlayerPrefs.SetInt("SlowEnemyUpgrade",PlayerPrefs.GetInt("SlowEnemyUpgrade") - 1);
        }
    }
    //Slow Enemy upgrade end
    //Small Cube upgrade start
 public void BuySmallCube()
    {
        if(PlayerPrefs.GetInt("Money") >= 1 && PlayerPrefs.GetInt("MaxSmallCubeUpgrade") == 0 )
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 1);
           // Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSmallCubeUpgrade",PlayerPrefs.GetInt("MaxSmallCubeUpgrade") + 1);
            PlayerPrefs.SetInt("SmallCubeUpgrade",PlayerPrefs.GetInt("SmallCubeUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        else if(PlayerPrefs.GetInt("Money") >= PlayerPrefs.GetInt("MaxSmallCubeUpgrade")*2 && PlayerPrefs.GetInt("MaxSmallCubeUpgrade") < 5 && PlayerPrefs.GetInt("MaxSmallCubeUpgrade") != 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - PlayerPrefs.GetInt("MaxSmallCubeUpgrade")*2);
            //Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSmallCubeUpgrade",PlayerPrefs.GetInt("MaxSmallCubeUpgrade") + 1);
            PlayerPrefs.SetInt("SmallCubeUpgrade",PlayerPrefs.GetInt("SmallCubeUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
    }

    public void ModifySmallCubePlus()
    {
        if(PlayerPrefs.GetInt("SmallCubeUpgrade") < 5 && PlayerPrefs.GetInt("SmallCubeUpgrade") < PlayerPrefs.GetInt("MaxSmallCubeUpgrade"))
        {
            PlayerPrefs.SetInt("SmallCubeUpgrade",PlayerPrefs.GetInt("SmallCubeUpgrade") + 1);
        }
    }

    public void ModifySmallCubeMinus()
    {
        if(PlayerPrefs.GetInt("SmallCubeUpgrade") > 0)
        {
            PlayerPrefs.SetInt("SmallCubeUpgrade",PlayerPrefs.GetInt("SmallCubeUpgrade") - 1);
        }
    }
    //Small Cube upgrade end
    //Small Enemy upgrade start
 public void BuySmallEnemy()
    {
        if(PlayerPrefs.GetInt("Money") >= 2 && PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") == 0 )
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 2);
           // Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSmallEnemyUpgrade",PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") + 1);
            PlayerPrefs.SetInt("SmallEnemyUpgrade",PlayerPrefs.GetInt("SmallEnemyUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        else if(PlayerPrefs.GetInt("Money") >= (PlayerPrefs.GetInt("MaxSmallEnemyUpgrade")+1)*2 && PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") < 5 && PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") != 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - (PlayerPrefs.GetInt("MaxSmallEnemyUpgrade")+1)*2);
            //Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxSmallEnemyUpgrade",PlayerPrefs.GetInt("MaxSmallEnemyUpgrade") + 1);
            PlayerPrefs.SetInt("SmallEnemyUpgrade",PlayerPrefs.GetInt("SmallEnemyUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        //Napomena!!!! Ako mijenjam cijenu ovoga onda moram ovo prilagodit novoj cijeni 10 je cijena zadnjeg upgrade,a 12 cijena nepostojeceg 6 upgrade-a
    }

    public void ModifySmallEnemyPlus()
    {
        if(PlayerPrefs.GetInt("SmallEnemyUpgrade") < 5 && PlayerPrefs.GetInt("SmallEnemyUpgrade") < PlayerPrefs.GetInt("MaxSmallEnemyUpgrade"))
        {
            PlayerPrefs.SetInt("SmallEnemyUpgrade",PlayerPrefs.GetInt("SmallEnemyUpgrade") + 1);
        }
    }

    public void ModifySmallEnemyMinus()
    {
        if(PlayerPrefs.GetInt("SmallEnemyUpgrade") > 0)
        {
            PlayerPrefs.SetInt("SmallEnemyUpgrade",PlayerPrefs.GetInt("SmallEnemyUpgrade") - 1);
        }
    }
    //Small Enemy upgrade end

    //Ghost upgrade start
 public void BuyGhost()
    {
        if(PlayerPrefs.GetInt("Money") >= 10 && PlayerPrefs.GetInt("MaxGhostUpgrade") == 0 )
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - 10);
           // Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxGhostUpgrade",PlayerPrefs.GetInt("MaxGhostUpgrade") + 1);
            PlayerPrefs.SetInt("GhostUpgrade",PlayerPrefs.GetInt("GhostUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
            Price[5].text = ((PlayerPrefs.GetInt("MaxGhostUpgrade")+4)*3).ToString();
        }
        else if(PlayerPrefs.GetInt("Money") >= (PlayerPrefs.GetInt("MaxGhostUpgrade")+4)*3 && PlayerPrefs.GetInt("MaxGhostUpgrade") < 5 && PlayerPrefs.GetInt("MaxGhostUpgrade") != 0)
        {
            PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - (PlayerPrefs.GetInt("MaxGhostUpgrade")+4)*3);
            //Money.text = PlayerPrefs.GetInt("Money").ToString();
            PlayerPrefs.SetInt("MaxGhostUpgrade",PlayerPrefs.GetInt("MaxGhostUpgrade") + 1);
            PlayerPrefs.SetInt("GhostUpgrade",PlayerPrefs.GetInt("GhostUpgrade") + 1);
           // UpgradedSpeedText.text = PlayerPrefs.GetInt("SpeedUpgrade").ToString();
        }
        //Napomena!!!! Ako mijenjam cijenu ovoga onda moram ovo prilagodit novoj cijeni 10 je cijena zadnjeg upgrade,a 12 cijena nepostojeceg 6 upgrade-a
    }

    public void ModifyGhostPlus()
    {
        if(PlayerPrefs.GetInt("GhostUpgrade") < 5 && PlayerPrefs.GetInt("GhostUpgrade") < PlayerPrefs.GetInt("MaxGhostUpgrade"))
        {
            PlayerPrefs.SetInt("GhostUpgrade",PlayerPrefs.GetInt("GhostUpgrade") + 1);
        }
    }

    public void ModifyGhostMinus()
    {
        if(PlayerPrefs.GetInt("GhostUpgrade") > 0)
        {
            PlayerPrefs.SetInt("GhostUpgrade",PlayerPrefs.GetInt("GhostUpgrade") - 1);
        }
    }
    //Ghost upgrade end

    public void BackButtonToShopU()
    {
        Pages[0].SetActive(false);
        ShopMenu.SetActive(true);
    }

    public void PagesBack(int i)
    {
        Pages[i].SetActive(false);
        Pages[i - 1].SetActive(true);
    }
    public void PagesForward(int i)
    {
        Pages[i].SetActive(false);
        Pages[i + 1].SetActive(true);
    }
}
