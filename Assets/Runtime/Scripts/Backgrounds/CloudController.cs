using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] float speed = 0.04f;
    [SerializeField] int startPosition = 6;
    [SerializeField] bool randomFlipXY = false;
    float timeToRespawn = 0;
    [SerializeField] SpriteRenderer[] render;
    bool checkInstantiate = false;
    int indexSprite = 0;
    GameObject instanceBackground;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + startPosition, transform.position.z);
        RandomSprite();
    }

    void FixedUpdate()
    {
        MoveDown();
        InstantiateBackground();
        DestroyInstanceBackground();
    }

    void RandomSprite()
    {
        int sizeArrayRender = render.Length;
        indexSprite = Random.Range(0, sizeArrayRender);

        for (int i = 0; i < sizeArrayRender; i++)
        {
            render[i].enabled = true;

            if (indexSprite == i)
            {
                render[i].enabled = false;
            }
        }
    }

    void MoveDown()
    {
        timeToRespawn += Time.fixedDeltaTime;

        if (timeToRespawn >= startPosition)
        {
            transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
        }
    }

    void InstantiateBackground()
    {
        if (!checkInstantiate)
        {
            if (transform.position.y <= -startPosition)
            {
                checkInstantiate = true;
                instanceBackground = Instantiate(this.gameObject);
                instanceBackground.transform.position = new Vector3(transform.position.x, transform.position.y + startPosition, transform.position.z);

                if (randomFlipXY)
                {
                    SpriteRenderer instanceRenderer = instanceBackground.GetComponentInChildren<SpriteRenderer>();
                    if (instanceRenderer != null)
                    {
                        if (RandBool())
                        {
                            instanceRenderer.flipX = !instanceRenderer.flipX;
                        }

                        if (RandBool())
                        {
                            instanceRenderer.flipY = !instanceRenderer.flipY;
                        }
                    }
                }
            }
        }
    }

    void DestroyInstanceBackground()
    {
        if (transform.position.y <= -startPosition)
        {
            Destroy(this.gameObject);
        }
    }

    bool RandBool()
    {
        float rand = Random.Range(0, 100);
        return (rand < 50) ? true : false;
    }
}
