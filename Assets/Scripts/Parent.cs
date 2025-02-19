using UnityEngine;

public class Parent : MonoBehaviour
{
    GameObject [] cubes;
    void Start()
    {
        cubes = new GameObject [transform.childCount]; //the array's value is the amount of children the gameobject has

        for (int i = 0; i < transform.childCount; i++)
        {
            cubes[i] = transform.GetChild(i).gameObject;

            if (i % 2 == 0)
            {
                CubeFluctuate fluctuate = cubes[i].AddComponent<CubeFluctuate>();
            }
            
            else
            {
                CubeGrow grow = cubes[i].AddComponent<CubeGrow>();
            }
        }
        
        Debug.Log(cubes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
