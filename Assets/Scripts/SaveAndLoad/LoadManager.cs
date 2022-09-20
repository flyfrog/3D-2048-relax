using System;
using UnityEngine;

namespace SaveAndLoad
{
    public class LoadManager
    {
        private DataSettings _savedDataSettings;
    
        public LoadManager()
        {
            LoadDataFromPrefs();
        }
    
        private void LoadDataFromPrefs()
        {
            String saveJSONString = PlayerPrefs.GetString("gameSave", "none");

            if (saveJSONString != "none")
            {
                _savedDataSettings = JsonUtility.FromJson<DataSettings>(saveJSONString);
            }
            else
            {
                _savedDataSettings = new DataSettings();
            }
        }

        public DataSettings GetSavedData()
        {
            return _savedDataSettings;
        }
    }
}