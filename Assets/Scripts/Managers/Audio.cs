using UnityEngine;

namespace Managers
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceSounds;
        [SerializeField] private AudioSource audioSourceMusic;

        [Space(30)]
        public AudioClip clickSound;

        private void Awake() => UpdateStates();


        public void PlaySound(AudioClip audioClip) => audioSourceSounds.PlayOneShot(audioClip);

        public void UpdateStates()
        {
            audioSourceSounds.volume = Datas.Datas.Sound ? 1 : 0;

            audioSourceMusic.volume = Datas.Datas.Music ? 1 : 0;
        }
        
    }
}

