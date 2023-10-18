using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHeadScript : MonoBehaviour
{
    public GameObject enemy;
    public spawnerHead spawnerHead;
    public SpriteRenderer rend;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        spawnerHead = GameObject.Find("BossController").GetComponent<BossController>().spawnerHead;
        rend = GetComponent<SpriteRenderer>();
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        float rn = Random.Range(0, 100) / 100f;
        if (spawnerHead.Level == 1)
        {
            if (rn < (spawnerHead.spawnRate * Time.deltaTime) && open)
            {
                StartCoroutine(spawn());
            }
        }
    }

    public IEnumerator spawn()
    {
        open = false;
        //spawning animation, sound, idk
        yield return new WaitForSeconds(1.5f);
        GameObject inimigo = Instantiate(enemy, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, -100, 0), Quaternion.identity);
        inimigo.GetComponent<EnemyScript>().position = 1;
        GameObject inimigo2 = Instantiate(enemy, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 0, 0), Quaternion.identity);
        inimigo2.GetComponent<EnemyScript>().position = 2;
        GameObject inimigo3 = Instantiate(enemy, transform.position - new Vector3(rend.bounds.extents.x * 1.1f, 100, 0), Quaternion.identity);
        inimigo3.GetComponent<EnemyScript>().position = 3;
        yield return new WaitForSeconds(3);
        open = true;
    }
}
