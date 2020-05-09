using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaucetScript : MonoBehaviour
{
    private GameObject Todo;
    private GameObject Manager;
    private YardManager ManagerScript;
    private GameObject instruction;
    int washHandCounter;
    ParticleSystem water;
    private AudioSource waterSound;
    // Use this for initialization
    void Start()
    {
        waterSound = gameObject.GetComponent<AudioSource>();
        water = GetComponent<ParticleSystem>();
        washHandCounter = 0;
        Manager = GameObject.Find("GameManager");
        ManagerScript = Manager.GetComponent<YardManager>();
        Todo = GameObject.Find("TODO");
        instruction = GameObject.Find("OP");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider Player)
    {
        if (Player.gameObject.name == "FPSController")
        {
            instruction.GetComponent<Text>().text = "Left click to wash hand!";
            if (Input.GetMouseButtonDown(0))
            {
                if (!waterSound.isPlaying)
                {
                    waterSound.Play();
                }
                washHandCounter++;
                water.Play();
            }
            if (washHandCounter == 0)
            {
                Todo.GetComponent<Text>().text = "Please wash your hand before start cooking!";
            }
            else if (washHandCounter <= 7)
            {
                Todo.GetComponent<Text>().text = "Please wash your hand longer!";
            }
            else
            {
                Todo.GetComponent<Text>().text = "Finished washing!";
                ManagerScript.handWashed = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (waterSound.isPlaying)
            waterSound.Stop();
        washHandCounter = 0;
        water.Stop();
        if (ManagerScript.handWashed)
        {
            Todo.GetComponent<Text>().text = "Your hand is washed!";
        }
        else
        {
            Todo.GetComponent<Text>().text = "Your hand is not washed yet!";
        }
    }
}
