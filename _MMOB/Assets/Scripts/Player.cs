using System;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Transform bomb;
    public float speed = 2;
    public int countOfBombs = 1;
    public int powerOfBomb = 1;
    private Transform _t;
    private int[] position;
    // Use this for initialization
    private void Start()
    {
        _t = transform;
        position = new int[2];
        Vector3 v = new Vector3((float) Math.Truncate(_t.position.x), (float) Math.Truncate(_t.position.y),
                                (float) Math.Truncate(_t.position.z)); //Position of player
        position[0] = (int) v.x;
        position[1] = (int) v.z;
        Debug.Log("PlayerPosition[" + v.x + "," + v.z + "]");
        if (World.Map[(int) v.x, (int) v.z] == 3) //If player are placed on bomb
            World.Map[(int) v.x, (int) v.z] = 5; 
        else if (World.Map[(int)v.x, (int)v.z] == 0) //If nothing
        {
            World.Map[(int) v.x, (int) v.z] = 4;
        }
        Debug.Log("Initialized player: " + World.Map[(int)v.x, (int)v.z]);
        World.Players[0] = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3((float)Math.Truncate(_t.position.x), (float)Math.Truncate(_t.position.y),
                                  (float)Math.Truncate(_t.position.z));
        if (position[0] > v.x || position[0] < v.x || 
            position[1] > v.z || position[1] < v.z) //if player went to another tile
        {
            //Put player into new tile:
            if (World.Map[(int)v.x, (int)v.z] == 3)
                World.Map[(int)v.x, (int)v.z] = 5; 
            else if (World.Map[(int)v.x, (int)v.z] == 0)
                World.Map[(int)v.x, (int)v.z] = 4;
            //Remove player from old tile:
            if (World.Map[position[0], position[1]] == 5) 
                World.Map[position[0], position[1]] = 3;
            else if (World.Map[position[0], position[1]] == 4)
                World.Map[position[0], position[1]] = 0;
            //Remember player position:
            position[0] = (int)v.x;
            position[1] = (int)v.z;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, _t.position, Quaternion.identity);
            Bomb b = bomb.GetComponent<Bomb>();
            b.power = powerOfBomb;
        }
    }
}