using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int type;
    public Bullet bullet;
    public Rigidbody2D rb;
    public GameObject playerObj;
    public bulletHead bulletHead;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        bullet = new Bullet(type);
        rb = GetComponent<Rigidbody2D>();
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
        if (bullet.Type == 1)
        {
            rb.velocity = new Vector2(bullet.Speed, 0);
        }
        else if(bullet.Type == 2)
        {
            rb.velocity = new Vector2(bullet.Speed, ((playerObj.transform.position.y - transform.position.y) / (playerObj.transform.position.x - transform.position.x) * bullet.Speed) + Random.Range(-0.35f, 0.35f) * bullet.Speed);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(bullet.Type == 1)
        {
            if(collision.gameObject.name == "bulletHead")
            {
                bulletHead.Health -= bullet.Damage;
                StartCoroutine(death());
            }
            //else if() other heads
        }
        else if(bullet.Type == 2)
        {
            if (collision.gameObject.name == "Player")
            {
                player.Health -= bullet.Damage;
                StartCoroutine(death());
            }
        }
    }

    public IEnumerator death()
    {
        rb.velocity = new Vector2(0, 0);
        this.GetComponent<SpriteRenderer>().enabled = false;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        yield return new WaitForSeconds(1);
        GameObject.Destroy(this.gameObject);
    }
}
