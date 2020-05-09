using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondHotPlate : MonoBehaviour
{
    Text time;
    private GameObject Manager;
    private BroccoliManager ManagerScript;
    bool clicked = false;
    GameObject instruction;
    AudioSource frying;


    // Use this for initialization
    void Start()
    {
        frying = gameObject.GetComponent<AudioSource>();
        Manager = GameObject.Find("GameManager");
        ManagerScript = Manager.GetComponent<BroccoliManager>();
        time = GameObject.Find("Time").GetComponent<Text>();
        instruction = GameObject.Find("OP");
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerScript.cookMode && clicked)
        {
            ManagerScript.timecount += Time.deltaTime;
            time.text = "Time: " + ManagerScript.timecount.ToString("0.00");
        }
        else
        {
            frying.Stop();
            clicked = false;
            time.text = "";
        }
    }

    private void OnMouseDown()
    {
        if (!clicked)
        {
            frying.Play();
            clicked = true;
            ManagerScript.timecount = 0.0f;
            instruction.GetComponent<Text>().text = "Remember what you learned from recipe!";
        }
    }
}
