using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    GameObject cubeSystem;

    GameObject audioSystem; 

    AudioSystem CSM;
    
    void Start()
    {
        cubeSystem = GameObject.Find("cube_system");
        audioSystem = GameObject.Find("audio_system");

        CSM = audioSystem.GetComponent<AudioSystem>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            GameObject other_cube_system = Instantiate (cubeSystem, new Vector3(0f, 1.5f, 10f), Quaternion.identity);
            other_cube_system.name = "cube_system" + CSM.counter;
            CSM.counter += 1;

            Debug.Log("cube system counter: " + CSM.counter);
        }
    }
}
