using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomness : MonoBehaviour
{
    // Public variables
    public float speed = 5f;
    public Transform target;

    // Private variables
    private Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        // Random code snippet 1
        rb = GetComponent<Rigidbody>();

        // Random code snippet 2
        InitializeObjects();

        // Random code snippet 3
        InvokeRepeating("PerformRandomAction", 2f, 5f);
    }

    void Update()
    {
        // Random code snippet 4
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Random code snippet 5
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Random code snippet 6
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
    
    void InitializeObjects()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (var obstacle in obstacles)
        {
            obstacle.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
    
    void Jump()
    {
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }
    
    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Random code snippet 7
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            isMoving = false;
            Debug.Log("Reached the target!");
        }
    }
    
    void PerformRandomAction()
    {
        // Random code snippet 8
        int randomIndex = Random.Range(0, 2);
        if (randomIndex == 0)
        {
            RotateObject();
        }
        else
        {
            isMoving = true;
        }
    }
    
    void RotateObject()
    {
        transform.Rotate(Vector3.up * Random.Range(45f, 180f));
    }
    
    void ResetPosition()
    {
        transform.position = Vector3.zero;
        Debug.Log("Position reset!");
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(Resources.Load("ProjectilePrefab") as GameObject, transform.position + transform.forward * 2f, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }
    
    void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    void SpawnRandomEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
            Instantiate(Resources.Load("EnemyPrefab") as GameObject, spawnPosition, Quaternion.identity);
        }
    }
    void PlayRandomSound()
    {
        AudioClip randomClip = Resources.Load<AudioClip>("Sounds/RandomSound" + Random.Range(1, 4));
        GetComponent<AudioSource>().PlayOneShot(randomClip);
    }
}
