using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.IO.IsolatedStorage;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Kod za Respawn Tokena #T
    public Rigidbody rb;
    //public float MovSpeed; //faktor ubrzanja
    public float MaxSpeed = 5f;
    public Vector3 input; //Modifier za brzinu,krece se od -1 do 1 i raste duljinom drzanja tipki(strelica)Horizontal-lijeva i desna strelica
                           //zato dolje staljvamo Horizontal i Vertical(One su vec kreirane osi),Modifier se mnozi sa max brzinom koja ce bit MovSpeed
    public GameObject DeathParticles;
    // private double timer = 0d;
    public GameManager GM;
    public AudioClip[] AudioClip;
    private AudioSource au;
    public Transform Parent;
    //Respawn Time Delay Counter-#RTDC
    private float RTDC;
    private bool RB; //Respawn Bool
    //Cilj Transparency
    private float scale;
    //Ghost
    private Collider[] Enemy;
    public int NumOfEnemy,NOC;//NOC - Number Of Colliders
    private bool G,Activ;
    private float timer;
    public Image ButtonUpgradeImage;
    //Tekst upozorenja nedovoljno tokena
    public GameObject UpozorenjeNeDovoljnoTokena;
    private GameObject UpozorenjeNeDovoljnoTokenaObject;
    public bool tekst;
    //playerspawn
    public GameObject StartObject;
    public Transform[] Checkpoint;
    private Vector3 Spawn;
    //Restart level by death
    public bool RLBD;
    //Reset tokena ON/OFF
    public bool ResetTokena;

    void Start()
    {
        if(PlayerPrefs.GetInt("GhostUpgrade") == 0)
        {
            ButtonUpgradeImage.fillAmount = 1;
        }
        Enemy = new Collider[NumOfEnemy];
        timer = 0f;
        G = false;
        RB = false;
        RTDC = 0;
        //Time.timeScale = 1f;
        au = GetComponent<AudioSource>();
        scale = (float)(0.9 - Mathf.Round(PlayerPrefs.GetInt("SmallCubeUpgrade"))/40);
        gameObject.transform.localScale = new Vector3(scale,scale,scale);

        tekst = true;
        Spawn = StartObject.transform.position;
        PlayerSpawn();
        
    }

    // Update is called once per frame
    //Drugaciji nacin - ovdje konkretno odredjujemo kolika je brzina,a dolje odredjujemo koliko je ubrzanje odnosno sila.
   /* void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = input * MovSpeed; //brzina je 3d vektor,input također i
    }
    */
    void Update()
    {
        if (RB == false && rb.position.y <= 0.21)
        {
            input = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical"));
            rb.velocity = input * (MaxSpeed + Mathf.Round(PlayerPrefs.GetInt("SpeedUpgrade")) / 8);
        }
        else if (RB == true)
        {
            RTDC += Time.deltaTime;
            if (RTDC >= 0.5)
            {
                RB = false;
                RTDC = 0;
            }
        }
    }
    void FixedUpdate()
    {


        if (transform.position.y < 0.0)
        {
            PlayerSpawn();
        }
        //Ghost:
        if(timer >= (float)PlayerPrefs.GetInt("GhostUpgrade")/2 && G)
        {
            GhostEnd();
            //timer = 0;
        }
        else if (G)
        {
            timer += Time.deltaTime;
            ButtonUpgradeImage.fillAmount = 2*timer/PlayerPrefs.GetInt("GhostUpgrade");
        }
    }
    void OnTriggerEnter(Collider other) 
    { 
        //Ghost Start
        if (other.transform.tag == "Enemy" && G) //mogu stavit jos PlayerPrefs.GetInt("GhostUpgrade") > 0
        {
            Collider GOC = gameObject.GetComponent<Collider>();
            Physics.IgnoreCollision(other,GOC,true);
            Enemy[NOC] = other;
            NOC++;
            Activ = true;
        }
        //Ghost End
        else if(other.transform.tag == "Enemy")
        {
            LevelCounter.Deaths++;
            GM.Deaths++;
            PlaySound(0,1);
            if(RLBD)
            {
                SceneManager.LoadScene(LevelCounter.Lvl);
                Time.timeScale = 1;
            }
            else
            {
                DeathCol();
            }

        }
        if (other.transform.tag == "Token")
        {
            PlaySound(1,1.2f);
            GM.AddToken(other.transform.position);
            Destroy(other.gameObject, 0.1f);
        }
           
        if(other.transform.tag == "Checkpoint")
        {
            Spawn = other.transform.position;
        }
    }

    void PlaySound(int clip, float volume)
    {
       au.PlayOneShot(AudioClip[clip],volume);
    }

    void DeathCol()
    {
            rb.velocity = new Vector3(0,0,0);
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            PlayerSpawn();
            RB = true;
        if (!ResetTokena)
        {
            for (int i = 0; i < GM.TokenCount; i++) // #T
            {
                Instantiate(GM.Token, GM.TokenSpawn[i], Quaternion.identity, Parent); // #T
            }
            GM.TokenCount = 0; // #T
        }
    }

    void OnTriggerStay(Collider other) 
    {
       /*  if(other.transform.tag == "Cilj")
        {
            timer = timer + Time.deltaTime;
        } */
        //if()
        if(other.transform.tag == "Cilj" /* && timer >= 1*/ && GM.TokenCount == GM.TotalLvlToken)
        {
            PlaySound(2,6f);
            Time.timeScale = 0;
            GM.CompleteLevel();
        }
        else if(other.transform.tag == "Cilj" && GM.TokenCount < GM.TotalLvlToken && tekst && (GM.CurrentLvl != 7 && GM.CurrentLvl != 8 && GM.CurrentLvl != 14 && GM.CurrentLvl != 16) && GM.DefaultCam.activeSelf)
        {
            UpozorenjeNeDovoljnoTokenaObject = Instantiate(UpozorenjeNeDovoljnoTokena, other.transform.position + new Vector3(0,5,0),UpozorenjeNeDovoljnoTokena.transform.rotation);
            tekst = false;
        }
        else if (other.transform.tag == "Cilj" && GM.TokenCount < GM.TotalLvlToken && tekst && (GM.CurrentLvl != 7 && GM.CurrentLvl != 8 && GM.CurrentLvl != 14 && GM.CurrentLvl != 16) && GM.TwoDCam.activeSelf)
        {
            UpozorenjeNeDovoljnoTokenaObject = Instantiate(UpozorenjeNeDovoljnoTokena, other.transform.position + new Vector3(0, 5, 0), Quaternion.Euler (90,0,0));
            tekst = false;
        }
        if (UpozorenjeNeDovoljnoTokenaObject != null && GM.TwoDCam.activeSelf)
        {
            UpozorenjeNeDovoljnoTokenaObject.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        else if (UpozorenjeNeDovoljnoTokenaObject != null && GM.DefaultCam.activeSelf)
        {
            UpozorenjeNeDovoljnoTokenaObject.transform.rotation = Quaternion.Euler(20,0,0);
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.transform.tag == "Start")
        {
            GameManager.StartBool = true;
        }
        if (other.transform.tag == "Cilj" && tekst == false)
        {
            Destroy(UpozorenjeNeDovoljnoTokenaObject);
            tekst = true;
        }
    }

     //Ghost
    public void GhostStart()
    {
        G = true;
    }
    
    void GhostEnd()
    {
        Collider GOC = gameObject.GetComponent<Collider>();
        G = false;
            if(Activ == true)
            {
                for(int i=0; i < NOC; i++)
                {
                    Physics.IgnoreCollision(Enemy[i],GOC,false);
                    Activ = false;
                }
            }
    }

    void PlayerSpawn()
    {
        rb.position = Spawn + new Vector3(0, (float)(scale/2 + 0.01), 0);
    }
}
