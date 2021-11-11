using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneController : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneController.Instance.LoadScene(name);
    }
}
