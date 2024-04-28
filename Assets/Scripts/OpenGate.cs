using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject ActivationObject;
    public Transform Cilj;
    public float speed;
    public bool Deactivate;

    void LateUpdate()
    {
        if(ActivationObject == null)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Cilj.position,speed*Time.deltaTime);
        }
        if(gameObject.transform.position == Cilj.position && Deactivate && ActivationObject == null)
        {
            gameObject.SetActive(false);
        }
    }
}
