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
    bool typeInput;

    public Vector3 MovementsKeyboard()
    {
        if (!enabled)
        {
            return Vector3.zero;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 && vertical != 0)
        {
            typeInput = false;
        }

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
            typeInput = true;
            Touch touch = Input.GetTouch(0);
            positionTouch = Camera.main.ScreenToWorldPoint(touch.position);
        }

        positionTouch.z = transform.position.z;
        return positionTouch;
    }

    public bool IsTouch()
    {
        return typeInput;
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
