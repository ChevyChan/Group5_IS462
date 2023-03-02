using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    private double start;
    Rigidbody m_Rigidbody;
    public GameObject target;
    public AudioSource audioSource;
    public AudioClip crashSound;
    public float moveSpeed;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = crashSound;
        audioSource.Play();
        start = Time.realtimeSinceStartup;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.realtimeSinceStartup;
        if (!gameOver)
        {
            if (timeNow > 120)
            {
                Debug.Log("Running");
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }
            else
            {
                Debug.Log("Walking");
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }
        }
        //var lookPos = target.transform.position - transform.position;
        //var rotation = Quaternion.LookRotation(lookPos);
        //rotation.y = 0;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1F * Time.deltaTime);
        if (!gameOver)
        {
            // Get the terrain height at the target position
            float terrainHeight = Terrain.activeTerrain.SampleHeight(target.transform.position);

            // Calculate the target position on the terrain
            Vector3 targetPosOnTerrain = new Vector3(target.transform.position.x, terrainHeight, target.transform.position.z);

            // Move the object towards the target position on the terrain
            transform.position = Vector3.MoveTowards(transform.position, targetPosOnTerrain, 1F * Time.deltaTime);

            transform.LookAt(targetPosOnTerrain);
        } else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOver = true;
            Debug.Log("END");
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Hello");
        }

    }
}
