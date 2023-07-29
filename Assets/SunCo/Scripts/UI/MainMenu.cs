using UnityEngine;
using UnityEngine.SceneManagement;

namespace SunCo.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene(1);
        }
        public void QuitButton()
        {
            Application.Quit();
        }
    }
}
