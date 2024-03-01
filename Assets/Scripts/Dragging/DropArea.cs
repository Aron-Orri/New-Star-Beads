using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    private DragDrop dragDrop;
    public DraggCompletion completion;
    private bool canDrop;

    private void Awake()
    {
        canDrop = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag == tag && canDrop)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
            dragDrop.cantDragg();
            dragDrop.ableSpawn();
            completion.areaCompleted();
            canDrop = false;
        }
    }
}
