using Project3.Abstract.Movements;
using Project3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project3.Movements
{
    public class RotatorY : IRotator
    {
        Transform _transform;
        float _tilt;
        public RotatorY(PlayerController playerController)
        {
            _transform = playerController.TurnTransform;
        }
        public void RotationAction(float direction, float speed)
        {
            direction *= speed  * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30f, 30f);
            _transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);
        }
    }

}
