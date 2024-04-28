using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLevelDeaths : MonoBehaviour
{
    public GameManager GM;
    public TMPro.TMP_Text Timer,Level,Deaths;

    // Update is called once per frame
    void Update()
    {
        Timer.text = GM.CurrentTime;
        Deaths.text = (GM.Deaths.ToString());
        Level.text = (LevelCounter.Lvl.ToString()+ "/30");
    }

}
