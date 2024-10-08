using UnityEngine;

public class Shoot:MonoBehaviour
{
    public GameObject prefab;
    public Transform aim;
    public float speed = 80f;
    public float cd = 0.3f;
    public float timer = 0;

    public float liftForce = 10f;


    private void Update()
    {
        TryShoot();
    }

    private void TryShoot()
    {
        if(timer>0f)
        {
            timer -= Time.deltaTime;
            return;
        }

        if (Input.anyKey)
        {
            if(Input.GetMouseButtonDown(0))
            {
                timer = cd;

                var bullet = GetBullet();
                var ballon = bullet.GetComponent<Bullet>();
                ballon.liftForce = liftForce;

                bullet.gameObject.SetActive(true);
                var dir = (aim.position - transform.position).normalized;
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody>().velocity = dir * speed;
            }
            else if(Input.GetMouseButtonDown(1))
            {
                timer = cd;

                var bullet = GetBullet();
                var ballon = bullet.GetComponent<Bullet>();
                ballon.liftForce = liftForce * -1;

                bullet.gameObject.SetActive(true);
                var dir = (aim.position - transform.position).normalized;
                bullet.transform.position = transform.position;
                bullet.GetComponent<Rigidbody>().velocity = dir * speed;
            }
        }
    }

    private GameObject GetBullet()
    {
        return GameObject.Instantiate(prefab);
    }
}