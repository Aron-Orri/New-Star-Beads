using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private bool canDrag = true;
    private Vector2 save, saveAnchor;
    private bool canSpawn;
    public GameObject objectToSpawn;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canDrag = true;
        canSpawn = false;
        canvasGroup.blocksRaycasts = true;
        save = gameObject.transform.position;
        saveAnchor = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        if (canSpawn)
        {
            Spawn();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag) 
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    public void cantDragg()
    {
        canDrag = false;
    }

    public void Spawn()
    {
        GameObject clone = Instantiate(objectToSpawn, save, Quaternion.identity);
        clone.transform.SetParent(gameObject.transform.parent, true);
        clone.GetComponent<RectTransform>().anchoredPosition = saveAnchor;
        clone.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        canSpawn = false;
    }

    public void ableSpawn()
    { 
        canSpawn = true;
    }
}
