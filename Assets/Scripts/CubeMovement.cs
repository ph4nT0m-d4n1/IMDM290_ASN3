using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (CubeParent.time >= 35)
        {
            transform.position += new Vector3 (0f, 0f, -0.1f * Time.deltaTime);
        }
        
    }
}
