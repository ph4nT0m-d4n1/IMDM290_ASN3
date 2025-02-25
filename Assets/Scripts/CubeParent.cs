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
        if (time >= 235f && replacedCubes < transform.childCount)
        {
            StartCoroutine(ReplaceCubesSequentially());
        }
    }

    IEnumerator ReplaceCubesSequentially()
    {
        while (replacedCubes < transform.childCount)
        {
            if (replacedCubes % 2 == 0)
            {
                cubes[replacedCubes].GetComponent<CubeFluctuate>().enabled = false;
            }
            else
            {
                cubes[replacedCubes].GetComponent<CubeGrow>().enabled = false;
            }

            StartCoroutine(ShrinkCubeAndSpawnSphere(cubes[replacedCubes]));
            replacedCubes++;

            yield return new WaitForSeconds(0.1f); // Adjust timing as needed
        }
    }

    IEnumerator ShrinkCubeAndSpawnSphere(GameObject cube)
    {   
        Vector3 startScale = cube.transform.localScale;
        Vector3 targetScale = Vector3.zero;
        Vector3 startPosition = cube.transform.position;

        // Create the sphere but keep it inactive initially
        sphere_system = GameObject.Find("sphere_system");

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = startPosition;
        sphere.transform.localScale = Vector3.one; 
        sphere.SetActive(false);

        sphere.transform.parent = sphere_system.transform;

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
        sphere.SetActive(true);

        // Lerp the sphere
        // StartCoroutine(LerpSphere(sphere, startPosition, startPosition + new Vector3(0, 5f, 0)));
    }

    // IEnumerator LerpSphere(GameObject sphere, Vector3 startPos, Vector3 endPos)
    // {
    //     float lerpDuration = 2f;
    //     float elapsedTime = 0f;
    //     Vector3 startScale = Vector3.zero;
    //     Vector3 targetScale = new Vector3(1f, 1f, 1f);

    //     while (elapsedTime < lerpDuration)
    //     {
    //         elapsedTime += Time.deltaTime;
    //         float t = elapsedTime / lerpDuration;

    //         sphere.transform.position = Vector3.Lerp(startPos, endPos, t);
    //         sphere.transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            
    //         yield return null;
    //     }
    // }
}
