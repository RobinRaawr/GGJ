using UnityEngine;
using System.Collections;

public class GletsjerRespawn : MonoBehaviour {

    public GameObject spawnPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Spawnpoint")
        {
            transform.position = new Vector3(spawnPoint.transform.position.x, transform.position.y, transform.position.z);
        }

    }
}
