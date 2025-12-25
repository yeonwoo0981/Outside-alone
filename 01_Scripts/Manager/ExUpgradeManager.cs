using Member.SYW._01_Scripts.UI;
using UnityEngine;

namespace Member.SYW._01_Scripts.Manager
{
    public class ExUpgradeManager : MonoBehaviour
    {
        [SerializeField] private UpgradeUI upgradeUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                upgradeUI.Show();
            }
        }
    }
}