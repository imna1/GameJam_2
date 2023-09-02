using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField] private float maxScreenPoint = 0.2f;
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);
        Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;
        Vector3 destination = new Vector3(position.x, position.y, -10);

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 2, 39), Mathf.Clamp(transform.position.y, 1.5f, 26.5f), transform.position.z);
    }
}
