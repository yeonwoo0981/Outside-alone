using System;
using Member.SYW._01_Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Member.SYW._01_Scripts.Manager
{
    public class GameUIManager : MonoBehaviour
    {
        private InGameUIHome _inGameUIHome;
        private bool _panelOpen = false;

        public Action OnEscOpen;
        public Action OnEscClose;
        
        private void Awake()
        {
            _inGameUIHome = InGameUIHome.Instance;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                HandleEsc();
        }

        public void ResumeGame()
        {
            if (_panelOpen)
            {
                CloseEscPanel();
            }
        }

        private void HandleEsc()
        {
            if (!_panelOpen)
            {
                OnEscOpen?.Invoke();
                TimeManager.Instance.TimeStop();
                _panelOpen = true;
                print("엉");
            }
            else if (_panelOpen)
            {
                CloseEscPanel();
            }
        }
        
        private void CloseEscPanel()
        {
            OnEscClose?.Invoke();
            TimeManager.Instance.TimeStart();
            _panelOpen = false;
            print("잉");
        }

        public void Restart()
        {
            SceneManager.LoadScene("LobbyScene");
            TimeManager.Instance.TimeStart();
        }
        
        public void GameExit()
        {
            Application.Quit();
        }
    }
}