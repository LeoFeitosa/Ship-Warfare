using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotsController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void FixedUpdate()
    {
        Shot();
    }

    void Shot()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
