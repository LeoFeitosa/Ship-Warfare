using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputController : MonoBehaviour
{
    public Vector3 Movements()
    {
        if (!enabled)
        {
            return Vector3.zero;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                horizontal = pos.x > 0 ? 1 : -1;
                vertical = pos.y > 0 ? 1 : -1;
            }
        }

        return new Vector3(horizontal, vertical, transform.position.z);
    }

    public bool Shoot()
    {
        if (!enabled)
        {
            return false;
        }

        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            return true;
        }
        return false;
    }
}
