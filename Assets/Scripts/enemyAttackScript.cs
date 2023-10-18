using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyAttackScript : MonoBehaviour
{
    public Player player;
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
            player.Health -= 45;
            StartCoroutine(gameObject.transform.parent.gameObject.GetComponent<EnemyScript>().kill());
            if (player.Health <= 0)
            {
                StartCoroutine(restartLevel());
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
}
