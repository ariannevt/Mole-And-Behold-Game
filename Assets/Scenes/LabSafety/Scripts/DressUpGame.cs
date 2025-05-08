using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DressUpGame : MonoBehaviour
{
    [Header("Clothing Display (UI Images)")]
    public UnityEngine.UI.Image glassesImage;
    public UnityEngine.UI.Image coatImage;
    public UnityEngine.UI.Image glovesImage;
    public UnityEngine.UI.Image shoesImage;

    [Header("Correct Lab Safety Sprites")]
    public Sprite labGlasses;
    public Sprite labCoat;
    public Sprite labGloves;
    public Sprite labShoes;

    [Header("All Options (arrays must match button order)")]
    public Sprite[] glassesOptions; // e.g. [0]=random, [1]=random, [2]=lab
    public Sprite[] coatOptions;    // same ordering
    public Sprite[] glovesOptions;  // ...
    public Sprite[] shoesOptions;   // ...

    [Header("Result Text")]
    public UnityEngine.UI.Text resultText;
    
    // Starting.
    void Start()
    {
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
    }

    // Called by your Glasses buttons:
    public void SelectGlasses(int index)
    {
        var go = glassesImage.gameObject;
        go.SetActive(true);                  // turn the Image back on
        glassesImage.sprite = glassesOptions[index];
        CheckIfCorrect();
    }

    // Called by your Coat buttons:
    public void SelectCoat(int index)
    {
        var go = coatImage.gameObject;
        go.SetActive(true);
        coatImage.sprite = coatOptions[index];
        CheckIfCorrect();
    }

    // Called by your Gloves buttons:
    public void SelectGloves(int index)
    {
        var go = glovesImage.gameObject;
        go.SetActive(true);
        glovesImage.sprite = glovesOptions[index];
        CheckIfCorrect();
    }

    // Called by your Shoes buttons:
    public void SelectShoes(int index)
    {
        var go = shoesImage.gameObject;
        go.SetActive(true);
        shoesImage.sprite = shoesOptions[index];
        CheckIfCorrect();
    }

    private void CheckIfCorrect()
    {
        if (glassesImage.sprite == labGlasses
           && coatImage.sprite == labCoat
           && glovesImage.sprite == labGloves
           && shoesImage.sprite == labShoes)
        {
            resultText.text = "Good job!";
<<<<<<< Updated upstream
=======
            SceneManager.LoadScene("MainHub", LoadSceneMode.Single);

>>>>>>> Stashed changes
        }
        else
        {
            resultText.text = "";
        }
    }
}
