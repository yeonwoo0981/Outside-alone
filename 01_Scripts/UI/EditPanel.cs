using DG.Tweening;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class EditPanel : MonoSingleton<EditPanel>
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Button closeButton;
        [SerializeField] private AudioMixer audioMixer;
        
        private const string MasterParam = "Master";
        private const string BGMParam = "BGM";
        private const string SFXParam = "SFX";
        
        private void Start()
        {
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
            
            closeButton.onClick.AddListener(ClosePanel);
            
            InitVolume();
            
            gameObject.SetActive(false);
        }
        
        private void InitVolume()
        {
            float masterVol = PlayerPrefs.GetFloat(MasterParam, 1f);
            float bgmVol = PlayerPrefs.GetFloat(BGMParam, 1f);
            float sfxVol = PlayerPrefs.GetFloat(SFXParam, 1f);
            
            masterSlider.value = masterVol;
            bgmSlider.value = bgmVol;
            sfxSlider.value = sfxVol;
        }
        
        public void SetMasterVolume(float value)
        {
            SetVolume(MasterParam, value);
            PlayerPrefs.SetFloat(MasterParam, value);
        }

        public void SetBGMVolume(float value)
        {
            SetVolume(BGMParam, value);
            PlayerPrefs.SetFloat(BGMParam, value);
        }

        public void SetSFXVolume(float value)
        {
            SetVolume(SFXParam, value);
            PlayerPrefs.SetFloat(SFXParam, value);
        }
        
        private void SetVolume(string parameterName, float sliderValue)
        {
            float volume = sliderValue <= 0.0001f ? -80f : Mathf.Log10(sliderValue) * 20;
            
            audioMixer.SetFloat(parameterName, volume);
        }
        
        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            closeButton.DOKill();
            
            PlayerPrefs.Save();
        }
    }
}