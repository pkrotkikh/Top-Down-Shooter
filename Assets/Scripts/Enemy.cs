using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float speed = 3;

    Player player;
    Rigidbody myRb;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        myRb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = (player.transform.position - gameObject.transform.position).normalized;
        myRb.MovePosition(myRb.position + dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag){
            case "Player":
                player.TakeDamage(50);
                break;
        }
    }
}
