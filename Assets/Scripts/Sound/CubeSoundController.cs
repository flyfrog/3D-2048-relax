using UnityEngine;
using Random = UnityEngine.Random;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class CubeSoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _audioHit;
        [SerializeField] private float _porogSoundForce = 30;
        [SerializeField] private AudioClip _boom;
        [SerializeField] private AudioClip _pop;
        [SerializeField] private AudioClip _slide;
        [SerializeField] private AudioClip _spawn;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySoundHit(Collision collision)
        {
            float impulse = collision.impulse.magnitude / Time.fixedDeltaTime;

            if (impulse < _porogSoundForce)
                return;

            float normalizedImpulse = Mathf.InverseLerp(_porogSoundForce, 1000, impulse);
            float volome = normalizedImpulse;
            float pitch = Mathf.Lerp(0.8f, 1.1f, normalizedImpulse);

            _audioSource.pitch = pitch;

            int randomClip = Random.Range(0, _audioHit.Length);
            _audioSource.PlayOneShot(_audioHit[randomClip]);
        }


        public void PlayBoom()
        {
            _audioSource.PlayOneShot(_boom);
            _audioSource.PlayOneShot(_pop);
        }

        public void PlaySlide()
        {
            _audioSource.PlayOneShot(_slide);
        }

        public void PlaySpawn()
        {
            _audioSource.PlayOneShot(_spawn);
        }
    }
}