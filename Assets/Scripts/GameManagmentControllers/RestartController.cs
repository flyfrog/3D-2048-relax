using UnityEngine.SceneManagement;

namespace GameManagmentControllers
{
    public class RestartController
    {
        public void RestartScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}