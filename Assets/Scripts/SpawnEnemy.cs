using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy,ActivationObject;
    void Start()
    {
        Enemy.SetActive(false);
    }

    void LateUpdate()
    {
        if(ActivationObject == null)
        {
            Enemy.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
