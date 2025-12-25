using Member.KYM.Code.Agent;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class BossHealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSystem healthSystem;
        private Slider _hpBar;

        private void Awake()
        {
            _hpBar = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            healthSystem.OnDead += BossDieBar;
        }

        private void Start()
        {
            _hpBar.maxValue = 1f;
        }

        private void Update()
        {
            double value = healthSystem.Health / healthSystem.MaxHealth;

            _hpBar.value = (float)value;
        }

        private void BossDieBar()
        {
            Destroy(gameObject);
        }
        
        private void OnDisable()
        {
            healthSystem.OnDead -= BossDieBar;
        }
    }
}