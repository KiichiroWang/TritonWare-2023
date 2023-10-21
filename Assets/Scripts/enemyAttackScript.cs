using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script is attached to the CHILD of an enemy, an empty GameObject with a trigger collider that can detect collision with the player.
 */
public class enemyAttackScript : MonoBehaviour
{
    public Player player;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControllerScript>().player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player.Health -= damage;
            StartCoroutine(gameObject.transform.parent.gameObject.GetComponent<EnemyScript>().kill());
            if (player.Health <= 0)
            {
                //StartCoroutine(restartLevel());
                playerDeath();
            }
        }
    }

    public IEnumerator restartLevel()
    {
        //sound effect perhaps
        yield return new WaitForSeconds(0.5f);
        if (GameControllerScript.Instance.level > 1)
        {
            GameControllerScript.Instance.popup = true;
        }
        GameControllerScript.Instance.level = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void playerDeath()
    {
        // hmm i hate gameobject.find but prob best method here :/
        GameObject.Find("DeathScreenParent").transform.GetChild(0).gameObject.SetActive(true);
        SoundManager.Instance.Play("Death");
        Time.timeScale = 0;

    }
}
