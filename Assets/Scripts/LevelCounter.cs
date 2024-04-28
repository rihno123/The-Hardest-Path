using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCounter : MonoBehaviour
{
    public static int Lvl = 0;
    public static int Deaths = 0;//Iskoristit za nesto,(broji Deaths kroz sve levele od kada pocnes igrat bilo koji lvl)
    public static int WithoutUpgrades = 0;
    public static int WithoutDeaths = 0;
}

