using UnityEditor;
using UnityEngine;

namespace GameManagmentControllers
{
    public class ExitController
    {
        public void ExitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}