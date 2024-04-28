using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    public TMPro.TMP_Dropdown DDM;

    void Start()
    {
        if(PlayerPrefs.HasKey("Camera") == false)
        {
            PlayerPrefs.SetInt("Camera",0);
        }
        else if(PlayerPrefs.GetInt("Camera") == 0)
        {
            DDM.value = 0;
        }
        else if(PlayerPrefs.GetInt("Camera") == 1)
        {
            DDM.value = 1;
        }
    }
    public void Camera()
    {
        if(DDM.value==1)
        {
            PlayerPrefs.SetInt("Camera",1);
        }
        else if(DDM.value==0)
        {
            PlayerPrefs.SetInt("Camera",0);
        }
    }

}
