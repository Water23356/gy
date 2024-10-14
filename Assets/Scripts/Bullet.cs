using UnityEngine;

public class Bullet:MonoBehaviour
{
    public float liveTime = 15f;
    public Balloon pregab;
    public float liftForce = 10;

    public float startVelocity = 3f;

    public float lineLength = 5f;

    private void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime < 0 )
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Agent agent = other.GetComponent<Agent>();
        if(agent!=null)
        {
            var newBallon = GameObject.Instantiate(pregab.gameObject);
            newBallon.gameObject.SetActive(true);
            newBallon.transform.position = agent.transform.position;
            newBallon.transform.localScale = Vector3.one * Mathf.Max(0.8f, liftForce/10f);
            newBallon.GetComponent<Rigidbody>().velocity = new Vector3(Random.value, Random.value, Random.value) * startVelocity;
            var bln= newBallon.GetComponent<Balloon>();
            bln.liftForce = liftForce;
            bln.Combine(agent.rigidbody, lineLength);
            enabled = false;
            Destroy(gameObject);
        }
    }
}