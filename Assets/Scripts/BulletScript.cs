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
    public fireHead fireHead;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");

        //create a bullet object with the type that's provided in inspector
        bullet = new Bullet(type);

        rb = GetComponent<Rigidbody2D>();
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        spawnerHead = GameObject.Find("BossController").GetComponent<BossController>().spawnerHead;
        fireHead = GameObject.Find("BossController").GetComponent<BossController>().fireHead;
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;

        /*set bullet velocity based on bullet type (1 = player bullet, 2 = enemy bullet, 3 = enemy fireball). Enemy bullets are aimed generally
         * toward the player, with some randomness*/
        if (bullet.Type == 1)
        {
            rb.velocity = new Vector2(bullet.Speed, 0);
        }
        else if(bullet.Type == 2)
        {
            rb.velocity = new Vector2(bullet.Speed, ((playerObj.transform.position.y - transform.position.y) / (playerObj.transform.position.x - transform.position.x) * bullet.Speed) + Random.Range(-0.35f, 0.35f) * bullet.Speed);
        }
        else if (bullet.Type == 3)
        {
            rb.velocity = new Vector2(bullet.Speed, ((playerObj.transform.position.y - transform.position.y) / (playerObj.transform.position.x - transform.position.x) * bullet.Speed) + Random.Range(-0.2f, 0.2f) * bullet.Speed);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*Collision Detection, pretty self explanatory.*/
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
                    try
                    {
                        bulletHead.Level = 0;
                        GameObject.Find("ShooterHealth").SetActive(false);
                        GameObject.Find("Shooter").SetActive(false); //set into coroutine with some animation
                        GameControllerScript.Instance.levelUp();
                        //Debug.Log("leveled up");
                    }
                    catch(System.Exception e)
                    {
                        
                    }
                    
                }
            }
            if (collision.gameObject.name == "Spawner")
            {
                spawnerHead.Health -= bullet.Damage;
                StartCoroutine(death());
                if (spawnerHead.Health <= 0)
                {
                    try
                    {     
                        spawnerHead.Level = 0;
                        GameObject.Find("SpawnerHealth").SetActive(false);
                        GameObject.Find("Spawner").SetActive(false); //set into coroutine with some animation                     
                        GameControllerScript.Instance.levelUp();
                    }
                    catch (System.Exception e)
                    {

                    }
                    
                }
            }
            if (collision.gameObject.name == "Flame")
            {
                fireHead.Health -= bullet.Damage;
                StartCoroutine(death());
                if (fireHead.Health <= 0)
                {
                    try
                    {
                        fireHead.Level = 0;
                        GameObject.Find("FireHealth").SetActive(false);
                        GameObject.Find("Flame").SetActive(false); //set into coroutine with some animation                     
                        GameControllerScript.Instance.levelUp();
                    }
                    catch (System.Exception e)
                    {

                    }

                }
            }

        }
        else if(bullet.Type == 2 || bullet.Type == 3)
        {
            if (collision.gameObject.name == "Player")
            {
                try
                {
                    player.Health -= bullet.Damage;
                    StartCoroutine(death());
                    if (player.Health <= 0)
                    {
                        StartCoroutine(restartLevel());
                    }
                }
                catch (System.Exception e)
                {

                }
            }
        }
    }
    /*destroys a bullet after allowing particles to die*/
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
