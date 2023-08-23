using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(GraphicRaycaster))]
public class CanvasHitDetector : MonoBehaviour
{
    private GraphicRaycaster _graphicRaycaster;

    private void Start()
    {_graphicRaycaster = GetComponent<GraphicRaycaster>();
    }

    public bool IsPointerOverUI()
    {
        var pointerPosition = Touchscreen.current.position.ReadValue();

        var pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = pointerPosition
        };

        var results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(pointerEventData, results);
        return results.Count > 0;
    }
}
