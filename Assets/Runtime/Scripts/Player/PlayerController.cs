using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInputController input;

    [Header("Invulnerable")]
    [SerializeField] int numberOfBlinks = 8;
    [SerializeField] float timeBetweenColors = 2;

    [Header("Sounds")]
    [SerializeField] AudioClip collisionWithEnemy;
    ShotsTypesController shotsTypes;
    Vector3 moveDirections = Vector3.zero;
    Rigidbody2D rb2D;
    [SerializeField] int numberOfLives = 4;
    public int Lives { get; private set; }
    [SerializeField] float speedMoveNormal = 0.5f;
    [SerializeField] float limitMoveX = 4f;
    [SerializeField] float limitMoveY = 4f;
    public float IsMove { get; private set; }
    public bool IsDead { get; private set; }
    GameObject mainHUDObject;
    MainHUD mainHUD;
    SpriteRenderer spritePlayer;
    bool playerColliderWithEnemy = true;

    void Start()
    {
        mainHUDObject = GameObject.FindWithTag("MainHUD");
        mainHUD = mainHUDObject.GetComponent<MainHUD>();
        spritePlayer = GetComponentInChildren<SpriteRenderer>();

        Lives = numberOfLives;

        input = GetComponent<PlayerInputController>();
        shotsTypes = GetComponent<ShotsTypesController>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!mainHUD.IsCountSeconds)
        {
            Move(input.Movements());

            if (input.Shoot())
            {
                shotsTypes.ShootShot(input.Shoot());
            }

            Die();
        }
    }

    void Move(Vector3 move)
    {
        IsMove = move.x;

        moveDirections += move * speedMoveNormal * Time.fixedDeltaTime;

        moveDirections.x = Mathf.Clamp(moveDirections.x, -limitMoveX, limitMoveX);
        moveDirections.y = Mathf.Clamp(moveDirections.y, -limitMoveY, limitMoveY);

        rb2D.MovePosition(moveDirections);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && playerColliderWithEnemy)
        {
            AudioController.Instance.PlayAudioCue(collisionWithEnemy);
            ShakeScreenController.Instance.ShakeNow();
            Lives--;

            if (Lives > 0)
            {
                StartCoroutine(Invulnerable());
            }
        }

        if (col.CompareTag("Life"))
        {
            if (Lives < numberOfLives)
            {
                Lives++;
            }
        }
    }

    IEnumerator Invulnerable()
    {
        playerColliderWithEnemy = false;
        int loops = numberOfBlinks;

        while (loops >= 0)
        {
            spritePlayer.color = Color.red;
            yield return new WaitForSeconds(timeBetweenColors);
            spritePlayer.color = Color.white;
            yield return new WaitForSeconds(timeBetweenColors);
            loops--;
        }
        playerColliderWithEnemy = true;
    }

    void Die()
    {
        if (Lives == 0)
        {
            playerColliderWithEnemy = false;
            input.enabled = false;
            IsDead = true;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        mainHUD.GameOverActive();
    }
}
