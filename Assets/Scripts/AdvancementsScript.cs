using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancementsScript : MonoBehaviour
{
    public int NumOfAdv;
    public GameObject[] Checkmarks;


    void Start()
    {
    //PlayerPrefs.SetInt("Achievement 4",1);
        for(int i = 0; i < NumOfAdv; i++)
        {
            if(PlayerPrefs.GetInt("Achievement " + i.ToString()) == 1)
            {
                Checkmarks[i].SetActive(true);
            }

       //print(PlayerPrefs.GetInt("Achievement 1"));
        }


    }
}
