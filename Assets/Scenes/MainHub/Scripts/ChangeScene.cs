using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change_To_LabSafety()
    {
        SceneManager.LoadScene("MixAndMatch", LoadSceneMode.Single);
    }   
}
