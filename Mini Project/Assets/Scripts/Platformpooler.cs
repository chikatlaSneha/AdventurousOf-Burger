using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformpooler : MonoBehaviour
{
    //StartPoint = -10.
    //EndPoint = +470.
    public List<GameObject> PlatfromsPool = new List<GameObject>();
    public List<int> PlatformPlacer = new List<int>();//
    public List<int> IndexVals = new List<int>();
    public float distance;
    public int Dist;
    public int CountDist;
    public GameObject platformprefab;

    void Start()
    {
        createplatform(platformprefab);//
       // InvokeRepeating("placePlatforms", 1f, 2f);
    }

    void Update()
    {
    
    }

    void createplatform(GameObject platpool)
    {
        for(int i = 0;i<=15;i++) //platformcount
        {
            var Pobj = Instantiate(platpool, gameObject.transform.position, Quaternion.identity);
            platpool.SetActive(false);
            PlatfromsPool.Add(Pobj);
        }

        PlaceAtDist();
    }

    //PlatfromsPool - 15
    public void PlaceAtDist()
    {
        Dist = 0;
        CountDist = 100;
        for (int i = 0; i < 20; i++)
        {
            int Rand = Random.Range(0, 3);//3,5,7
            int Temp = RandDistance(Rand);
            Dist += (Temp + 15);
            PlatformPlacer.Add(Dist);
            if (Dist > 480)
            {
                IndexVals.Add(i);
                break;
            }

            if (Dist > CountDist)
            {
               CountDist += 100;
                IndexVals.Add(i);
            }
           // PlatfromsPool[i].transform.position = new Vector3(Dist, 3f, 0);
           // PlatfromsPool[i].SetActive(true);
        }
    }

    public int RandDistance(int n)
    {
        int Num = 0;
        switch (n)
        {
            case 0:
                Num = 3;
                
                break;
            case 1:
                Num = 5;
              
                break;
            case 2:
                Num = 7;
                break;
        }

        return Num;
    }


    public void Interact(int Val)
    {
        for (int i = 0; i <= 4; i++) 
        {
            Val = IndexVals[i];
            Debug.Log(Val);
        }

    }
}
