using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField]
    private float range;
    
    [SerializeField]
    public Camera mainCamera;

    [SerializeField]
    private LayerMask layerMask;

    public Transform destinasi;

    public Image interactImage;

    public TextMeshProUGUI interactText;

    public GameObject backgroundText, buttonE;

    public Sprite defaultIcon;

    public Vector2 defaultIconSize;

    public Sprite defaultInteractIcon;

    public Vector2 defaultInteractIconSize;

    private ObjectPickup objectPickup;


    private void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * range);

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            var hitObjectInteract = hit.collider.GetComponent<Interactable>();
            InteractableObject io = hit.collider.GetComponent<InteractableObject>();

            if (hit.collider.GetComponent<InteractableObject>() != false)
            {
                if (hitObjectInteract == null || io == null || io.ID != hit.collider.GetComponent<InteractableObject>().ID)
                {
                    io = hit.collider.GetComponent<InteractableObject>();
                }

                if (hitObjectInteract != null || io.interaksiIcon != null)
                {
                    interactImage.sprite = io.interaksiIcon;

                    if (io.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                    }
                    else
                    {
                        interactImage.rectTransform.sizeDelta = io.iconSize;
                    }

                    backgroundText.SetActive(true);
                    buttonE.SetActive(true);

                    interactText.text = io.interaksiTeks;
                    successfulHit = true;

                    if (Input.GetButtonDown("Interact"))
                    {
                        io.onInteract.Invoke();
                        hitObjectInteract.Interact();
                        if (objectPickup == null)
                        {
                            if (hit.transform.TryGetComponent(out objectPickup))
                            {
                                objectPickup.Grab(destinasi);
                            }
                        }
                        else
                        {
                            objectPickup.Drop();
                            objectPickup = null;
                        }
                        
                    }

                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
            }

        }
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
            backgroundText.SetActive(false);
            buttonE.SetActive(false);
        }
        if (!successfulHit)
            interactText.text = "";
    }

    public void Interact()
    {
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            var hitObjectInteract = hit.collider.GetComponent<Interactable>();

            if (objectPickup == null)
            {
                if (hit.transform.TryGetComponent(out objectPickup))
                {
                    objectPickup.Grab(destinasi);
                }
            }
            else
            {
                objectPickup.Drop();
                objectPickup = null;
            }
            hitObjectInteract.Interact();
        }
    }

}
