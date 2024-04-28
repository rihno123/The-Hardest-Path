using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Animator Animator;
    public MainMenu MM;
    public GameObject ColorMenu,ShopMenu,UpgradesMenu;

    public void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void OpenPlayerColorMenuButton()
    {
        ShopMenu.SetActive(false);
        ColorMenu.SetActive(true);
    }

    public void OpenUpgradesMenu()
    {
        ShopMenu.SetActive(false);
        UpgradesMenu.SetActive(true);
    }

    public void ShopMenuBackButton()
    {
        MM.BackShop();
    }


}
