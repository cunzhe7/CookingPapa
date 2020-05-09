using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YardManager : MonoBehaviour {

    public static YardManager Instance;
    private Canvas UI;
    private GameObject Player;
    internal bool picking = false;
    private PlayerStatus PStatus;
    internal float player_health;
    internal bool handWashed = false;
    internal bool searchMode = false;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController PControll;
    internal bool load = false;
    internal int items = 0;
    internal bool cookMode = false;
    internal bool died = false;
    private GameObject Cooking;
    public Camera cookingCamera;
    bool menuMode = false;
    GameObject health;
    public Button restart;
    private Text inst;
    public Button again;
    public Button menu;
    public Button resume;
    Text time;
    internal float timecount;
    internal string onHold;
    internal bool finished = false;
    public GameObject integ;
    public AudioClip goodpick;
    public AudioClip badpick;
    internal AudioSource audio;
    public AudioClip water;
    public AudioClip fail;
    public AudioClip succ;
    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        timecount = 0.0f;
        inst = GameObject.Find("OP").GetComponent<Text>();
        health = GameObject.Find("Handle");
        player_health = 1.0f;
        Cooking = GameObject.Find("Cooking_Camera");
        Player = GameObject.Find("FPSController");
        UI = FindObjectOfType<Canvas>();
        PStatus = Player.GetComponent<PlayerStatus>();
        PControll = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        restart.onClick.AddListener(delegate { Restart(); });
        again.onClick.AddListener(delegate { Restart(); });
        menu.onClick.AddListener(delegate { goMain(); });
        resume.onClick.AddListener(delegate { res(); });
        time = GameObject.Find("Time").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

        if (load)
        {
            Player = GameObject.Find("FPSController");
            UI = FindObjectOfType<Canvas>();
            PControll = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            load = false;
            return;
        }

        

        if (!searchMode && !died && !cookMode && !menuMode && !finished)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PControll.enabled = true;
            again.gameObject.SetActive(false);
            cookingCamera.gameObject.SetActive(false);
            Player.SetActive(true);
            menu.gameObject.SetActive(false);
            resume.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("space"))
        {
            searchMode = false;
        }

        if (Input.GetKeyDown("escape"))
        {
            menuMode = !menuMode;
        }

        if (searchMode)
        {
            UI.GetComponentInChildren<Text>().text = "Used 5 health to enter searching mode!\n prese space to exit if you can't find it";
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PControll.enabled = false;
        }
        else if (cookMode)
        {
            integ.SetActive(true);
            cookingCamera.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Player.SetActive(false);
            inst.text = "Press space to exit cooking mode";

            if (Input.GetKeyDown("space"))
            {
                cookMode = false;
                cookingCamera.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Player.SetActive(true);
            }
        }
        else if (menuMode)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PControll.enabled = false;
            resume.gameObject.SetActive(true);
            again.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
        }

        

        health.transform.localScale = new Vector3(player_health, 1f, 1f);

        if (Player.transform.position.y < -10 && player_health >= 0.01)
            player_health -= 0.1f;

        if (player_health < 0.01f)
        {
            player_health = 0f;
            died = true;
            PControll.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (died)
        {
            UI.GetComponentInChildren<Text>().text = "you died!";
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
        if (finished)
        {
            UI.GetComponentInChildren<Text>().text = "You just made the Omelet successfully!";
            inst.text = "Go to the Main menu to choose another stage or play again!";
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restart.gameObject.SetActive(false);
    }

    void goMain()
    {
        SceneManager.LoadScene(1);
    }

    void res()
    {
        menuMode = false;
    }
}
