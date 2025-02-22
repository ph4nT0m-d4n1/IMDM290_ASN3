using UnityEngine;

public class CubeSystemMovement : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (CubeParent.time >= 35)
        {
            transform.position += new Vector3 (0f, .1f * Time.deltaTime, -0.3f * Time.deltaTime);
        }
        
    }
}
