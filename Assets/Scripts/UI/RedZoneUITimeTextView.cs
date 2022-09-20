using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RedZoneUITimeTextView : MonoBehaviour
    {
        [SerializeField] private Text _timerText;

        public void DrawText(float timeLostToGameOverArg)
        {
            int timeClamp = Mathf.RoundToInt(timeLostToGameOverArg);
            string difTimeText = timeClamp.ToString();
            _timerText.text = difTimeText;
        }
    

        public void HideText()
        {
            _timerText.gameObject.SetActive(false);
        }
    
        public void ShowText()
        {
            _timerText.gameObject.SetActive(true);
        }
    
    }
}
