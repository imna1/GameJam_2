using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever4 : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.TurnOnLewer();
    }
}
