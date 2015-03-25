using UnityEngine;
using System.Collections;

public class DetectionManager : MonoBehaviour
{
    public int borderSize = 20;
    public int borderHeight = 5;
    public int cubeSize = 25;
    public GameObject cubePrefab;

    private Color[] colorList = { Color.gray, Color.yellow };

    // Use this for initialization
    void Start()
    {
        CreateDetectionCubes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateDetectionCubes()
    {
        int colorSelector = 0;
        GameObject g;

        for (int x = -borderSize; x <= borderSize; x++)
        {
            for (int z = -borderSize; z <= borderSize; z++)
            {
                for (int y = Random.Range(0, 3 ); y <= Random.Range(2, 7); y++)
                {
                    g =
                        (GameObject)
                            Instantiate(cubePrefab, new Vector3(x * cubeSize, y * cubeSize, z * cubeSize), Quaternion.identity);
                    g.GetComponent<MeshRenderer>().material.color = colorList[colorSelector];
                }
                colorSelector = 1 - colorSelector;
            }
        }
    }
}
