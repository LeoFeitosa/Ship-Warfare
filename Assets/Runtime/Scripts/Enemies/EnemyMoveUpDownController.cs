using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDownController : MonoBehaviour
{
    [SerializeField] float speed = 0.04f;
    [SerializeField] int startPosition = 6;
    [SerializeField] bool invert = false;
    [SerializeField] float xInitial = -2.5f;
    [SerializeField] float xFinal = 2.5f;
    public bool IsInvert { get; private set; }

    Vector2 direction;
    GameObject mainHUDObject;
    MainHUD mainHUD;

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        transform.position = Vector3.zero;

        IsInvert = invert;

        if (IsInvert)
        {
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            transform.position = new Vector3(RandomPositionX(), transform.position.y - startPosition, transform.position.z);
            direction = Vector2.up;
        }
        else
        {
            Debug.Log("subir");
            transform.position = new Vector3(RandomPositionX(), transform.position.y + startPosition, transform.position.z);
            direction = Vector2.down;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (!mainHUD.IsCountSeconds)
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime);
        }
    }

    float RandomPositionX()
    {
        return Random.Range(xInitial, xFinal);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
