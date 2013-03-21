using UnityEngine;
using Assets.Scripts;

public class World : MonoBehaviour
{
    public Object Wall;
    public Object Box;
    public Object Player;

    // Use this for initialization
    void Start()
    {
        /*var bc = GameObject.FindGameObjectsWithTag("Box");
        for (int i = 0; i < bc.Length; i++)
        {
            Assets.Scripts.Boxes.BoxPositions[i] = bc[i].transform;
            //Destroy(bc[i]);
        }*/
        //Boxes.Map.Initialize();
        //Level data:
        for (int i = 1; i < Boxes.Height; i++)
        {
            for (int j = 1; j < Boxes.Width; j++)
            {
                if (((i % 2 == 0) && (j % 2 == 0))) 
                    Boxes.Map[i, j] = 1;
                //if (((i % 2 == 0) && (j % 2 == 0)) || ((i % 2 == 1) && (j % 2 == 1))) 
            }
        }
        //Visualize level:
        for (int i = 0; i < Boxes.Height; i++)
        {
            for (int j = 0; j < Boxes.Width; j++)
            {
                if (i == 0 || j == 0 || i == 99 || j == 99)
                    Instantiate(Wall, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
                else if (Boxes.Map[i, j] == 1)
                    Instantiate(Wall, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
            }
        }
        //Create players:
        Instantiate(Player, new Vector3(1.5f, 1.5f, 1.5f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
