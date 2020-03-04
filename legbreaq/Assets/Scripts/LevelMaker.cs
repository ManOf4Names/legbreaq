using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    enum gridSpace {empty, room, spawnRoom};
    gridSpace[,] grid;
    int roomHeight, roomWidth;
    Vector2 roomSizeWorldUnits = new Vector2(2000, 2000);
    public float worldUnitsInOneGridCell = 200;
    struct walker
    {
        public Vector2 dir;
        public Vector2 pos;
    }
    List<walker> walkers;
    public float chanceWalkerChangeDir = 0.5f, chanceWalkerSpawn = 0.05f;
    public float chanceWalkerDestoy = 0.05f;
    public int maxWalkers = 10;
    public float percentToFill = 0.2f;
    public GameObject LRUD;
    public GameObject L;
    public GameObject LR;
    public GameObject LRU;
    public GameObject LRD;
    public GameObject LU;
    public GameObject LUD;
    public GameObject LD;
    public GameObject R;
    public GameObject RU;
    public GameObject RD;
    public GameObject RUD;
    public GameObject U;
    public GameObject UD;
    public GameObject D;
    public GameObject spawnRoom;

    int spawnX = 0;
    int spawnY = 0;


    GameObject roomObj;
    void Start()
    {
        Setup();
        CreateRooms();
        FixRoom();
        SpawnLevel();
    }
    void Setup()
    {
        //find grid size
        roomHeight = Mathf.RoundToInt(roomSizeWorldUnits.x / worldUnitsInOneGridCell);
        roomWidth = Mathf.RoundToInt(roomSizeWorldUnits.y / worldUnitsInOneGridCell);
        //create grid
        grid = new gridSpace[roomWidth, roomHeight];
        //set grid's default state
        for (int x = 0; x < roomWidth - 1; x++)
        {
            for (int y = 0; y < roomHeight - 1; y++)
            {
                //make every cell "empty"
                grid[x, y] = gridSpace.empty;
            }
        }
        //set first walker
        //init list
        walkers = new List<walker>();
        //create a walker 
        walker newWalker = new walker();
        newWalker.dir = RandomDirection();
        //find center of grid
        Vector2 spawnPos = new Vector2(Mathf.RoundToInt(roomWidth / 2.0f), Mathf.RoundToInt(roomHeight / 2.0f));
        newWalker.pos = spawnPos;
        //add walker to list
        walkers.Add(newWalker);
    }
    void CreateRooms()
    {
        int iterations = 0;//loop will not run forever
        int angle;
        do
        {
            //create room at position of every walker
            foreach (walker myWalker in walkers)
            {
                if (iterations == 0)
                {
                    grid[(int)myWalker.pos.x, (int)myWalker.pos.y] = gridSpace.spawnRoom;
                }
                else{
                    if (grid[(int)myWalker.pos.x, (int)myWalker.pos.y] != gridSpace.spawnRoom)
                    {
                        grid[(int)myWalker.pos.x, (int)myWalker.pos.y] = gridSpace.room;
                    }
                }
            }
            //chance: destroy walker
            int numberChecks = walkers.Count; //might modify count while in this loop
            for (int i = 0; i < numberChecks; i++)
            {
                //only if its not the only one, and at a low chance
                if (Random.value < chanceWalkerDestoy && walkers.Count > 1)
                {
                    walkers.RemoveAt(i);
                    break; //only destroy one per iteration
                }
            }
            //chance: walker pick new direction
            for (int i = 0; i < walkers.Count; i++)
            {
                if (Random.value < chanceWalkerChangeDir)
                {
                    walker thisWalker = walkers[i];
                    thisWalker.dir = RandomDirection();
                    walkers[i] = thisWalker;
                }
            }
            //chance: spawn new walker
            numberChecks = walkers.Count; //might modify count while in this loop
            for (int i = 0; i < numberChecks; i++)
            {
                //only if # of walkers < max, and at a low chance
                if (Random.value < chanceWalkerSpawn && walkers.Count < maxWalkers)
                {
                    //create a walker 
                    walker newWalker = new walker();
                    newWalker.dir = RandomDirection();
                    newWalker.pos = walkers[i].pos;
                    walkers.Add(newWalker);
                }
            }
            //move walkers
            for (int i = 0; i < walkers.Count; i++)
            {
                walker thisWalker = walkers[i];
                thisWalker.pos += thisWalker.dir;
                walkers[i] = thisWalker;
            }
            //avoid boarder of grid
            for (int i = 0; i < walkers.Count; i++)
            {
                walker thisWalker = walkers[i];
                //clamp x,y to leave a 1 space boarder: leave room for walls
                thisWalker.pos.x = Mathf.Clamp(thisWalker.pos.x, 1, roomWidth - 2);
                thisWalker.pos.y = Mathf.Clamp(thisWalker.pos.y, 1, roomHeight - 2);
                walkers[i] = thisWalker;
            }
            //check to exit loop
            if ((float)NumberOfRooms() / (float)grid.Length > percentToFill)
            {
                break;
            }
            iterations++;
        } while (iterations < 10000);
    }
   
    void SpawnLevel()
    {
        int choice = Mathf.FloorToInt(Random.value * 3.99f);
        int rand;
        string s = "";

        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                s = "";
                if (grid[x, y] == gridSpace.room)
                {
                    if (grid[x - 1, y] == gridSpace.room || grid[x - 1, y] == gridSpace.spawnRoom)
                    {
                        s = s + "L";
                    }
                    if (grid[x + 1, y] == gridSpace.room || grid[x + 1, y] == gridSpace.spawnRoom)
                    {
                        s = s + "R";
                    }
                    if (grid[x, y + 1] == gridSpace.room || grid[x, y + 1] == gridSpace.spawnRoom)
                    {
                        s = s + "U";
                    }
                    if (grid[x, y - 1] == gridSpace.room || grid[x, y - 1] == gridSpace.spawnRoom)
                    {
                        s = s + "D";
                    }

                    switch (s)
                    {
                        case "LRUD":
                            //rand = Random.Range(0, bottomRooms.Length);
                            roomObj = LRUD;
                            Spawn(x, y, roomObj);
                            break;

                        case "L":
                            roomObj = L;
                            Spawn(x, y, roomObj);
                            break;

                        case "LR":
                            roomObj = LR;
                            Spawn(x, y, roomObj);
                            break;

                        case "LRU":
                            roomObj = LRU;
                            Spawn(x, y, roomObj);
                            break;

                        case "LRD":
                            roomObj = LRD;
                            Spawn(x, y, roomObj);
                            break;

                        case "LU":
                            roomObj = LU;
                            Spawn(x, y, roomObj);
                            break;

                        case "LUD":
                            roomObj = LUD;
                            Spawn(x, y, roomObj);
                            break;

                        case "LD":
                            roomObj = LD;
                            Spawn(x, y, roomObj);
                            break;

                        case "R":
                            roomObj = R;
                            Spawn(x, y, roomObj);
                            break;

                        case "RU":
                            roomObj = RU;
                            Spawn(x, y, roomObj);
                            break;

                        case "RD":
                            roomObj = RD;
                            Spawn(x, y, roomObj);
                            break;

                        case "RUD":
                            roomObj = RUD;
                            Spawn(x, y, roomObj);
                            break;

                        case "U":
                            roomObj = U;
                            Spawn(x, y, roomObj);
                            break;

                        case "UD":
                            roomObj = UD;
                            Spawn(x, y, roomObj);
                            break;

                        case "D":
                            roomObj = D;
                            Spawn(x, y, roomObj);
                            break;

                        default:

                            break;

                    }
                }
            }
        }
    }

    void FixRoom()
    {
        int choice = Mathf.FloorToInt(Random.value * 3.99f);
        int rand;
        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                if (grid[x, y] == gridSpace.spawnRoom)
                {
                        grid[x - 1, y] = gridSpace.room;
                        grid[x + 1, y] = gridSpace.room;
                        grid[x, y - 1] = gridSpace.room;
                        grid[x, y + 1] = gridSpace.room;

                        roomObj = spawnRoom;
                        Spawn(x, y, roomObj);
                        spawnX = x;
                        spawnY = y;

                }
            }
        }
    }

    Vector2 RandomDirection()
    {
        //pick random int between 0 and 3
        int choice = Mathf.FloorToInt(Random.value * 3.99f);
        //use that int to chose a direction
        switch (choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            default:
                return Vector2.right;
        }
    }

    int NumberOfRooms()
    {
        int count = 0;
        foreach (gridSpace space in grid)
        {
            if (space == gridSpace.spawnRoom || space == gridSpace.room)
            {
                count++;
            }
        }
        return count;
    }

    void Spawn(float x, float y, GameObject toSpawn)
    {
        //find the position to spawn
        Vector2 offset = roomSizeWorldUnits / 2.0f;
        Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell - offset;
        //spawn object
        Instantiate(toSpawn, spawnPos, Quaternion.identity);
    }
}