using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.45f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;

    
    float xMin, xMax, yMin, yMax;
    Camera gameCamera;

    private Vector3 mouseToWorldPosition() => gameCamera.ScreenToWorldPoint(Input.mousePosition);

    private void Start()
    {
        gameCamera = Camera.main;
        SetupMoveBoundaries();
    }

    private void Update()
    {
        Move();
        //Aim();
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, laserSpeed);
        }
    }

    private void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        movement *= Time.deltaTime * moveSpeed;

        float playerPosX = transform.position.x + movement.x;
        float playerPosY = transform.position.y + movement.y;

        transform.position = new Vector2(Mathf.Clamp(playerPosX, xMin, xMax), Mathf.Clamp(playerPosY, yMin, yMax));
    }

    private void Aim()
    {
        Vector3 mousePosition = mouseToWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -angle);
    }

    private void SetupMoveBoundaries()
    {
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
