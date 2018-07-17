using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public static int count;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        count = 0;
    }

    void Update()
    {
        text.text = "Count: " + count;
    }
}
