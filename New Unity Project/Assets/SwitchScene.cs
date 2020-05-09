using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour {
    
    public GameObject OP;
    GameObject UI;
    private GameObject Manager;
    public GameObject yard;
    GameObject kitchen;
	// Use this for initialization
	void Start () {
        UI = GameObject.Find("Canvas");
        Manager = GameObject.Find("GameManager");
        kitchen = GameObject.Find("Kitchen_all");
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerStay(Collider Player)
    {
        // This can be use to disable the prefabs
        OP.GetComponent<Text>().text = "Press F to go backyard";
        if (Input.GetKey("f"))
        {
            //StartCoroutine(LoadScene(Player));
            yard.SetActive(true);
            kitchen.SetActive(false);
            OP.GetComponent<Text>().text = "";
        }
    }

    private void OnTriggerExit(Collider Player)
    {
        OP.GetComponent<Text>().text = "";
    }

    IEnumerator LoadScene(Collider Player)
    {
        //DontDestroyOnLoad(OP.transform.GetComponentInParent<Canvas>().gameObject);
        //Destroy(Player.gameObject);
        //Destroy(UI);
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);
        //Manager.GetComponent<YardManager>().load = true;
        //Scene nextScene = SceneManager.GetSceneAt(1);
        //SceneManager.MoveGameObjectToScene(Manager, nextScene);
        ////SceneManager.MoveGameObjectToScene(OP.transform.GetComponentInParent<Canvas>().gameObject, nextScene);
        //yield return null;
        //SceneManager.UnloadSceneAsync(0);
        
        yield return null;
    }


}
