using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance { get; set; }
    public bool popup;
    public int level;

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
    }
}
