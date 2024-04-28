using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloudOnceServices : MonoBehaviour
{
    public static CloudOnceServices instance;

    private void Awake()
    {
        CheckInstance();
    }
    private void CheckInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

   


}
