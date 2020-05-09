using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasoningPick : MonoBehaviour
{

    private Canvas UI;
    private GameObject Manager;
    private YardManager ManagerScript;
    private GameObject instruction;
    Component[] ss;
    
    void Start()
    {
        ss = GetComponentsInChildren<Transform>();
        Manager = GameObject.Find("GameManager");
        ManagerScript = Manager.GetComponent<YardManager>();
        UI = FindObjectOfType<Canvas>();
        instruction = GameObject.Find("OP");
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider Player)
    {
        UI.GetComponentInChildren<Text>().fontSize = 20;
        UI.GetComponentInChildren<Text>().text = "";
        if (Player.gameObject.name == "FPSController")
        {

            for(int k = 1; k < ss.Length; k++)
            {
                if(ss[k].gameObject.active)
                    UI.GetComponentInChildren<Text>().text += "Press " + k + " to pick " + ss[k].gameObject.name + "\n";
            }
        }

        for (int k = 1; k < ss.Length; ++k)
        {
            if (Input.GetKeyDown("" + k))
            {
                if (ss[k].gameObject.active)
                {
                    instruction.GetComponent<Text>().text = "Picked up " + ss[k].gameObject.name;
                    ss[k].gameObject.SetActive(false);
                    if (k == 5 || k == 6)
                    {
                        ManagerScript.items++;
                        instruction.GetComponent<Text>().text += "\nThat's one of the seasoning on the Recipe!";
                    }
                    else
                    {
                        ManagerScript.player_health -= 0.05f;
                        instruction.GetComponent<Text>().text += "\n You don't have to use it \n But if you really like it, you can use 5 health to add it";
                    }
                }
            }
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        UI.GetComponentInChildren<Text>().fontSize = 40;
        UI.GetComponentInChildren<Text>().text = "";
        instruction.GetComponent<Text>().text = "";
    }
}
