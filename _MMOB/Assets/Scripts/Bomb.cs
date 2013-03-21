using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Transform _t;
    private Vector3 _v;
    public float time = 5;
    public int power = 1;
	// Use this for initialization
	void Start ()
	{
	    _t = transform;
        _v = new Vector3((float)Math.Truncate(_t.position.x), (float)Math.Truncate(_t.position.y),
                                  (float)Math.Truncate(_t.position.z));
        transform.position = new Vector3((float)Math.Truncate(_t.position.x) + 0.5f, (float)Math.Truncate(_t.position.y) + 0.5f,
                          (float)Math.Truncate(_t.position.z) + 0.5f); 
        //if (World.Map[(int)(_t.position.x - 0.5), (int)(_t.position.z - 0.5)] == 4) //If bomb
        World.Map[(int) _v.x, (int)_v.z] = 5;
        World.MapT[(int)_v.x, (int)_v.z] = this.gameObject;
        Debug.Log("Initialized bomb:" + World.Map[(int)_v.x, (int)_v.z]);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    time -= Time.deltaTime;
        if (time <= 0)
            Explode();
	}
    public void Explode()
    {
        for (int i = 0; i < power; i++)
        {
            //if (_t.position.x + i > Boxes.BoxPositions[0].position.x) Destroy(Boxes.BoxPositions[0].gameObject);
        }
        for (int i = 0; i <= power; i++)
        {
            Debug.Log("ExplosionPosition[" + ((int)_v.x + i) + "," + (int)_v.z + "]");
            Debug.Log("LocatedObject: " + World.Map[(int)_v.x + i, (int)_v.z]);

            if ((int)_v.x + i <= World.Height)
            {
                if (World.Map[(int) _v.x + i, (int) _v.z] == 2)//If Box
                {
                    World.Map[(int) _v.x + i, (int) _v.z] = 0;
                    Destroy(World.MapT[(int) _v.x + i, (int) _v.z]);
                    break;
                }
                if (World.Map[(int) _v.x + i, (int) _v.z] == 3) //If bomb
                {
                    if (i != 0)
                    {
                        (World.MapT[(int) _v.x + i, (int) _v.z] as GameObject).GetComponent<Bomb>().Explode();
                        break;
                    }
                }
                if (World.Map[(int) _v.x + i, (int) _v.z] == 4) //If player
                {
                    Destroy((World.Players[0] as GameObject));
                    World.Map[(int) _v.x + i, (int) _v.z] = 0;
                }
                if (World.Map[(int)_v.x + i, (int)_v.z] == 5) //If player
                {
                    if (i != 0)
                    {
                        (World.MapT[(int)_v.x + i, (int)_v.z] as GameObject).GetComponent<Bomb>().Explode();
                        break;
                    }
                    Destroy((World.Players[0] as GameObject));  
                    World.Map[(int)_v.x + i, (int)_v.z] = 0;
                }
            }
        }

        World.Map[(int)_v.x, (int)_v.z] = 0;
        Destroy(gameObject);

        /*for (int i = 0; i >= -power; i--)
        {
            if ((int)(_t.position.x - 0.5) + i >= 0)
            {
                if (World.Map[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] == 1 ||
                    World.Map[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] == 2) //If Wall or Box
                {
                    World.Map[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] = 0;
                    break;
                }
                if (World.Map[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] == 3) //If bomb
                {
                    (World.MapT[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] as GameObject).
                        GetComponent<Bomb>().Explode();
                }
                if (World.Map[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] == 4) //If player
                {
                    Destroy(World.Players[0]);
                    World.Map[(int) (_t.position.x - 0.5) + i, (int) (_t.position.z - 0.5)] = 0;
                }
            }
        }
        for (int i = 0; i <= power; i++)
        {
            if ((int)(_t.position.z - 0.5) + i <= World.Width)
            {
                if (World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 1 ||
                    World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 2) //If Wall or Box
                {
                    World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] = 0;
                    break;
                }
                if (World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 3) //If bomb
                {
                    (World.MapT[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] as GameObject).
                        GetComponent<Bomb>().Explode();
                }
                if (World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 4) //If player
                {
                    Destroy(World.Players[0]);
                    World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] = 0;
                }
            }
        }
        for (int i = 0; i >= -power; i--)
        {
            if ((int)(_t.position.z - 0.5) + i >= 0)
            {
                if (World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 1 ||
                    World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 2) //If Wall or Box
                {
                    World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] = 0;
                    break;
                }
                if (World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 3) //If bomb
                {
                    (World.MapT[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] as GameObject).
                        GetComponent<Bomb>().Explode();
                }
                if (World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] == 4) //If player
                {
                    Destroy(World.Players[0]);
                    World.Map[(int) (_t.position.x - 0.5), (int) (_t.position.z - 0.5) + i] = 0;
                }
            }
        }*/

    }
       
}
