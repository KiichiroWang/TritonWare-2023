using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHeadScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public spawnerHead spawnerHead;
    public SpriteRenderer rend;

    //state flags, controls when waves can spawn
    public bool open;
    public bool unlocked;

    //array to keep track of whether all 3 ranged enemies are dead, so a new wave can be spawned
    public bool[] spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawnerHead = GameObject.Find("BossController").GetComponent<BossController>().spawnerHead;
        rend = GetComponent<SpriteRenderer>();
        open = true;
        unlocked = true;
        spawned = new bool[3];
        spawned[0] = false;
        spawned[1] = false;
        spawned[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn rates for different levels
        float rn = Random.Range(0, 100) / 100f;
        if (spawnerHead.Level == 1)
        {
            if (rn < (spawnerHead.spawnRate * Time.deltaTime) && open)
            {
                StartCoroutine(spawn(enemy));
            }
        }
        else if (spawnerHead.Level == 2)
        {
            if(open && !spawned[0] && !spawned[1] && !spawned[2])
            {
                unlocked = true;
            }
            if (rn < (spawnerHead.spawnRate * 1.5f * Time.deltaTime) && open && unlocked)
            {
                unlocked = false;
                StartCoroutine(spawn(enemy2));
            }
        }
        else if(spawnerHead.Level == 3)
        {
            if (open && !spawned[0] && !spawned[1] && !spawned[2])
            {
                unlocked = true;
            }
            if (rn < (spawnerHead.spawnRate * 1.3f * Time.deltaTime) && open && unlocked)
            {
                unlocked = false;
                StartCoroutine(spawn(enemy2));
            }
        }
    }

    //spawns a new enemy wave, with 3 second cooldown afterward before another wave can spawn
    public IEnumerator spawn(GameObject enemy)
    {
        open = false;
        //spawning animation, sound, idk
        yield return new WaitForSeconds(1.5f);
        GameObject inimigo = Instantiate(enemy, transform.position - new Vector3(rend.bounds.extents.x * 1.5f, -100, 0), Quaternion.identity);
        inimigo.GetComponent<EnemyScript>().position = 1;
        GameObject inimigo2 = Instantiate(enemy, transform.position - new Vector3(rend.bounds.extents.x * 1.5f, 0, 0), Quaternion.identity);
        inimigo2.GetComponent<EnemyScript>().position = 2;
        GameObject inimigo3 = Instantiate(enemy, transform.position - new Vector3(rend.bounds.extents.x * 1.5f, 100, 0), Quaternion.identity);
        inimigo3.GetComponent<EnemyScript>().position = 3;
        if(enemy.GetComponent<EnemyScript>().type == 2)
        {
            spawned[0] = true;
            spawned[1] = true;
            spawned[2] = true;
        }
        yield return new WaitForSeconds(3);
        open = true;
    }
}
