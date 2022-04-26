using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boundary : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPoint;
    public Player player;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoundObj"))
        {
            RestartScene();
        }
    }

    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}
