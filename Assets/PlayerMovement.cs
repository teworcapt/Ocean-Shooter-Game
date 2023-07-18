using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //prefab projectile
    public GameObject bulletPreFab;

    //bullet Spawn here
    public Transform bulletSpawnPoint;

    //speed of bullet
    public float bulletSpeed;

    //speed
    public float moveSpeed;

    //RigidBody
    public Rigidbody2D rigidBody;
    private Vector2 movementInput;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * bulletSpeed;
        }
    }

    private void FixedUpdate()
    {
        //makes our player move
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        //wasd = vector 2 values
        movementInput = inputValue.Get<Vector2>();
    }
}
