using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyColor : MonoBehaviour
{
    public PlayerColorShop PCS;
    private TMPro.TMP_Text[] Price;
    public GameObject Coin;


    public void BuyColorButton(int i)
    {
        Price = PCS.Toggles[i].GetComponentsInChildren<TMPro.TMP_Text>();
        if(PlayerPrefs.GetInt("Money") >= StringToInt(Price[1].text))
        {
        PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") - StringToInt(Price[1].text));
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("OwnedColor" +i.ToString(),1);
        PCS.Toggles[i].interactable = true;
        Coin.SetActive(false);
        Price[1].alignment = TextAlignmentOptions.Center;
        Price[1].text = "Owned";
        }
    }
    
    private int StringToInt(string String)
    { 
        if(String[4] - 48 < 10 && String[4] - 48 >= 0)
        {
            return String[4] - 48;
        }
        else
        {
            return 0;
        }
    }
}
