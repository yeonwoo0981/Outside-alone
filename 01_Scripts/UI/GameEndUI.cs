using DG.Tweening;
using Member.SYW._01_Scripts.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    enum Grade
    {
        SSS,
        SS,
        S,
        AAA,
        AA,
        A,
        B,
        C,
        D,
        F
    }
    
    public class GameEndUI : MonoSingleton<GameEndUI>
    {
        [Header("References")]
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gradeText;
        [SerializeField] private Button[] buttons;

        [Header("Grade Settings (점수 커트라인 설정)")] 
        [SerializeField] private int scoreSSS = 10000;
        [SerializeField] private int scoreSS = 9750;
        [SerializeField] private int scoreS = 9500;
        [SerializeField] private int scoreAAA = 9000;
        [SerializeField] private int scoreAA = 8000;
        [SerializeField] private int scoreA = 7000;
        [SerializeField] private int scoreB = 5000;
        [SerializeField] private int scoreC = 3500;
        [SerializeField] private int scoreD = 1000;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(gradeText.DOFade(1f, 0.5f)).SetUpdate(true);
            sequence.AppendInterval(0.5f).SetUpdate(true);
            foreach (Button button in buttons)
            {
                sequence.Append(button.image.DOFade(1f, 0.5f)).SetUpdate(true);
            }
            
            if (scoreManager != null)
            {
                int finalScore = scoreManager.GetScore();
                
                scoreText.text = $"최종 점수: {finalScore}점";
                Grade userGrade = CalculateGrade(finalScore);
                gradeText.text = $"등급: {userGrade}";
                
                SetGradeColor(userGrade);
            }
        }

        private Grade CalculateGrade(int score)
        {
            if (score >= scoreSSS) return Grade.SSS;
            if (score >= scoreSS) return Grade.SS;
            if (score >= scoreS) return Grade.S;
            if (score >= scoreAAA) return Grade.AAA;
            if (score >= scoreAA) return Grade.AA;
            if (score >= scoreA) return Grade.A;
            if (score >= scoreB) return Grade.B;
            if (score >= scoreC) return Grade.C;
            if (score >= scoreD) return Grade.D;
            
            return Grade.F;
        }
        
        private void SetGradeColor(Grade grade)
        {
            switch (grade)
            {
                case Grade.SSS: gradeText.color = Color.cyan; break;
                case Grade.SS: gradeText.color = Color.yellow; break;
                case Grade.S: gradeText.color = Color.yellow; break;
                case Grade.A: gradeText.color = Color.blue; break;
                case Grade.B: gradeText.color = Color.blue; break;
                case Grade.C: gradeText.color = Color.green; break;
                case Grade.D: gradeText.color = Color.gray; break;
                case Grade.F: gradeText.color = Color.red; break;
            }
        }
    }
}