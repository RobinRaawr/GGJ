using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {

    public static GameObject control;
    public int lanes;
    public float width;

    void Awake()
    {
        control = this.gameObject;

    }

}
