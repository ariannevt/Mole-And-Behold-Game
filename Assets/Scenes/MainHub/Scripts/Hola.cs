using System.Diagnostics;
using UnityEngine;

public class Hola : MonoBehaviour, IInteractable
{
    public ChangeScene targetScript;

    public void Interact_LabSafety()
    {
        targetScript.Change_To_LabSafety();
    }

    public void Interact_MixAndMatch()
    {
        targetScript.Change_To_MixAndMatch();
    }
}
