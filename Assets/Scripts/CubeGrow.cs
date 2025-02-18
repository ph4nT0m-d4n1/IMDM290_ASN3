using UnityEngine;

public class CubeGrow : MonoBehaviour
{
    float time;
    float x;
    float y;
    float z;
    
   
    void Start()
    {
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(x,  y* time, z);
    }
}
