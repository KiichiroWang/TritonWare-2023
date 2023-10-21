using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance { get; set; }
    public bool popup;
    public int level;
    public GameObject winScreen;
    public GameObject levelUpScreen;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        popup = false;
        //winScreen = GameObject.Find("WinScreenParent").transform.GetChild(0).gameObject; // Just in case its lost on reset
        //levelUpScreen = GameObject.Find("LevelUpScreenParent").transform.GetChild(0).gameObject; // Just in case its lost on reset
    }

    private void OnLevelWasLoaded()
    {
        level = 1;
        popup = false;
       // winScreen = GameObject.Find("WinScreenParent").transform.GetChild(0).gameObject; // Just in case its lost on reset
       // levelUpScreen = GameObject.Find("LevelUpScreenParent").transform.GetChild(0).gameObject; // Just in case its lost on reset
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /**
     * Increases level and also levels up all of the boss heads.
     */
    public void levelUp()
    {
        level++;
        BossController bc = GameObject.Find("BossController").GetComponent<BossController>();
        Player player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
        bc.bulletHead.levelUp();
        bc.spawnerHead.levelUp();
        bc.fireHead.levelUp();
        player.Health = 100;

        if (!levelUpScreen.active)
        {
            levelUpScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Win()
    {
        if (!winScreen.active)
        {
            if (levelUpScreen.active)
            {
                levelUpScreen.SetActive(false);
            }
            SoundManager.Instance.Play("Win");
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // LEVEL UP GAINS
    public void BulletUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBulletSpawnScript>().poweredUp = true;
        Time.timeScale = 1;
        levelUpScreen.SetActive(false);
    }

    public void SpeedUp()
    {
        GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().IncreaseSpeed();
        Time.timeScale = 1;
        levelUpScreen.SetActive(false);
    }
}
