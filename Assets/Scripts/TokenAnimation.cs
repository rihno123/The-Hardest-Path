using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenAnimation : MonoBehaviour
{
    public GameObject[] EnemiesToSpawn;
    void Start()
    {
        for (int i = 0; i < EnemiesToSpawn.Length; i++)
        {
            if (EnemiesToSpawn[i] != null)
            {
                EnemiesToSpawn[i].SetActive(false);
            }
        }
        StartCoroutine(Animation());
    }
    
    IEnumerator Animation()
    {
        while(true)
        {
        GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        }

    }
    void OnDestroy()
    {
        for(int i = 0;i<EnemiesToSpawn.Length; i++)
        {
            if (EnemiesToSpawn[i] != null)
            {
                EnemiesToSpawn[i].SetActive(true);
            }
        }
    }
}
