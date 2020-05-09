using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integredients2 : MonoBehaviour
{

    Vector3 mouse_position;
    Vector3 new_point;
    BroccoliManager ManagerScript;
    Camera CookingCam;
    bool hold = false;
    // Use this for initialization
    void Start()
    {
        ManagerScript = GameObject.Find("GameManager").GetComponent<BroccoliManager>();
        CookingCam = GameObject.Find("Cooking_Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerScript.cookMode && hold)
        {
            new_point = CookingCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1));
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new_point, 0.1f);
        }
    }

    private void OnMouseDown()
    {
        if (!hold)
        {
            hold = true;
            ManagerScript.onHold = gameObject.name;
        }
        else
        {
            if (gameObject.name != "cookingSpatula")
                gameObject.SetActive(false);
            else
                Destroy(gameObject, 20f - ManagerScript.timecount);
        }
    }
}
