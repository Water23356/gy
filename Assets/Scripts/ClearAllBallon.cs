using UnityEngine;
using UnityEngine.UIElements;

public class ClearAllBallon:MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKey)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                BalloonPool.Instance.ReturnAll();
            }
        }
    }
}