using System;
using Sound;
using UnityEngine;
using Zenject;

namespace SaveAndLoad
{
    public class SaveManager
    {
        private AudioMixerController _audioMixerController;

        [Inject]
        public SaveManager(AudioMixerController audioMixerControllerArg)
        {
            _audioMixerController = audioMixerControllerArg;
            _audioMixerController.OnChangedMuteState += SaveSettings;
        }
        

        public void SaveSettings()
        {
       
            DataSettings settingsForSave = new DataSettings();
            settingsForSave.soundMuteState = _audioMixerController.GetMuteState();
            SaveData(settingsForSave);
        }

        private void SaveData(DataSettings dictionaryArg)
        {
            String JSONstringForSave = JsonUtility.ToJson(dictionaryArg);
            SaveDataValueByType("gameSave", JSONstringForSave);
        }

        public void SaveDataValueByType(String key, String valueArg)
        {
            PlayerPrefs.SetString(key, valueArg);
        }
    }
}