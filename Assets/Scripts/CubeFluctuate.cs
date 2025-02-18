using UnityEngine;

public class CubeFluctuate : MonoBehaviour
{
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
        gameObject.transform.localScale = new Vector3(xScale, yScale * AudioSpectrum.audioAmp, zScale);
    }
}
