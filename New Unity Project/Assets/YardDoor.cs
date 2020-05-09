using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YardDoor : MonoBehaviour {
    GameObject yard;
    public GameObject kitchen;
    GameObject UI;
    private YardManager ManagerScript;
    GameObject OP;
    // Use this for initialization
    void Start () {
        UI = GameObject.Find("Canvas");
        yard = GameObject.Find("Yard_all");
        OP = GameObject.Find("OP");
        ManagerScript = GameObject.Find("GameManager").GetComponent<YardManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider Player)
    {
        // This can be use to disable the prefabs
        OP.GetComponent<Text>().text = "Press F to go kitchen";
        if (Input.GetKey("f"))
        {
            //StartCoroutine(LoadScene(Player));
            kitchen.SetActive(true);
            yard.SetActive(false);
            ManagerScript.handWashed = false;
            UI.GetComponentInChildren<Text>().text = "";
            OP.GetComponent<Text>().text = "";
        }
    }

    private void OnTriggerExit(Collider Player)
    {
        OP.GetComponent<Text>().text = "";
    }
}
