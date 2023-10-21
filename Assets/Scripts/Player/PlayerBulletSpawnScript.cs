using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawnScript : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer rend;
    public Transform shootRingPos;

    [Space(20)]
    public float shootingCooldownTime;
    private bool cooldown;

    public bool poweredUp = false;
    public float verticalOffset;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cooldown = false;
    }


    void Update()
    {
        // Player Shooting
        if(Input.GetKey(KeyCode.Space) && !cooldown)
        {
            // Power Up
            if (poweredUp)
            {
                PoweredUpShooting();
            }
            else
            {
                //Creates bullet
                Instantiate(bullet, shootRingPos.position, Quaternion.identity);
            }

            // Audio
            SoundManager.Instance.Play("PlayerShoot");

            // Cooldown between shots
            cooldown = true;
            StartCoroutine(cooldownTimer());
        }
    }

    public IEnumerator cooldownTimer()
    {
        yield return new WaitForSeconds(shootingCooldownTime);
        cooldown = false;
    }

    private void PoweredUpShooting()
    {
        // Spawns 3 
        Instantiate(bullet, (Vector2)shootRingPos.position + new Vector2(0, verticalOffset), Quaternion.identity);
        Instantiate(bullet, shootRingPos.position, Quaternion.identity);
        Instantiate(bullet, (Vector2)shootRingPos.position + new Vector2(0, -verticalOffset), Quaternion.identity);
    }
}
