using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GearObj20 : MonoBehaviour
{
    public Gear20 GearScript;
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }
    private void Update()
    {
        transform.position = (Vector2)_cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
