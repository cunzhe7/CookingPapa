using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatTBPicked : MonoBehaviour {

    private Canvas UI;
    private GameObject Manager;
    private YardManager ManagerScript;
    private GameObject Player;
    private PlayerStatus PStatus;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("FPSController");
        Manager = GameObject.Find("GameManager");
        UI = FindObjectOfType<Canvas>();
        ManagerScript = Manager.GetComponent<YardManager>();
        PStatus = Player.GetComponent<PlayerStatus>();
    }

    private void Awake()
    { 
    }

    
    // Update is called once per frame
    void Update () {
        if (ManagerScript.load)
        {
            Player = GameObject.Find("FPSController");
            Manager = GameObject.Find("GameManager");
            UI = FindObjectOfType<Canvas>();
            ManagerScript = Manager.GetComponent<YardManager>();
            PStatus = Player.GetComponent<PlayerStatus>();
        }

        float distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (distance < 3)
        {
            if (!ManagerScript.searchMode)
            {
                // Handle the case that plyaer leave the range but UI still showing item is nearby
                UI.GetComponentInChildren<Text>().text = "You are around " + gameObject.name + "!\nPress F to enter searching mode";
                if (Input.GetKey("f"))
                {
                    ManagerScript.searchMode = true;
                    ManagerScript.player_health -= 0.05f;
                }
            }
        }
        // if the distance is larger than something, show stop showing that. 
    }

    private void OnMouseDown()
    {
        if (ManagerScript.searchMode)
        {
            UI.GetComponentInChildren<Text>().text = "Picked up " + gameObject.name;
            if (gameObject.name == "egg" || gameObject.name == "eggHalf")
            {
                ManagerScript.audio.PlayOneShot(ManagerScript.goodpick);
                ManagerScript.items++;
            }
            else
            {
                ManagerScript.audio.PlayOneShot(ManagerScript.badpick);
                UI.GetComponentInChildren<Text>().text += " but you don't really it";
            }
            Destroy(gameObject);
            ManagerScript.searchMode = false;
            if (ManagerScript.items == 2)
                UI.GetComponentInChildren<Text>().text = "Got all material, go back to kitchen and get seasonings!";
        }
    }
}
