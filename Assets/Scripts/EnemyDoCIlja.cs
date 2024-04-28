using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoCIlja : MonoBehaviour
{
    int CurrentPoint;
    public Transform[] EnemyPoint;
    public float moveSpeed;


    void Start()
    {
        gameObject.transform.position = EnemyPoint[0].position;
    }
    void FixedUpdate()
    {
        if (transform.position == EnemyPoint[CurrentPoint].position && CurrentPoint != EnemyPoint.Length-1)
        {
            CurrentPoint++;
        }
        transform.position = Vector3.MoveTowards(transform.position, EnemyPoint[CurrentPoint].position, (moveSpeed - moveSpeed * Mathf.Round(PlayerPrefs.GetInt("SlowEnemyUpgrade")) / 33) * Time.deltaTime);
    }
}
