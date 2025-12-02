using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickLogger : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("[ButtonClickLogger] Button clicked! pointerId=" + eventData.pointerId +
                  " button=" + eventData.button + " position=" + eventData.position);
    }
}
