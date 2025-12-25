using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.KYM.Code.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class AmmoUI : MonoBehaviour
    {
        private Gun _gun;
        private Slider _slider;
        private TextMeshProUGUI _ammoText;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _ammoText = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        private void OnEnable()
        {
            EventBus<AmmoReturnEvent>.OnEvent += ChangeAmmoUI;
        }
        
        private void ChangeAmmoUI(AmmoReturnEvent evt)
        {
            _slider.value = evt.Ammo;
            _ammoText.text = evt.Ammo.ToString();
        }
        
        private void OnDisable()
        {
            EventBus<AmmoReturnEvent>.OnEvent -= ChangeAmmoUI;
        }
    }
}