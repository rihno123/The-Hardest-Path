using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatEnemy : MonoBehaviour
{
    //svaki "Enemy" mora imati svoh "enemyDoCIlja".
    public GameObject[] Enemy;
    public EnemyDoCIlja[] enemyDoCilja;
    void OnDestroy()
    {
        for(int i = 0; i<Enemy.Length; i++)
        {
            if (Enemy[i] != null)
            {
                Enemy[i].SetActive(false);
                Enemy[i].transform.position = enemyDoCilja[i].EnemyPoint[0].position;
            }
        }

    }

}
