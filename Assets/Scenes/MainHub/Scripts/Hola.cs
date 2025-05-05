using UnityEngine;

public class Hola : MonoBehaviour, IInteractable
{
    public ChangeScene targetScript;

    public void Interact()
    {
        Debug.Log("Hola Arianne :)");
        targetScript.Change_To_LabSafety();
    }
}
