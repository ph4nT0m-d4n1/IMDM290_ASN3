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

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * AudioSpectrum.audioAmp;
        gameObject.transform.localScale = new Vector3(xScale, yScale * time, zScale);
    }
}
