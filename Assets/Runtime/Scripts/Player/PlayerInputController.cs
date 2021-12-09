using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputController : MonoBehaviour
{
    Vector3 positionTouch;
    bool touchInput = false;
    bool touchInputMove = false;

    public Vector3 MovementsKeyboard()
    {
        if (!enabled)
        {
            return Vector3.zero;
        }

        if (Input.anyKey)
        {
            touchInput = false;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, vertical, transform.position.z);
    }

    public Vector3 MovementsTouch()
    {
        if (!enabled)
        {
            return Vector3.zero;
        }

        if (Input.touchCount > 0)
        {
            touchInput = true;
            Touch touch = Input.GetTouch(0);
            positionTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
                touchInputMove = true;
            }
            else
            {
                touchInputMove = false;
            }
        }
        else
        {
            touchInputMove = false;
        }

        positionTouch.z = transform.position.z;
        return positionTouch;
    }

    public bool TouchOnTheMove()
    {
        return touchInputMove;
    }

    public bool IsTouch()
    {
        return touchInput;
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
