using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawnScript : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer rend;
    public bool cooldown;
    public Transform shootRingPos;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Space) && !cooldown)
        {
            cooldown = true;
            Instantiate(bullet, transform.position + new Vector3(rend.bounds.extents.x*1.5f, 0, 0), Quaternion.identity);
            StartCoroutine(cooldownTimer());
        }

        // Editing Shooting Code - Kiichi (just making it so u hold and fire)
        //(Sumukh - I switched back to the old version because spawning 60 bullets per second made the game too easy, imo there should be a cooldown)
        /*if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, shootRingPos.position, Quaternion.identity);
        }*/
    }

    public IEnumerator cooldownTimer()
    {
        yield return new WaitForSeconds(0.13f);
        cooldown = false;
    }
}
