using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDownController : MonoBehaviour
{
    [SerializeField] float speed = 0.04f;
    [SerializeField] int startPosition = 6;
    [SerializeField] bool invert = false;
    Vector2 direction;
    GameObject mainHUDObject;
    MainHUD mainHUD;

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        transform.position = Vector3.zero;

        if (invert)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - startPosition, transform.position.z);
            direction = Vector2.up;
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + startPosition, transform.position.z);
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
}
