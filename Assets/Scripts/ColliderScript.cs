using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    GameObject cubeSystem;

    GameObject audioSystem; 

    AudioSystem ASM;

    CubeSystemMovement CSM;
    
    void Start()
    {
        cubeSystem = GameObject.Find("cube_system");
        audioSystem = GameObject.Find("audio_system");

        CSM = cubeSystem.GetComponent<CubeSystemMovement>();
        ASM = audioSystem.GetComponent<AudioSystem>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            GameObject other_cube_system = Instantiate (cubeSystem, new Vector3(0f, 1.5f, 10f), Quaternion.identity);
            other_cube_system.name = "cube_system" + ASM.counter;
            ASM.counter += 1;

            // Debug.Log("cube system counter: " + ASM.counter);
        }
    }
}
