//Done with help of the following video: https://www.youtube.com/playlist?list=PLZhNP5qJ2IA2DA4bzDyxFMs8yogVQSrjW

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;
    
    [SerializeField]
    private GameObject btn;

    void Awake(){
        for(int i=0; i<8; i++){
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }
    }
} //AddButtons
