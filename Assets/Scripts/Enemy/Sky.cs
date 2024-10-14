using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    public bool isDead = false;

    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = Spawner.spawner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 坠地死亡
    /// </summary>
    public void Drawn()
    {
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
