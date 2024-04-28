using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    private float timer;
    private bool ActivatedOnce = false;
    public Image ButtonUpgradeImage;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("SlowMotionUpgrade") == 0)
        {
            ButtonUpgradeImage.fillAmount = 1;
        }
    }
    public void SlowMot()
    {
        if(PlayerPrefs.GetInt("SlowMotionUpgrade") != 0 && ActivatedOnce == false)
        {
        timer = 0f;
        Time.timeScale = 0.1f;
        ActivatedOnce = true;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeScale == 0.1f)
        {
            timer += Time.deltaTime * 10;
            ButtonUpgradeImage.fillAmount = timer/PlayerPrefs.GetInt("SlowMotionUpgrade");
            if (timer >= PlayerPrefs.GetInt("SlowMotionUpgrade"))
            {
                timer = 0f;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }
    }
}
