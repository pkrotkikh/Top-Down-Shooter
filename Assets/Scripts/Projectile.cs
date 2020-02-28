using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;
        }
    }
}
