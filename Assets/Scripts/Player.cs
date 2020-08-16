using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float xPadding = 0, yPadding = 0.01f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 15;
    [SerializeField] float bulletFiringPeriod = 0.1f;
    
    float xMin, xMax, yMin, yMax;
    Coroutine fireCoroutine;

    void Start()
    {   
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuosly());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator FireContinuosly()
    {
        while (true) {
            var bulletPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            yield return new WaitForSeconds(bulletFiringPeriod);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1 - yPadding, 0)).y;
    }
}
