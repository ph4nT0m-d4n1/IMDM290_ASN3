using UnityEngine;
using System.Collections;

public class CubeParent : MonoBehaviour
{
    GameObject [] cubes;
    public static float time;
    int replacedCubes = 0;
    GameObject sphere_system;
    void Start()
    {
        InitializeChildren();
    }

    void Update()
    {
        AwakenChildren();
    }

    void InitializeChildren()
    {
        cubes = new GameObject [transform.childCount]; //the array's value is the amount of children the gameobject has

        for (int i = 0; i < transform.childCount; i++)
        {
            cubes[i] = transform.GetChild(i).gameObject;
            cubes[i].SetActive(false);

            if (i % 2 == 0)
            {
                CubeFluctuate fluctuate = cubes[i].AddComponent<CubeFluctuate>();
            }   
            else
            {
                CubeGrow grow = cubes[i].AddComponent<CubeGrow>();
            }
        }
    }

    void AwakenChildren()
    {
        time += Time.deltaTime * AudioSystem.audioAmp;
        // Debug.Log(time);

        //time of ___ = 130
        // time of beat drop = 168

        if (time >= 34f) //the cubes appear when the exposition ends
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i].SetActive(true);
            }
        }
    }
}
