using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wok : MonoBehaviour {
    YardManager ManagerScript;

    bool eggAdded = false;
    bool oilAdded = false;
    bool cheeseAdded = false;
    bool flipped = false;
    bool failed = false;
    public GameObject eggCooked;
    // Use this for initialization
    void Start () {
        ManagerScript = GameObject.Find("GameManager").GetComponent<YardManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ManagerScript.timecount >= 20 && ManagerScript.cookMode)
        {
            if (!eggAdded || !cheeseAdded || !oilAdded || !flipped)
                failed = true;
            else
            {
                ManagerScript.cookMode = false;
                ManagerScript.finished = true;
                ManagerScript.audio.PlayOneShot(ManagerScript.succ);
            }
        }
        if(failed)
        {
            ManagerScript.player_health -= 0.3f;
            ManagerScript.cookMode = false;
            failed = false;
            ManagerScript.audio.PlayOneShot(ManagerScript.fail);
        }
	}

    private void OnMouseDown()
    {
        if (ManagerScript.cookMode) {
            if (ManagerScript.timecount >= 0.01f)
            {
                if (ManagerScript.onHold == "bottleOil")
                {
                    oilAdded = true;
                }
                else if (ManagerScript.onHold == "egg")
                {
                    eggAdded = true;
                    if (oilAdded)
                    {
                        eggCooked.SetActive(true);
                    }
                    else
                    {
                        failed = true;
                    }
                }
                else if (ManagerScript.onHold == "cheese")
                {
                    cheeseAdded = true;
                    if (!eggAdded || !oilAdded)
                    {
                        failed = true;
                    }
                }
                if (ManagerScript.timecount >= 10)
                {
                    if (ManagerScript.onHold == "cookingSpatula")
                    {
                        flipped = true;
                        eggCooked.transform.Rotate(60, 0, 0);
                    }
                }
            }
        }
    }
}
