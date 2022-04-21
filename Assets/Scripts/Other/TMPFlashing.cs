using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPFlashing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmpText;
    [SerializeField][Range(0,1)] float speed;

    Color colorOriginal;

    private void Awake() => colorOriginal = tmpText.color;

    private void Update()
    {
        colorOriginal.a = Mathf.PingPong(Time.time * speed, 1);

        tmpText.color = colorOriginal;
    }
}
