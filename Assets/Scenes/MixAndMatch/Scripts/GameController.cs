//https://www.youtube.com/watch?v=qS8c_6dycDc&list=PLZhNP5qJ2IA2DA4bzDyxFMs8yogVQSrjW&index=3
//https://www.youtube.com/watch?v=4HjHg2B6D9E&list=PLZhNP5qJ2IA2DA4bzDyxFMs8yogVQSrjW&index=6
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    void Awake() {
        puzzles = Resources.LoadAll<Sprite>("Sprites/chsprites");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i=0; i<objects.Length; i++){
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles() {
        int looper = btns.Count;
        int index = 0;

        for(int i=0; i<looper; i++){
            if(index == looper / 2) {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);

            index++;
        }
    }

    void AddListeners(){
        foreach (Button btn in btns){
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle() {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("You Are Clicking A Button named " + name);

        if(!firstGuess){
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        } else if(!secondGuess){
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzleMatch());
            /*   if (firstGuessPuzzle == secondGuessPuzzle){
                Debug.Log("The Puzzles Match.");
            } else {
                Debug.Log("The Puzzles Don't match.");
            } */
        }
    }
    IEnumerator CheckIfThePuzzleMatch() {
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == secondGuessPuzzle){
            yield return new WaitForSeconds (.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);
            
            CheckIfTheGameIsFinished();
        } else {

            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);
        firstGuess = secondGuess = false;
    }
    void CheckIfTheGameIsFinished() {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses){
            Debug.Log("Game Finished");
            Debug.Log("It took you " + countGuesses + " many guess(es) to finish the game");
            SceneManager.LoadScene("MainHub", LoadSceneMode.Single);
        }
    }

    void Shuffle(List<Sprite> list){
        for(int i = 0; i<list.Count; i++){
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);  
            list[i] = list[randomIndex];
            list[randomIndex] = temp;      
        }
    }
}