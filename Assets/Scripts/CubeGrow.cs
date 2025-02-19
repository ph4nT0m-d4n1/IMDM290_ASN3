using UnityEngine;

public class CubeGrow : MonoBehaviour
{
    float time;
    float xScale;
    float yScale;
    float zScale;
    void Start()
    {
        xScale = gameObject.transform.localScale.x;
        yScale = gameObject.transform.localScale.y;
        zScale = gameObject.transform.localScale.z;
    }

    void Update()
    {
        time += Time.deltaTime * AudioSpectrum.audioAmp;
        Debug.Log(time);

        gameObject.transform.localScale = new Vector3(xScale, yScale * time, zScale);
        Renderer cubeRenderer = gameObject.GetComponent<Renderer>();

        float hue = 1f; 
        Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Cos(time)), Mathf.Cos(AudioSpectrum.audioAmp / 10f), 2f + Mathf.Cos(time)); 
        cubeRenderer.material.color = color;
    }
}
