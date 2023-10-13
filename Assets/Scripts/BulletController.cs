using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet
{
    public int Type { get; set; }
    public float Speed { get; set; }
    public Bullet(int t)
    {
        if(t == 1)
        {
            Speed = 600;
            Type = 1;
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
