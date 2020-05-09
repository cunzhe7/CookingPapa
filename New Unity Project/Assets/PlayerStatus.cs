using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public static PlayerStatus Instance;
    internal int items;


    private void Awake()
    {
        //items = 0;
        //if (Instance == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        //    Instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
