using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HankingController : MonoBehaviour
{
    [SerializeField] GameObject rowUI;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponentsInChildren<TextMeshProUGUI>();
            row[0].text = (i + 1).ToString();
            row[1].text = Random.Range(0, 9999).ToString();
            row[2].text = Random.Range(0, 9999).ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
