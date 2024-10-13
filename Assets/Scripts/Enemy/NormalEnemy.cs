using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    public GameObject aliveState;

    public GameObject freezeState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    ///升至固定高度后死亡 
    /// </summary>
    public void Freeze()
    {
        aliveState.GetComponent<MeshRenderer>().enabled = false;

        freezeState.GetComponent<MeshRenderer>().enabled = true;

    }
}
