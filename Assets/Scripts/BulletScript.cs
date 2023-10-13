using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int type;
    Bullet bullet;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        bullet = new Bullet(type);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bullet.Speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
