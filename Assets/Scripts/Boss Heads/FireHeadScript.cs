using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHeadScript : MonoBehaviour
{
    public GameObject flameBullet;
    public fireHead fireHead;

    private SpriteRenderer rend;

    void Start()
    {
        fireHead = GameObject.Find("BossController").GetComponent<BossController>().fireHead;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //determines spawn rates of projectiles at levels 1, 2, and 3 using rng
        float rn = Random.Range(0f, 1f);
        if (fireHead.Level == 1)
        {
            if (rn < (0.5f * Time.deltaTime))
            {
                //Debug.Log(rn);
                Instantiate(flameBullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
        }
        else if (fireHead.Level == 2)
        {
            if (rn < (1f * Time.deltaTime))
            {
                Instantiate(flameBullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
        }
        else if (fireHead.Level == 3)
        {
            if (rn < (3f * Time.deltaTime))
            {
                Instantiate(flameBullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
            //other stuff
        }
    }
}
