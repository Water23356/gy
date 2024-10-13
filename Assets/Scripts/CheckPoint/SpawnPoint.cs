using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Vector3 myPos;

    private GameObject player;

    private bool isActive = true;

    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        myPos = transform.position;

        spawner = Spawner.spawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GetComponent<MeshRenderer>().enabled = false;

            ResetSpawnPoint();

            Debug.Log("See Player");
        }

    }

    public void ResetSpawnPoint()
    {
        isActive = false;

        spawner.ResetSpawnPoint(myPos);
    }
}
