using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHeadScript : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer rend;
    public bulletHead bulletHead;
    // Start is called before the first frame update
    void Start()
    {
        bulletHead = GameObject.Find("BossController").GetComponent<BossController>().bulletHead;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float rn = Random.Range(0, 100)/100f;
        if(bulletHead.Level == 1)
        {
            if(rn < (0.25f * Time.deltaTime))
            {
                Instantiate(bullet, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
            }
        }
    }
}
