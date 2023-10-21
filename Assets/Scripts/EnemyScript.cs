using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int position;
    public Vector3 target;
    public Rigidbody2D rb;
    public bool update;
    public GameObject player;
    public float speed;
    public bool dead;
    public int type;
    public GameObject bullet;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        speed = 120;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        update = false;
        dead = false;

        //starts the dash to the center of the screen
        StartCoroutine(dash());

    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            if(type == 1)
            {
                if (dead)
                {
                    GameObject.Destroy(this.gameObject);
                }
                rb.velocity = (player.transform.position - transform.position);
                rb.velocity = speed * rb.velocity / rb.velocity.magnitude;
            }
            else if(type == 2)
            {
                if (dead)
                {
                    GameObject.Destroy(this.gameObject);
                }
                rb.velocity = new Vector2(0, 0);
                float rn = Random.Range(0f, 1f);
                if(GameControllerScript.Instance.level == 2)
                {
                    if (rn < (2f * Time.deltaTime))
                    {
                        Instantiate(bullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
                    }
                }
                else if (GameControllerScript.Instance.level == 3)
                {
                    if (rn < (4f * Time.deltaTime))
                    {
                        Instantiate(bullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
                    }
                }
                
            }
            
        }
    }

    /*
     * Controls the initial dash. It's slower for type 1 enemies (melee) and faster for type 2 (ranged). After the dash, the update method takes control.
     */
    public IEnumerator dash()
    {
        //There is a 1 second waiting period for melee enemies before the dash
        if(type == 1)
        {
            yield return new WaitForSeconds(1);
        }

        //position denotes whether the object is the top, middle, or bottom member of that wave
        if(position == 1)
        {
            //target = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * 1f / 4f, transform.position.z);
            target = new Vector3(0, 270, transform.position.z);
        }
        else if(position == 2)
        {
            //target = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * 2f / 4f, transform.position.z);
            target = new Vector3(0, 0, transform.position.z);
        }
        else if(position == 3)
        {
            //target = new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * 3f / 4f, transform.position.z);
            target = new Vector3(0, -270, transform.position.z);
        }

        //dash speed
        if(type == 1)
        {
            rb.velocity = target - transform.position;
            //Debug.Log(rb.velocity.x);
            yield return new WaitForSeconds(1);
        }
        else
        {
            rb.velocity = 2*(target - transform.position);
            //Debug.Log(rb.velocity.x);
            yield return new WaitForSeconds(0.5f);
        }
        update = true;

    }

    public IEnumerator kill()
    {
        //update the spawned array, which keeps track of when a wave is dead so it can spawn another one (only applies to ranged enemies)
        if(type == 2)
        {
            try
            {
                GameObject.Find("Spawner").GetComponent<SpawnerHeadScript>().spawned[position - 1] = false;
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        update = false;
        gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //some animation and sound effect here
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(this.gameObject);
        dead = true;
        update = true;
    }
}
