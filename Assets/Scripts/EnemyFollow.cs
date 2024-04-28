using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Start,Player;
    public float moveSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.position, (moveSpeed - moveSpeed * Mathf.Round(PlayerPrefs.GetInt("SlowEnemyUpgrade")) / 33) * Time.deltaTime);
    }
}
