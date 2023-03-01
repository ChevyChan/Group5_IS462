using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public GameObject ObjectPrefab; // Object Prefab 
    public Transform ObjectSpawnLocation; // Location of the object that will appear

    public GameObject EnemyPrefab;
    //public RuntimeAnimatorController animatorController;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(EnemyPrefab, GenerateRandomPosition(), Quaternion.identity); // Quaternion: Do not need to rotate, just stay at its position
        }

        Vector3 GenerateRandomPosition()
        {
            float x, y, z;
            x = Random.Range(-33, -21);
            z = Random.Range(0, 10);
            y = 0f;

            return new Vector3(x, y, z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Animator animator = GetComponent<Animator>();
            //animator.runtimeAnimatorController = animatorController;
            StatsController.startingScore++;

            Debug.Log("You have hit an enemy!");

            //Destroy(other.gameObject, 1f);
            Destroy(gameObject, 1f);
        }
    }
}
