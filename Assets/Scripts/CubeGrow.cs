using UnityEngine;

public class CubeGrow : MonoBehaviour
{
    public GameObject cube;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        cube.transform.localScale = new Vector3(1f, 1f * time, 1f);
    }
}
