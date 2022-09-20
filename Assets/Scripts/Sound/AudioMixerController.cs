using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class AudioMixerController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        public event Action OnChangedMuteState; 

        private bool _muteState;
        private float _defaultVolume = 0f;
        
        public bool GetMuteState()
        {
            return _muteState;
        }

        public void SwitchMuteState()
        {
            _muteState = !_muteState;
            RealiseOnOrOffMute();
        }
    
        public void SetMuteState(bool muteStatusArg)
        {
            _muteState = muteStatusArg;
            RealiseOnOrOffMute();
        }

        private void RealiseOnOrOffMute()
        {
            OnChangedMuteState?.Invoke();
            if (_muteState)
            {
                SetOnMute();
            }
            else
            {
                SetOffMute();
            }
        }
    
        private void SetOnMute()
        {
            _audioMixer.SetFloat("masterVolume", -80f);
        }

        private void SetOffMute()
        {
            _audioMixer.SetFloat("masterVolume", _defaultVolume);
        }
    }
}