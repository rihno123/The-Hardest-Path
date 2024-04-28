using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject[] Enemy;
    void OnDestroy()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i] != null)
            {
                Enemy[i].SetActive(false);
            }
        }
    }
}
