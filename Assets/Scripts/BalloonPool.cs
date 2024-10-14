using System.Collections.Generic;
using UnityEngine;

public class BalloonPool : MonoBehaviour
{
    private static BalloonPool instance;

    public static BalloonPool Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int count = 50;

    private Queue<Balloon> queue = new Queue<Balloon>();
    private List<Balloon> used = new List<Balloon>();

    public Balloon GetObject()
    {
        var bl = queue.Dequeue();
        bl.transform.SetParent(null);
        if (bl != null)
        {
            used.Add(bl);
            bl.gameObject.SetActive(true);
            bl.ResetState();
        }
        return bl;
    }

    public void ReturnAll()
    {
        for (int i = 0; i < used.Count; i++)
        {
            Balloon balloon = used[i];
            balloon.transform.SetParent(transform);
            balloon.gameObject.SetActive(false);
            queue.Enqueue(balloon);
        }
        used.Clear();
    }

    public void Return(Balloon balloon)
    {
        balloon.transform.SetParent(transform);
        balloon.gameObject.SetActive(false);
        queue.Enqueue(balloon);
        used.Remove(balloon);
    }

    private void Start()
    {
        int count = this.count;
        while (count > 0)
        {
            count--;
            var obj = GameObject.Instantiate(prefab);
            var bl = obj.GetComponent<Balloon>();
            Return(bl);
        }
    }
}