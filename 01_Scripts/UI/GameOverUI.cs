using Member.SYW._01_Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class GameOverUI : MonoSingleton<GameOverUI> // 폐기
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);

            if (scoreManager != null)
            {
                int finalScore = scoreManager.GetScore();
                scoreText.text = $"최종 점수: {finalScore}점";
            }
        }
    }
}