using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float Speed { get; set; }
    public float Health { get; set; }
    public int FireRate { get; set; }

    public Player(float s, float h, int f)
    {
        Speed = s;
        Health = h;
        FireRate = f;
    }

}
public class PlayerControllerScript : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player(400, 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
