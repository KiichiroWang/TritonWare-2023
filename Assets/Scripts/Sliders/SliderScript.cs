using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public int type; //assign in inspector
    public float playerHealth;
    public float bossHealth;
    public Player player;
    public bulletHead bulletHead;
    public spawnerHead spawnerHead;
    public fireHead fireHead;

    void Start()
    {
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        spawnerHead = GameObject.Find("BossController").GetComponent<BossController>().spawnerHead;
        fireHead = GameObject.Find("BossController").GetComponent<BossController>().fireHead;
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
    }

    void Update()
    {
        //this is all self-explanatory

        if(type == 1)
        {
            gameObject.GetComponent<Slider>().value = player.Health / playerHealth;
        }
        else if(type == 2)
        {
            gameObject.GetComponent<Slider>().value = bulletHead.Health / bossHealth;
        }
        else if(type == 3)
        {
            gameObject.GetComponent<Slider>().value = spawnerHead.Health / bossHealth;
        }
        else if(type == 4)
        {
            gameObject.GetComponent<Slider>().value = fireHead.Health / bossHealth;
        }
    }
}
