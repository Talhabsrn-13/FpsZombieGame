using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] float _distance = 100f;
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] Camera _camera;
        [SerializeField] LayerMask _layerMask;


        float _currentTime;

        void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;

            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2);

            if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            
            _currentTime = 0;

        }
    }

}
