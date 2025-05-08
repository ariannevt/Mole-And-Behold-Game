using System.Diagnostics;
using UnityEngine;

public class Hola : MonoBehaviour, IInteractable
{
    public ChangeScene targetScript;

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    public void Interact_LabSafety()
    {
        targetScript.Change_To_LabSafety();
    }

    public void Interact_MixAndMatch()
    {
        targetScript.Change_To_MixAndMatch();
    }

    public void Interact_Reaction()
    {
        targetScript.Change_To_Reaction();
    }
}
