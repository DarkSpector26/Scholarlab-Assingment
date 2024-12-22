using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler , IPointerClickHandler
{
    public AnimalData animalData;

    private Vector3 startPosition;
    private Transform startParent;
    public GameObject DescriptionPanel;
    public TMP_Text descriptionText;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

       
        GameObject target = eventData.pointerEnter;
        if (target != null && target.CompareTag("Bucket"))
        {
            FindObjectOfType<AnimalQuizManager>().AnimalIdentifier(animalData, target);
            Destroy(gameObject);
        }
        else
        {
            transform.position = startPosition; 
        }

       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        DescriptionPanel.SetActive(true);

       
        descriptionText.text = animalData.AnimalDescription;
    }

}
