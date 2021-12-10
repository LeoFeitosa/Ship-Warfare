using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class EnemyMoveUpDownController : MonoBehaviour
{
    [SerializeField] float speed = 0.04f;
    [SerializeField] int startPosition = 6;
    [SerializeField] bool invert = false;
    [SerializeField] float distanceHitRaycast = 3f;
    bool respawnBehindThePlayer = false;
    bool respawnFromBelow = false;
    public bool IsInvert { get; private set; }
    Vector2 direction;
    MainHUD mainHUD;
    PlayerController playerController;

    void Start()
    {
        GameObject mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();

        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        transform.position = Vector3.zero;

        IsInvert = invert;

        if (IsInvert)
        {
            DirectionDown();
        }
        else
        {
            DirectionUp();
        }
    }

    void Update()
    {
        CheckTheRespawnBehindThePlayer();
        Move();
    }

    void DirectionDown()
    {
        transform.position = new Vector3(RandomPositionX(), transform.position.y - startPosition, transform.position.z);
        direction = Vector2.up;

        respawnFromBelow = true;

        if (respawnBehindThePlayer)
        {
            respawnBehindThePlayer = false;
            DirectionDown();
        }
    }

    void DirectionUp()
    {
        transform.position = new Vector3(RandomPositionX(), transform.position.y + startPosition, transform.position.z);
        direction = Vector2.down;
    }

    void CheckTheRespawnBehindThePlayer()
    {
        if (respawnFromBelow)
        {
            Vector2 startPosition = (Vector2)transform.position + new Vector2(0, 0.3f);
            int layerMask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.up, distanceHitRaycast, layerMask, 0);

            Debug.DrawRay(startPosition, Vector2.up * distanceHitRaycast, Color.green);

            if (hit && hit.transform.name == "Player")
            {
                Debug.Log(hit.transform.name);
                respawnBehindThePlayer = true;
            }
        }
    }

    void Move()
    {
        if (!mainHUD.IsCountSeconds)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    float RandomPositionX()
    {
        return Random.Range(-playerController.LimitsMove.x, playerController.LimitsMove.x);
    }
}
