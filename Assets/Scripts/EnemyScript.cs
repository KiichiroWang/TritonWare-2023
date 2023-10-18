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
    // Start is called before the first frame update
    void Start()
    {
        speed = 300;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        update = false;
        StartCoroutine(dash());
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            if (dead)
            {
                GameObject.Destroy(this.gameObject);
            }
            rb.velocity = (player.transform.position - transform.position);
            rb.velocity = speed * rb.velocity / rb.velocity.magnitude;
        }
    }

    public IEnumerator dash()
    {
        yield return new WaitForSeconds(1);
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

        rb.velocity = target - transform.position;
        Debug.Log(rb.velocity.x);
        yield return new WaitForSeconds(1);
        update = true;

    }

    public IEnumerator kill()
    {
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
