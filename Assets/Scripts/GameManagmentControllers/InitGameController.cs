using SaveAndLoad;
using Sound;
using UnityEngine;
using Zenject;

namespace GameManagmentControllers
{
    public class InitGameController: IInitializable
    {
        private LoadManager _loadManager;
        private AudioMixerController _audioMixerController;
        private PauseController _pauseController;

        [Inject]
        public InitGameController(LoadManager loadManagerArg, AudioMixerController audioMixerControllerArg,
            PauseController pauseControllerArg)
        {
            _loadManager = loadManagerArg;
            _audioMixerController = audioMixerControllerArg;
            _pauseController = pauseControllerArg;

        }

        private void SetGameSettingFromSavesData()
        {
            DataSettings settingsFromStorage = _loadManager.GetSavedData();
            _audioMixerController.SetMuteState(settingsFromStorage.soundMuteState);

        }

        public void Initialize()
        {
            _pauseController.PauseOn();
            SetGameSettingFromSavesData();
        }
    }
}