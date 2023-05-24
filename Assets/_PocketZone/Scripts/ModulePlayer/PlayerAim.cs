using System.Collections.Generic;
using _PocketZone.Scripts.ModuleEnemies;
using _PocketZone.Scripts.ModuleItems;
using UnityEngine;

namespace _PocketZone.Scripts.ModulePlayer
{
    public class PlayerAim : MonoBehaviour
    {
        private List<Enemy> _trackedEnemies;

        public Vector3 EnemyPosition { get; private set; }
        public bool HasTarget { get; private set; }

        private void Start()
        {
            _trackedEnemies = new List<Enemy>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Enemy enemy))
            {
                _trackedEnemies.Add(enemy);

                if (HasTarget == false)
                {
                    HasTarget = true;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (HasTarget)
            {
                EnemyPosition = _trackedEnemies[0].transform.position;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Enemy enemy))
            {
                for (int i = 0; i < _trackedEnemies.Count; i++)
                {
                    if (_trackedEnemies[i].Id == enemy.Id)
                    {
                        _trackedEnemies.RemoveAt(i);
                        
                        if (_trackedEnemies.Count <= 0)
                        {
                            HasTarget = false;
                        }
                    }
                }
            }
        }
    }
}