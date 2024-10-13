using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner instance;

    public GameObject player;

    public static Spawner spawner
    {
        get
        {
            return instance;
        }
    }

    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

            Debug.Log("重生监听已加载");
        }
    }

    public void ResetSpawnPoint(Vector3 vector3)
    {
        spawnPosition = vector3;
     
        Debug.Log("新重生点已设置");
     }

    public void ReSpawn()
    {
        player.transform.position = spawnPosition;
    }
}
