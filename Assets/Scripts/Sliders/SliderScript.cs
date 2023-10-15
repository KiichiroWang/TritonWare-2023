using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public int type; //assign in inspector
    public Player player;
    public bulletHead bulletHead;
    // Start is called before the first frame update
    void Start()
    {
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
    }

    // Update is called once per frame
    void Update()
    {
        if(type == 1)
        {
            gameObject.GetComponent<Slider>().value = player.Health / 100f;
        }
        else if(type == 2)
        {
            gameObject.GetComponent<Slider>().value = bulletHead.Health / 100f;
        }
    }
}