using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Tutorial1,Tutorial2,Tutorial3, Tutorial4;
    public Transform Tutparent;
    public PlayerMovement PM;
    private GameObject GO;
    TMPro.TMP_Text Tekst;
    float timer = 0;

    bool b1, b2, b3, b4, b5;
    void Start()
    {
        b1 = false;
        b2 = false;
        b3 = false;
        b4 = false;
        b5 = true;
        if (PlayerPrefs.GetInt("Level Completed") == 1)
        {
            
           GO = Instantiate(Tutorial1, Tutparent.transform.position, Quaternion.identity, Tutparent);
           GO.transform.SetAsFirstSibling();
           Time.timeScale = 0;
           //Time.fixedDeltaTime = (Time.timeScale + 1) * 0.02f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Level Completed") == 1)
        {
            timer += Time.unscaledDeltaTime;
            if (!b4 && PM.input != Vector3.zero && !b1 && !b2 && !b3 && timer >= 2)
            {
                Destroy(GO);
                GO = Instantiate(Tutorial2, Tutparent.transform.position, Quaternion.identity, Tutparent);
                GO.transform.SetAsFirstSibling();
                b1 = true;
                timer = 0;
            }
            if (!b4 && PM.input != Vector3.zero && b1 && timer >= 2)
            {
                GO.transform.GetComponentInChildren<TMPro.TMP_Text>().text = "This is button for 'Slow Motion'.\nYou can buy it in the shop!";
                GO.transform.GetChild(0).gameObject.SetActive(false);
                b1 = false;
                b2 = true;
                timer = 0;
            }
            if (!b4 && PM.input != Vector3.zero && b2 && timer >= 2)
            {
                GO.transform.GetComponentInChildren<TMPro.TMP_Text>().text = "This is button for 'Ghost' ability.\nYou can buy it in the shop!";
                GO.transform.GetChild(1).gameObject.SetActive(false);
                GO.transform.GetChild(0).gameObject.SetActive(true);
                b2 = false;
                b3 = true;
                timer = 0;
            }
            if (!b4 && PM.input != Vector3.zero && b3 && timer >= 2)
            {
                Destroy(GO);
                GO = Instantiate(Tutorial3, Tutparent.transform.position, Quaternion.identity, Tutparent);
                GO.transform.SetAsFirstSibling();
                b3 = false;
                b4 = true;
                timer = 0;
            }
            if (b4 && PM.input != Vector3.zero && timer >= 2 && b5)
            {
                Destroy(GO);
                timer = 0;
                b5 = false;
                GO = Instantiate(Tutorial4, Tutparent.transform.position, Quaternion.identity, Tutparent);
                GO.transform.position += new Vector3(0,-85,0);
            }
            if (b4 && PM.input != Vector3.zero && timer >= 2 && !b5)
            {
                Time.timeScale = 1;
                Destroy(GO);
                RemoveScript();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void RemoveScript()
    {
        Destroy(gameObject);
    }
}
