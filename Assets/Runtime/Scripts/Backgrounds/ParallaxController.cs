using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float offset = 1f;
    [SerializeField] bool randomFlipX = false;
    float imageSizeY;
    bool checkInstantiate = false;
    GameObject instanceBackground;

    void Start()
    {
        imageSizeY = GetComponentInChildren<SpriteRenderer>().size.y;
    }

    void FixedUpdate()
    {
        MoveBackground();
        InstantiateBackground();
        DestroyInstanceBackground();
    }

    void MoveBackground()
    {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }

    void InstantiateBackground()
    {
        if (!checkInstantiate)
        {
            if (transform.position.y <= imageSizeY)
            {
                checkInstantiate = true;
                instanceBackground = Instantiate(this.gameObject);
                instanceBackground.transform.position = new Vector3(transform.position.x, transform.position.y + (imageSizeY * 2) + offset, transform.position.z);

                if (randomFlipX)
                {
                    if (RandBool())
                    {
                        SpriteRenderer instanceRenderer = instanceBackground.GetComponentInChildren<SpriteRenderer>();
                        if (instanceRenderer != null)
                        {
                            instanceRenderer.flipX = !instanceRenderer.flipX;
                        }
                    }
                }
            }
        }
    }

    void DestroyInstanceBackground()
    {
        if (transform.position.y <= (imageSizeY * 2) * -1)
        {
            Destroy(this.gameObject);
        }
    }

    bool RandBool()
    {
        return (Random.value < 0.5f) ? true : false;
    }
}
