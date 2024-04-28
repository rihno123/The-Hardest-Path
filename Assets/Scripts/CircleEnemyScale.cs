using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyScale : MonoBehaviour
{

    void Start()
    {
        gameObject.transform.position -= new Vector3(0, Mathf.Round(PlayerPrefs.GetInt("SmallEnemyUpgrade")) / 66, 0);
    }

}
