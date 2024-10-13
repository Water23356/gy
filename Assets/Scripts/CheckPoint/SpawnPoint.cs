using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Vector3 myPos;

    private GameObject player;

    private object myMesh;

    // Start is called before the first frame update
    void Start()
    {
        myPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GetComponent<MeshRenderer>().enabled = false;

            Debug.Log("See Player");
        }


    }
}
