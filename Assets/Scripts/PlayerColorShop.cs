using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerColorShop : MonoBehaviour
{
    public GameObject ShopMenu,ColorMenu;
    public Animator Animator;
    public ToggleGroup Togglegroup;
    public Toggle[] Toggles;
    public TMPro.TMP_Text Money;
    private TMPro.TMP_Text[] Price;
    public BuyColor[] BuyButton;
    public Image[] Coin;
    public float frameTimer;

    public void Awake()
    {
        Toggles = Togglegroup.GetComponentsInChildren<Toggle>();
        for(int i=1; i< Togglegroup.transform.childCount; i++)
        {
            if(PlayerPrefs.GetInt("OwnedColor" +i.ToString()) == 1 && PlayerPrefs.HasKey("OwnedColor" +i.ToString()) == true)
            {
                BuyButton[i-1].gameObject.SetActive(false);
                Toggles[i].interactable = true;
                Price = Toggles[i].GetComponentsInChildren<TMPro.TMP_Text>();
                Coin = Toggles[i].GetComponentsInChildren<Image>();
                Color tempColor = Coin[3].color;
                tempColor.a = 0f;
                Coin[3].color = tempColor;
                Price[1].alignment = TextAlignmentOptions.Center;
                Price[1].text = "Owned";
            }
        }
    }

    void Start()
    {
        Money.text = PlayerPrefs.GetInt("Money").ToString();
        Toggles[PlayerPrefs.GetInt("Color")].isOn = true;
        frameTimer = Time.time;
    }
    

    void FixedUpdate()
    {
        if (Time.time - frameTimer >= 0.2)
        {
            //print(PlayerPrefs.GetInt("Color"));
            Money.text = PlayerPrefs.GetInt("Money").ToString();
            frameTimer = Time.time;
        }
    }

    public void SelectedColor(Toggle toggle)
    {
        if(toggle.isOn)
        {
            for(int i = 0; i< Togglegroup.transform.childCount; i++)
            {
                if(Toggles[i].isOn)
                {
                    PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money"));
                    PlayerPrefs.SetInt("Color",i);
                }   
            }
        }
    }
    
    public void BackButtonToShop()
    {
        ColorMenu.SetActive(false);
        ShopMenu.SetActive(true);
    }


}
