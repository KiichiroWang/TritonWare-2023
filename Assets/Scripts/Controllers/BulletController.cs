using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            Damage = 5;
        }
        if(t == 2)
        {
            Speed = -300;
            Type = 2;
            Damage = 25;
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
