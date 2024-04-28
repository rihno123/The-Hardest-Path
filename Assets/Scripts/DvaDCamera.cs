using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvaDCamera : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        gameObject.transform.position = Player.transform.position + new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.position = Player.transform.position + new Vector3(0, 20, 0);
    }
}
