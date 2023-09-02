using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gear20 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _gearPrefab;
    private GameObject _go;
    private Button _button;
    private void Start()
    {
        _button = GetComponent<Button>();
    }
    private void Update()
    {
        
    }
    public void OnMouseRealesed()
    {
        GameManager.Instance.CheckDistance(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        gameObject.SetActive(true);
        Destroy(_go);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("fagahg");
        _go = Instantiate(_gearPrefab, Input.mousePosition, Quaternion.identity);
        _go.GetComponent<GearObj20>().GearScript = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(_go);
        if (GameManager.Instance.CheckDistance(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            this.enabled = false;
        
    }
}
