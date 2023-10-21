using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHeadScript : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer rend;
    public bulletHead bulletHead;

    void Start()
    {
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //determines spawn rates of projectiles at levels 1, 2, and 3 using rng
        float rn = Random.Range(0f, 1f);
        if (bulletHead.Level == 1)
        {
            if(rn < (2.3f * Time.deltaTime))
            {
                Instantiate(bullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
        }
        else if (bulletHead.Level == 2)
        {
            if (rn < (3.5f * Time.deltaTime))
            {
                Instantiate(bullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
        }
        else if(bulletHead.Level == 3)
        {
            if (rn < (5.5f * Time.deltaTime))
            {
                Instantiate(bullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
            //other stuff
        }
    }
}
