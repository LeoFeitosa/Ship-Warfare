using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShotsController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] bool inverse = false;

    void Awake()
    {
        InvertY();
    }

    void FixedUpdate()
    {
        Shot();
    }

    void Shot()
    {
        if (inverse)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    void InvertY()
    {
        if (inverse)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
