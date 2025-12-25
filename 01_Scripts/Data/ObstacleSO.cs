using Member.SYW._01_Scripts.ETC;
using UnityEngine;

namespace Member.SYW._01_Scripts.Data
{
    [CreateAssetMenu(fileName = "ObstacleSO", menuName = "YeonSO/ObstacleSO")]
    public class ObstacleSO : ScriptableObject
    {
        [field:SerializeField] public Obstacle Obstacle { get; set; }
    }
}
