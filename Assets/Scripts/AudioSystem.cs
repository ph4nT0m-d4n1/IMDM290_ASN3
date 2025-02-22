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

    GameObject cube_sys2;
    GameObject sys2_parent;
    AudioSource source;
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
        ManageAudioSys();
        ManageCubeSys();
    }

    void ManageCubeSys()
    {
        cube_sys2 = GameObject.Find("cube_system2");

        if (cube_sys2)
        {
            sys2_parent = cube_sys2.transform.GetChild(0).gameObject;
            // Debug.Log(sys2_parent);

            if (CubeParent.time >= 168 && CubeParent.time <= 175)
            {
                sys2_parent.SetActive(false);
            }
            else if (CubeParent.time >= 178)
            {
                sys2_parent.SetActive(true);
            }
        }
    }

    void ManageAudioSys()
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
