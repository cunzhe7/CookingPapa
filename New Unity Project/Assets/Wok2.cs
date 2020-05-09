using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wok2 : MonoBehaviour
{
    BroccoliManager ManagerScript;

    bool meatAdded = false;
    bool brocAdded = false;
    bool failed = false;
    public GameObject eggCooked;
    public GameObject meat;
    public GameObject broc;
    // Use this for initialization
    void Start()
    {
        ManagerScript = GameObject.Find("GameManager").GetComponent<BroccoliManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerScript.timecount >= 10 && ManagerScript.cookMode)
        {
            if (!meatAdded || !brocAdded)
                failed = true;
            else
            {
                ManagerScript.cookMode = false;
                ManagerScript.finished = true;
                ManagerScript.audio.PlayOneShot(ManagerScript.successed);
            }
        }
        if (failed)
        {
            ManagerScript.audio.PlayOneShot(ManagerScript.failed);
            ManagerScript.player_health -= 0.3f;
            ManagerScript.cookMode = false;
            failed = false;
        }
    }

    private void OnMouseDown()
    {
        if (ManagerScript.cookMode)
        {
            if (ManagerScript.timecount >= 0.01f)
            {
                if (ManagerScript.onHold == "broccoli")
                {
                    brocAdded = true;
                    broc.SetActive(true);
                }
                else if (ManagerScript.onHold == "meatRaw")
                {
                    meatAdded = true;
                    meat.SetActive(true);
                }
            }
        }
    }
}
