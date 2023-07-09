using CodeBase.Events;
using TMPro;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyCounter : MonoBehaviour
    {
        public TextMeshProUGUI Counter;
        
        private void Awake()
        {
            EventBus.Instance.EnemyDied += UpdateCounter;
        }

        private void OnDestroy()
        {
            EventBus.Instance.EnemyDied -= UpdateCounter;
        }

        private void Start()
        {
            UpdateCounter();
        }

        private void UpdateCounter()
        {
            Counter.text = $"{EnemyCounterData.CountOfKilled}";
        }
    }
}
