using Unity.VisualScripting;
using UnityEngine;

public class CubeGrow : MonoBehaviour
{
    float time;
    float xScale;
    float yScale;
    float zScale;
    public CubeParent CB;
    void Start()
    {
        xScale = gameObject.transform.localScale.x;
        yScale = gameObject.transform.localScale.y;
        zScale = gameObject.transform.localScale.z;

        xScale = 0.15f;
        zScale = 0.15f;
    }

    void Update()
    {
        time += Time.deltaTime * AudioSpectrum.audioAmp;

        gameObject.transform.localScale = new Vector3(xScale, yScale * time, zScale);
        Renderer cubeRenderer = gameObject.GetComponent<Renderer>();

        if (CubeParent.time < 60)
        {
            float hue = 1f;
            Color color = Color.HSVToRGB(hue, Mathf.Cos(AudioSpectrum.audioAmp / 10f), 0.5f); 
            cubeRenderer.material.color = color;
        }
        else if (CubeParent.time > 60 && CubeParent.time < 80)
        {
            float hue = 1f;
            Color color = Color.HSVToRGB(hue, Mathf.Cos(AudioSpectrum.audioAmp / 10f), 2f + Mathf.Cos(time)); 
            cubeRenderer.material.color = color;
        }
        else
        {
            for (int i = 0; i < 100; i++)
            {
                float hue = 1f;
                Color color = Color.HSVToRGB(Mathf.Abs(hue), Mathf.Cos(AudioSpectrum.audioAmp / 10f), 2f + Mathf.Cos(time)); 
                cubeRenderer.material.color = color;
            }

        }

    }
}
