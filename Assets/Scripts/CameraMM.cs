using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMM : MonoBehaviour
{
    public Transform[] Point;
    public float moveSpeed;
    private int CurrentPoint;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Point[0].position;
        CurrentPoint = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == Point[CurrentPoint].position)
        {
            CurrentPoint++;
        }
        if(CurrentPoint == Point.Length)
        {
            CurrentPoint = 0;
        }
       transform.position = Vector3.MoveTowards(transform.position, Point[CurrentPoint].position,moveSpeed * Time.deltaTime);
    }
}
