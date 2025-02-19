using Unity.VisualScripting;
using UnityEngine;

public class CubeFluctuate : MonoBehaviour
{
    float xScale;
    float yScale;
    float zScale;
    float time;
    void Start()
    {
        xScale = gameObject.transform.localScale.x;
        yScale = gameObject.transform.localScale.y;
        zScale = gameObject.transform.localScale.z;
    }

    void Update()
    {
        time += Time.deltaTime * AudioSpectrum.audioAmp;
        
        gameObject.transform.localScale = new Vector3(xScale, yScale * time * AudioSpectrum.audioAmp, zScale);
        Renderer cubeRenderer = gameObject.GetComponent<Renderer>();

        for (int i = 0; i < 100; i++)
        {
            float hue = i / 100; 
            Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Cos(AudioSpectrum.audioAmp)), Mathf.Cos(AudioSpectrum.audioAmp / 10f), 2f + Mathf.Cos(AudioSpectrum.audioAmp)); 
            cubeRenderer.material.color = color;
        }
        
    }
}
