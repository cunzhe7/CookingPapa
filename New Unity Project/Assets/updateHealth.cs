using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateHealth : MonoBehaviour
{
    GameObject manager;
    BroccoliManager broc;
    float boss_health;
    GameObject Player;
    public AudioClip addhp;
    public AudioClip minushp;
    AudioSource aud;
    // Use this for initialization
    void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
        Player = GameObject.Find("FPSController");
        manager = GameObject.Find("GameManager");
        broc = manager.GetComponent<BroccoliManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "BigBoss")
        {
            Debug.Log(Vector3.Distance(gameObject.transform.position, Player.transform.position));
            if (Vector3.Distance(gameObject.transform.position, Player.transform.position) < 40)
            {
                broc.audio.Stop();
                if(!gameObject.GetComponent<AudioSource>().isPlaying)
                    gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
    void OnTriggerEnter()
    {
        Debug.Log("Player hit");
        
        GameObject txt = GameObject.Find("HealthNum");
        aud.PlayOneShot(addhp);
        txt.GetComponent<UnityEngine.UI.Text>().text = (float.Parse(txt.GetComponent<UnityEngine.UI.Text>().text) + 5.0f).ToString();

    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "ballPrefab(Clone)")
        {
            GameObject txt = GameObject.Find("HealthNum");
            float score = col.relativeVelocity.magnitude;
            boss_health = float.Parse(txt.GetComponent<UnityEngine.UI.Text>().text);
            Debug.Log(score);
            Destroy(col.gameObject);
            aud.PlayOneShot(minushp);
            if (score < 5.0f)
            {
                if (boss_health > 10f)
                    txt.GetComponent<UnityEngine.UI.Text>().text = (boss_health - 10.0f).ToString();
                else
                {
                    txt.GetComponent<UnityEngine.UI.Text>().text = "0";
                    broc.defeated = true;
                }
            }
            if (score > 5.0f)
            {
                if (boss_health > 20f)
                    txt.GetComponent<UnityEngine.UI.Text>().text = (boss_health - 20.0f).ToString();
                else
                {
                    txt.GetComponent<UnityEngine.UI.Text>().text = "0";
                    broc.defeated = true;
                }
            }
        }
    }

}
