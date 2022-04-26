using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    private bool movingLeft = true;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 2f;
    [SerializeField] private Transform groundDetection;

    private void Update()
    {
        if (Physics.Raycast(groundDetection.position, Vector3.down, distance))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    // Update is called once per frame
    public void takeDamage()
    {
        enemyHealth -= 50f;
        if (enemyHealth < 1f) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 8)
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
        else if (other.gameObject.layer == 6)
        {
            takeDamage();
        }
    }
}
