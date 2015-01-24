using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {

    public static PlaneControl control;
    public int lanes;
    public float width;

    void Awake()
    {
        control = this;
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Bounds bounds = mesh.bounds;
		width = bounds.size.x;
		lanes = 6;
    }

}
