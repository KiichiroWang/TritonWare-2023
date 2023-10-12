using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal and vertical movement

        bool keyFlag = false;
        //Debug.Log("entered update");

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector2(-1f * player.Speed * 3f * Time.deltaTime, 0);
            keyFlag = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector2(1f * player.Speed * 3f * Time.deltaTime, 0);
            keyFlag = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector2(0, -1f * player.Speed * 3f * Time.deltaTime);
            keyFlag = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += new Vector2(0, 1f * player.Speed * 3f * Time.deltaTime);      
            keyFlag = true;
        }

        if(rb.velocity.magnitude > player.Speed)
        {
            rb.velocity *= (player.Speed / rb.velocity.magnitude);
        }

        if (!keyFlag)
        {
            rb.velocity += (-3f * rb.velocity * Time.deltaTime); 
        }


    }
}
