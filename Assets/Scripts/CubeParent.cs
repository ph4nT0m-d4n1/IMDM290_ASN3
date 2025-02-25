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
        MorphCubes();
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

    void MorphCubes()
    {
        if (time >= 235f)
        {
            for (int i = replacedCubes; i < transform.childCount; i++)
            {

                StartCoroutine(ShrinkCubeAndSpawnSphere(cubes[i]));
            }
            replacedCubes = transform.childCount; // Ensure all cubes are counted as replaced
        }
    }


    IEnumerator ShrinkCubeAndSpawnSphere(GameObject cube)
    {
        Vector3 startScale = cube.transform.localScale;
        Vector3 targetScale = Vector3.zero;

        float shrinkDuration = 1.5f;
        float elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            elapsedTime += Time.deltaTime;
            cube.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / shrinkDuration);
            yield return null;
        }

        // Disable cube and enable the sphere
        cube.SetActive(false);
    }
}
