using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCircle : MonoBehaviour
{
    public float FazniPomak;
    public Transform[] EnemyPoint;
    public float moveSpeed;
    float timeCounter = 0;
    public float Radius;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = EnemyPoint[0].position;
        scale = (float)(gameObject.transform.localScale.x - Mathf.Round(PlayerPrefs.GetInt("SmallEnemyUpgrade")) / 33);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }


    void Update () {
        timeCounter += Time.deltaTime;
        float x = Radius*Mathf.Sin ((moveSpeed-Mathf.Round(PlayerPrefs.GetInt("SlowEnemyUpgrade"))/15)*timeCounter + FazniPomak*Mathf.Deg2Rad);
        float y = 0.25f;
        float z = Radius*Mathf.Cos ((moveSpeed-Mathf.Round(PlayerPrefs.GetInt("SlowEnemyUpgrade"))/15)*timeCounter + FazniPomak*Mathf.Deg2Rad);
        transform.position = EnemyPoint[0].position + new Vector3 (x, y, z);
    }
}
