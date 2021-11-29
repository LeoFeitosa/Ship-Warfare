using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDownController : MonoBehaviour
{
    [SerializeField] float speed = 0.04f;
    [SerializeField] int startPosition = 6;
    [SerializeField] bool invert = false;
    public bool IsInvert { get; private set; }

    Vector2 direction;
    GameObject mainHUDObject;
    MainHUD mainHUD;
    GameObject player;
    PlayerController playerController;

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        transform.position = Vector3.zero;

        IsInvert = invert;

        if (IsInvert)
        {
            transform.position = new Vector3(RandomPositionX(), transform.position.y - startPosition, transform.position.z);
            direction = Vector2.up;
        }
        else
        {
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
        return Random.Range(-playerController.LimitsMove.x, playerController.LimitsMove.x);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
