using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    Renderer render;
    Color def; //default color
    public GameObject Particles;
    private ParticleSystem.MainModule PS;
    void Awake()
    {   
        if(PlayerPrefs.HasKey("Color") == false)
        {
            PlayerPrefs.SetInt("Color",0);
        }
        //PlayerPrefs.SetInt("Color",7);
        def = new Color(0,0.4228201f,1,1);
        render = GetComponent<Renderer>();
        if(PlayerPrefs.GetInt("Color") == 1)
        {        
            render.material.color = Color.yellow;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.yellow;
        }
        if(PlayerPrefs.GetInt("Color") == 2)
        {        
            render.material.color = Color.green;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.green;
        }
        if(PlayerPrefs.GetInt("Color") == 3)
        {        
            render.material.color = Color.magenta;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.magenta;
        }
        if(PlayerPrefs.GetInt("Color") == 4)
        {        
            render.material.color = Color.grey;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.grey;
        }
        if(PlayerPrefs.GetInt("Color") == 5)
        {        
            render.material.color = Color.red;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.red;
        }
        if(PlayerPrefs.GetInt("Color") == 6)
        {        
            render.material.color = Color.white;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.white;
        }
        if(PlayerPrefs.GetInt("Color") == 7)
        {        
            render.material.color = Color.black;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = Color.black;
        }        
        if(PlayerPrefs.GetInt("Color") == 0)
        {        
            render.material.color = def;
            PS = Particles.GetComponent<ParticleSystem>().main;
            PS.startColor = def;
        }
    }

}
