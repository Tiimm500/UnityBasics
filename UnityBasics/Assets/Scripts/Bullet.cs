using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
        WaitAndDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 8 && other.gameObject.layer != 10)
        {
            Object.Destroy(gameObject);
        }
    }

    void WaitAndDestroy()
    {
        Object.Destroy(gameObject, 1.5f);
    }
}
