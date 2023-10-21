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
            //Creates bullet
            Instantiate(bullet, shootRingPos.position, Quaternion.identity);

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
}
