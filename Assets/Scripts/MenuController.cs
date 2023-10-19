using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void SelectLevel1() {
        SceneManager.LoadScene("Level1");
    }

    public void SelectLevel2() {
        SceneManager.LoadScene("Level2");
    }

     public void Quit() {
        Application.Quit(0);
    }
}
