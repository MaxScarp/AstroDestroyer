using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingX = 0.5f;
    [SerializeField] float paddingY = 0.5f;

    float xMin, xMax, yMin, yMax;


    private void Start()
    {
        SetupMoveBoundaries();
    }

    private void Update()
    {
        Move();
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

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingY;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingY;
    }
}
