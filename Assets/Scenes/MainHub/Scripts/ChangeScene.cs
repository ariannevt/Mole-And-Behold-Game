using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change_To_MixAndMatch()
    {
        SceneManager.LoadScene("MixAndMatch", LoadSceneMode.Single);
    }

    public void Change_To_LabSafety()
    {
        SceneManager.LoadScene("LabSafety", LoadSceneMode.Single);
    }

    public void Change_To_Reaction()
    {
        SceneManager.LoadScene("Reaction", LoadSceneMode.Single);
    }

    public void Change_To_MainHub()
    {
        SceneManager.LoadScene("MainHub", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
