using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Head
{
    public float Health { get; set; }
    public int Level { get; set; }

    public Head(float h, int lvl)
    {
        Health = h;
        Level = lvl;
    }

    public abstract void levelUp();
}

public class bulletHead : Head
{
    //flags
    public bulletHead(float h, int lvl):base(h,lvl)
    {
        
    }
    override
    public void levelUp()
    {
        Level++;
        Health = 100;
        //set flags
    }
}

public class spawnerHead : Head
{
    //flags
    public float spawnRate { get; set; }
    public spawnerHead(float h, int lvl, float s) : base(h, lvl)
    {
        spawnRate = s;
    }
    override
    public void levelUp()
    {
        Level++;
        Health = 100;
        //set flags
    }
}

public class fireHead : Head
{
    //flags
    public fireHead(float h, int lvl) : base(h, lvl)
    {

    }
    override
    public void levelUp()
    {
        Level++;
        Health = 100;
        //set flags
    }
}
/**
 * Creates 3 objects (classes defined above) for the 3 boss heads. Was this totally necessary? No. But I had initially thought that they would be more different
 * than they ended up being. 
 */
public class BossController : MonoBehaviour
{
    public bulletHead bulletHead;
    public spawnerHead spawnerHead;
    public fireHead fireHead;

    void Start()
    {
        // Sets boss
        // Changing health
        bulletHead = new bulletHead(1000, 1);
        spawnerHead = new spawnerHead(1000, 1, 0.1f);
        fireHead = new fireHead(1000, 1);
    }

    void Update()
    {
        
    }
}
