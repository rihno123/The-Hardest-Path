using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInfo : MonoBehaviour
{
    bool open = false;
   public void Open()
    {
        GameObject GO = transform.GetChild(1).gameObject;
        if (!open)
        {
            GO.SetActive(true);
            open = true;
        }
        else
        {
            GO.SetActive(false);
            open = false;
        }
    }
}
