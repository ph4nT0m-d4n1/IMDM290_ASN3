using UnityEngine;

public class CubeGrow : MonoBehaviour
{
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(1f, 1f * time, 1f);
    }
}
