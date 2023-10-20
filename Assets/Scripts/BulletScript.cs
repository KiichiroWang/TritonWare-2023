using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    public int type;
    public Bullet bullet;
    public Rigidbody2D rb;
    public GameObject playerObj;
    public bulletHead bulletHead;
    public spawnerHead spawnerHead;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        bullet = new Bullet(type);
        rb = GetComponent<Rigidbody2D>();
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        spawnerHead = GameObject.Find("BossController").GetComponent<BossController>().spawnerHead;
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
            if (collision.gameObject.tag == "Enemy")
            {
                StartCoroutine(death());
                StartCoroutine(collision.gameObject.GetComponent<EnemyScript>().kill()); //set into coroutine with some animation
            }
            if (collision.gameObject.name == "Shooter")
            {
                bulletHead.Health -= bullet.Damage;
                StartCoroutine(death());
                if(bulletHead.Health <= 0)
                {
                    bulletHead.Level = 0;
                    GameObject.Find("Shooter").SetActive(false); //set into coroutine with some animation
                    GameObject.Find("ShooterHealth").SetActive(false);
                    GameControllerScript.Instance.levelUp();
                }
            }
            if (collision.gameObject.name == "Spawner")
            {
                spawnerHead.Health -= bullet.Damage;
                StartCoroutine(death());
                if (spawnerHead.Health <= 0)
                {
                    spawnerHead.Level = 0;
                    GameObject.Find("Spawner").SetActive(false); //set into coroutine with some animation
                    GameObject.Find("SpawnerHealth").SetActive(false);
                    GameControllerScript.Instance.levelUp();
                }
            }

            //else if() other heads
        }
        else if(bullet.Type == 2)
        {
            if (collision.gameObject.name == "Player")
            {
                player.Health -= bullet.Damage;
                StartCoroutine(death());
                if(player.Health <= 0)
                {
                    StartCoroutine(restartLevel());
                }
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

    public IEnumerator restartLevel()
    {
        //sound effect perhaps
        yield return new WaitForSeconds(0.5f);
        if(GameControllerScript.Instance.level > 1)
        {
            GameControllerScript.Instance.popup = true;
        }
        GameControllerScript.Instance.level = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
