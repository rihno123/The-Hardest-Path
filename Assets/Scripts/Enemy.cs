using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] EnemyPoint;
    public float moveSpeed;
    private int CurrentPoint;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = EnemyPoint[0].position;
        CurrentPoint = 1;
        scale = (float)(gameObject.transform.localScale.x - Mathf.Round(PlayerPrefs.GetInt("SmallEnemyUpgrade"))/37);
        gameObject.transform.localScale = new Vector3(scale,scale,scale);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == EnemyPoint[CurrentPoint].position)
        {
            CurrentPoint++;
        }
        if(CurrentPoint == EnemyPoint.Length) //------->EnemyPoint.Lenght je broj elemenata u polju.
        {
            CurrentPoint = 0;
        }
       transform.position = Vector3.MoveTowards(transform.position, EnemyPoint[CurrentPoint].position,(moveSpeed - moveSpeed * Mathf.Round(PlayerPrefs.GetInt("SlowEnemyUpgrade"))/33) * Time.deltaTime);
    }
}
