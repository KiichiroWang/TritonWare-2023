using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public int type; //assign in inspector
    public Player player;
    public bulletHead bulletHead;
    public spawnerHead spawnerHead;
    public fireHead fireHead;
    // Start is called before the first frame update
    void Start()
    {
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        spawnerHead = GameObject.Find("BossController").GetComponent<BossController>().spawnerHead;
        fireHead = GameObject.Find("BossController").GetComponent<BossController>().fireHead;
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
    }

    // Update is called once per frame
    void Update()
    {
        //this is all self-explanatory

        if(type == 1)
        {
            gameObject.GetComponent<Slider>().value = player.Health / 100f;
        }
        else if(type == 2)
        {
            gameObject.GetComponent<Slider>().value = bulletHead.Health / 100f;
        }
        else if(type == 3)
        {
            gameObject.GetComponent<Slider>().value = spawnerHead.Health / 100f;
        }
        else if(type == 4)
        {
            gameObject.GetComponent<Slider>().value = fireHead.Health / 100f;
        }
    }
}
