using UnityEngine;

[RequireComponent(typeof (PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour {

    public float moveSpeed = 5;
    public int health = 100;

    float rayDistance;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    void Start() {
        viewCamera = Camera.main;
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }

    void Update() {
        Move();
        LookAt();
        Controlls();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Debug.Log("YOU DIE!");
        }
    }

    void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Velocity(moveVelocity);
    }
    void LookAt()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            controller.LookAt(point);
        }
    }
    void Controlls()
    {
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
