using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour {

    Button b1;
    Button b2;
    Button b3;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        b1 = GameObject.Find("B1").GetComponent<Button>();
        b2 = GameObject.Find("B2").GetComponent<Button>();
        b3 = GameObject.Find("B3").GetComponent<Button>();

        b1.onClick.AddListener(delegate { Start1(); });
        b2.onClick.AddListener(delegate { Start2(); });
        b3.onClick.AddListener(delegate { Instruction(); });

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            b1.gameObject.SetActive(true);
            b2.gameObject.SetActive(true);
            b3.gameObject.SetActive(true);
            panel.SetActive(false);
        }
	}


    void Start1()
    {
        SceneManager.LoadScene(0);
    }
    

    void Start2()
    {
        SceneManager.LoadScene(2);
    }

    void Instruction()
    {
        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(false);
        panel.SetActive(true);
    }
}
