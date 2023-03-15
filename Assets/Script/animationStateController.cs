using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    private double start;
    Rigidbody m_Rigidbody;
    public GameObject target;
    public GameObject firecracker;
    public GameObject drum;
    public GameObject redpacker;
    public GameObject Success;
    public GameObject Failure;
    public GameObject Title;
    public GameObject Information;
    public GameObject Locomotion;
    public AudioSource sfx;
    public AudioClip failure;
    public AudioClip win;
    public AudioClip applause;
    public AudioClip cymbal;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public float moveSpeed;
    private int counter = 0;
    public bool gameOver = false;
    public bool completed = false;
    public bool stun = false;
    public TMPro.TextMeshProUGUI information;

    // Start is called before the first frame update
    void Start()
    {
        start = Time.realtimeSinceStartup;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            float timeNow = Time.realtimeSinceStartup;
            string newText = "\nScare away the Nian (" + counter.ToString() + "/5)\nor survive for " + (150 - (int)timeNow).ToString() + " s";
            if (counter >= 5)
            {
                Title.SetActive(false);
                Information.SetActive(false);
                Success.SetActive(true);
                Locomotion.SetActive(false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
                StartCoroutine(PlayWinningSound());
                completed = true;
                return;
            }

            if (!gameOver && !stun)
            {
                if (timeNow > 150)
                {
                    Debug.Log("Stage Cleared");
                    gameOver = true;
                    StartCoroutine(PlayWinningSound());
                }
                else if (timeNow > 120)
                {
                    moveSpeed = 2F;
                    newText += "\n(Careful! Nian has sped up!)";
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isWalking", true);
                }
            } else if (gameOver || stun)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
            }
                //var lookPos = target.transform.position - transform.position;
                //var rotation = Quaternion.LookRotation(lookPos);
                //rotation.y = 0;
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
                //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1F * Time.deltaTime);
            if (!gameOver && !stun)
            {
                // Get the terrain height at the target position
                float terrainHeight = Terrain.activeTerrain.SampleHeight(target.transform.position);

                // Calculate the target position on the terrain
                Vector3 targetPosOnTerrain = new Vector3(target.transform.position.x, terrainHeight, target.transform.position.z);

                // Move the object towards the target position on the terrain
                transform.position = Vector3.MoveTowards(transform.position, targetPosOnTerrain, moveSpeed * Time.deltaTime);

                transform.LookAt(targetPosOnTerrain);
            }
            else if (gameOver || stun)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
            }
            information.text = newText;
        }
    }

    internal void Stun()
    {
        stun = true;
        counter++;
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isDamage", true);
        StartCoroutine(StunWait());
    }

    IEnumerator StunWait()
    {
        yield return new WaitForSecondsRealtime(5);
        stun = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOver = true;
            Information.SetActive(false);
            Locomotion.SetActive(false);
            Title.SetActive(false);
            Failure.SetActive(true);
            sfx.clip = failure;
            sfx.Play();
        }

    }

    IEnumerator PlayWinningSound()
    {
        sfx.clip = win;
        sfx.Play();
        yield return new WaitForSeconds(sfx.clip.length);
        sfx.clip = applause;
        sfx.Play();
    }
}
