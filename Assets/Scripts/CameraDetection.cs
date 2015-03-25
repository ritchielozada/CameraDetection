using UnityEngine;
using System.Collections;

public class CameraDetection : MonoBehaviour
{
    private int DetectionTTL = 0;
    private Color origColor;
    private Material materialReference;
    private MeshRenderer rendererReference;


    // Use this for initialization
    void Start()
    {
        rendererReference = GetComponent<MeshRenderer>();
        materialReference = rendererReference.material;
        origColor = materialReference.color;
    }

    
    void Update()
    {

    }

    void FixedUpdate()
    {
        /*
        
        // Using Time To Live approach, this runs on every cube.
        // Countdown the TTL until the object needs to check
         
        if (DetectionTTL > 0)
        {
            DetectionTTL--;
            if (DetectionTTL == 0)
            {
                materialReference.color = origColor;
            }
        }
         
         */
    }

    void OnWillRenderObject()
    {
        if (Camera.current == Camera.main)
        {
            if (DetectionTTL == 0)
            {
                StartCoroutine("LoadMesh");
                StartCoroutine("CleanUp");
            }
            DetectionTTL = 1;
        }
    }

    IEnumerator LoadMesh()
    {
        // Load Mesh and Update GameObject Asynchronously
        materialReference.color = Color.blue;
        yield return null;
    }

    IEnumerator CleanUp()
    {
        // Executes only for rendered cubes until timeout.
        // Random distribution of processing time to distribute checking load
        // Wait Time Period need to match data load latencies
        while(true)
        {
            yield return new WaitForSeconds(1 + 2 * Random.value);
            if (!rendererReference.isVisibleFrom(Camera.main))
            {
                DetectionTTL = 0;
                materialReference.color = origColor;
                break;
            }
        }
        yield return null;
    }
}
