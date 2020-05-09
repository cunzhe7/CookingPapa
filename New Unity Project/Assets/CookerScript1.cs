using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookerScript1 : MonoBehaviour {
    private Canvas UI;
    private GameObject Manager;
    private YardManager ManagerScript;
    private GameObject instruction;
    // Use this for initialization
    void Start () {
        Manager = GameObject.Find("GameManager");
        ManagerScript = Manager.GetComponent<YardManager>();
        UI = FindObjectOfType<Canvas>();
        instruction = GameObject.Find("OP");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider Player)
    {
        if (Player.gameObject.name == "FPSController")
        {
            if (ManagerScript.items < 2)
            {
                UI.GetComponentInChildren<Text>().text = "You don't have enough materials!";
                instruction.GetComponent<Text>().text = "Go find your ingredients!";
            }
            else if (ManagerScript.items < 4)
            {
                UI.GetComponentInChildren<Text>().text = "You don't have enough seasoning!";
                instruction.GetComponent<Text>().text = "Go find your seasoning!";
            }
            else if (!ManagerScript.handWashed)
            {
                UI.GetComponentInChildren<Text>().text = "Don't forget to wash your hand before you start cooking!";
                instruction.GetComponent<Text>().text = "Go wash your hand!";
            }
            else
            {
                UI.GetComponentInChildren<Text>().text = "start cooking!";
                instruction.GetComponent<Text>().text = "press F to enter cooking mode!";
                if (Input.GetKeyDown("f")){
                    UI.GetComponentInChildren<Text>().text = "Hit the hot plate to start!";
                    ManagerScript.cookMode = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UI.GetComponentInChildren<Text>().text = "";
        instruction.GetComponent<Text>().text = "";
    }
}
