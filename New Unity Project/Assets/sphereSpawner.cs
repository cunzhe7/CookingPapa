using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject clone = Instantiate(ballPrefab);
            clone.tag = "Respawn";
            Destroy(clone, 7);
        }
        if (GameObject.Find("SoccerSphere") == null && GameObject.Find("cubePrefab(Clone)") == null && GameObject.Find("ballPrefab(Clone)") == null)
        {
            GameObject clone = Instantiate(ballPrefab);
            clone.tag = "Respawn";
            Destroy(clone, 7);
        }
    }
}
