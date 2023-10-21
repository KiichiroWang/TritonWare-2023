using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Essentially just a bullet class with attributes about the bullet. Type 1 is a player bullet,
 * Type 2 is an enemy bullet, and Type 3 is a enemy "fireball" from the lower head
 * 
 */
public class Bullet
{
    public int Type { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public Bullet(int t)
    {
        if(t == 1)
        {
            Speed = 600;
            Type = 1;
            Damage = 3;
            // CHANGE THIS BACK TO 2
        }
        if(t == 2)
        {
            Speed = -300;
            Type = 2;
            Damage = 25;
        }
        if(t == 3)
        {
            Speed = -600;
            Type = 3;
            Damage = 40;
        }
    }
}
public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
