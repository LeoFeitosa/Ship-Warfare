using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 Movements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, vertical, transform.position.z);
    }

    public bool Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
}
