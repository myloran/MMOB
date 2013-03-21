using UnityEngine;

public class World : MonoBehaviour
{
    public Object Wall;
    public Object Box;
    public Object Player;

    public static int CountOfplayers = 10;
    public static int Height = 100;
    public static int Width = 100;
    public static int[,] Map = new int[Height, Width];
    public static Object[,] MapT = new Object[Height, Width];
    public static Object[] Players = new Object[CountOfplayers];

    // Use this for initialization
    void Start()
    {
        //Level data:
        for (int i = 1; i < Height; i++)
        {
            for (int j = 1; j < Width; j++)
            {
                if (((i % 2 == 0) && (j % 2 == 0))) 
                    Map[i, j] = 1;
                else Map[i, j] = 0;
                    //Boxes.Map.Add(new int[i, j], null);
                //if (((i % 2 == 0) && (j % 2 == 0)) || ((i % 2 == 1) && (j % 2 == 1))) 
            }
        }
        //Visualize level:
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (i == 0 || j == 0 || i == 99 || j == 99)
                {
                    
                    Object wall = Instantiate(Wall, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
                    MapT[i, j] = wall;
                }
                else if (Map[i, j] == 1)
                {
                    Object wall = Instantiate(Wall, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
                    MapT[i, j] = wall;
                }
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
