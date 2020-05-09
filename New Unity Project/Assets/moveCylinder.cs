using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCylinder : MonoBehaviour
{
    GameObject manager;
    BroccoliManager broc;
    float boss_health;
    bool playerfound = false;
    // Use this for initialization
    float timetotal = 0;
    void Start()
    {
        manager = GameObject.Find("GameManager");
        broc = manager.GetComponent<BroccoliManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject toMove = gameObject;
        if (toMove != null)
        {
            GameObject fps_player_obj = GameObject.Find("FPSController");

            float distance = (fps_player_obj.transform.position - toMove.transform.position).magnitude;
            if (distance < 40.0f)
            {
                playerfound = true;
                Vector3 original = toMove.transform.position;
                if(playerfound)
                    timetotal += Time.deltaTime;
                Vector3 temp = new Vector3();
                float step = 1.0f * Time.deltaTime;
                
                step *= Random.Range(0.1f, 0.2f) * timetotal;
                if(step > 2f)
                {
                    step /= Random.Range(0.1f, 0.2f) * timetotal;
                }
                temp = Vector3.MoveTowards(original, fps_player_obj.transform.position, step);

                //For some reason the ball's kept moving upwards. So I decided to just set the ball's 
                //  new location to a constant height of 1.0

                temp.y = 1f;
                toMove.transform.position = temp;
            }

            GameObject txt = GameObject.Find("HealthNum");
            if (float.Parse(txt.GetComponent<UnityEngine.UI.Text>().text) <= 0)
            {
                Destroy(GameObject.Find("BigBoss"));
            }
        }
    }
    void OnTriggerEnter()
    {
        Debug.Log("Player hit");
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
            if (score < 5.0f)
            {
                if(boss_health>10f)
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
