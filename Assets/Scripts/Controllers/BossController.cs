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
        //set flags
    }
}

public class spawnerHead : Head
{
    //flags
    public spawnerHead(float h, int lvl) : base(h, lvl)
    {

    }
    override
    public void levelUp()
    {
        Level++;
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
        //set flags
    }
}
public class BossController : MonoBehaviour
{
    public bulletHead bulletHead;
    public spawnerHead spawnerHead;
    public fireHead fireHead;
    // Start is called before the first frame update
    void Start()
    {
        bulletHead = new bulletHead(100, 1);
        spawnerHead = new spawnerHead(100, 1);
        fireHead = new fireHead(100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}