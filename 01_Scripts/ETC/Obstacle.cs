using System.Collections;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;

namespace Member.SYW._01_Scripts.ETC
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Obstacle : MonoBehaviour, IPoolable
    {
        [SerializeField] protected float lifeTime = 5f;
        [SerializeField] protected float speed = 5f;
        private Rigidbody2D _rb;
        
        public string ItemName => gameObject.name;
        public GameObject GetGameObject()
        {
            return gameObject;
        }
        
        public void Reset()
        {
            if(_rb != null) _rb.linearVelocity = Vector2.zero;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartCoroutine(LifeCoroutine());
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = Vector2.left * speed;
        }
        
        private IEnumerator LifeCoroutine()
        {
            yield return new WaitForSeconds(lifeTime);
            PoolManager.Instance.Push(this);
        }
    }
}