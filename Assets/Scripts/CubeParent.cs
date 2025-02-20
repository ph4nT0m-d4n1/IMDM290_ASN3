using UnityEngine;

public class CubeParent : MonoBehaviour
{
    GameObject [] cubes;
    public static float time;
    void Start()
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

    void Update()
    {
        time += Time.deltaTime * AudioSpectrum.audioAmp;
        //Debug.Log(time);

        if (time >= 34.96f) //the cubes appear when the exposition ends
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                cubes[i].SetActive(true);
            }
        }
    }
}
