using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NerdHeadExtensions.Vectors;
using NerdHeadExtensions;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour
{
    public RectTransform rTransform;
    public Button button;
    public Object cube;
    // Start is called before the first frame update
    void Start()
    {
        // Way 1
        Vector3 randomVector = new Vector3();
        randomVector.RandomVector3(Vector3.zero, Vector3.one * 10);
        //print(randomVector);

        // Way 2
        // print(RandomV3.Range(Vector3.zero, Vector3.one * 10));
        Instantiate(cube);
    }

    // Update is called once per frame
    void Update()
    {
        //non();
        transform.LookAt2D(Camera.main.GetMouseScreenPos());
        //print(Camera.main.GetMouseScreenPos());
    }
}
