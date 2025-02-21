using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    GameObject cubeSystem;
    
    void Start()
    {
        cubeSystem = GameObject.Find("cube_system");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Instantiate (cubeSystem, new Vector3(0f, 1.5f, 10f), Quaternion.identity);
            Debug.Log("all good!");
        }
    }

   
}
