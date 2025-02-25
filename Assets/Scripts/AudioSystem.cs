using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    [HideInInspector] public int counter;
    [HideInInspector] public static int FFTSIZE = 1024;
    [HideInInspector] public static float[] samples;
    [HideInInspector] public static float audioAmp = 0f;

    GameObject cube_sys;
    GameObject cube_sys1;
    GameObject cube_sys2;
    GameObject sys2_parent;
    GameObject sys2_collider;
    AudioSource source;
    float audioTime;
    void Start()
    {
        counter = 1;
        // Debug.Log("counter starting... " + counter);

        source = GetComponent<AudioSource>();   
        samples = new float[FFTSIZE];   
    }

    // Update is called once per frame
    void Update()
    {
        audioTime += Time.deltaTime  * audioAmp;
        Debug.Log(audioTime);
        ManageAudioSys();
        ManageCubeSys();
    }

    void ManageCubeSys()
    {
        cube_sys = GameObject.Find("cube_system");
        cube_sys1 = GameObject.Find("cube_system1");
        cube_sys2 = GameObject.Find("cube_system2");

        if (cube_sys2)
        {
            sys2_parent = cube_sys2.transform.GetChild(0).gameObject;
            sys2_collider = cube_sys2.transform.GetChild(1).gameObject;
            // Debug.Log(sys2_parent);

            if (CubeParent.time >= 168)
            {
                sys2_parent.SetActive(false);
            }

            if (audioTime >= 1000)
            {
                cube_sys.transform.GetChild(0).gameObject.SetActive(false);
                cube_sys1.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    void ManageAudioSys() //imported from Prof. Lee's AudioSpectrum script
    {
        // source (time domain) transforms into samples in frequency domain 
        source.GetSpectrumData(samples, 0, FFTWindow.Hanning);
        // empty first then pull down the value.
        audioAmp = 0f;
        for (int i = 0; i < FFTSIZE; i++)
        {
            audioAmp += samples[i];
        }   
    }
}
