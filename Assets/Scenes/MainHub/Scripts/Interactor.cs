//With help of the following video: https://www.youtube.com/watch?v=K06lVKiY-sY
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

interface IInteractable
{
    public void Interact_LabSafety();
    public void Interact_MixAndMatch();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    if(hitInfo.collider.gameObject.tag == "MixAndMatch")
                    {
                        interactObj.Interact_MixAndMatch();
                    }
                    if (hitInfo.collider.gameObject.tag == "LabSafety")
                    {
                        interactObj.Interact_LabSafety();
                    }
                    
                }
            }
        }
    }
}
