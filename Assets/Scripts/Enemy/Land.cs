using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Land : MonoBehaviour
{
    private Spawner spawner;

    public GameObject parentObject;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        spawner = Spawner.spawner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Freeze()
    {
        parentObject.GetComponent<NormalEnemy>().Freeze();

        isDead = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            spawner.ReSpawn();
        }
    }
}
