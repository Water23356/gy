using UnityEngine;

public class CameraLookAt:MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        transform.LookAt(target);
    }
}