using _PocketZone.Scripts.ModuleMap;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleUtilities
{
    public class CharacterMovement
    {
        private Map _map;
        
        public CharacterMovement(Map map)
        {
            _map = map;
        }
        
        public void Move(Rigidbody2D rigidbody, Vector2 direction, float moveSpeed, float deltaTime,
            bool isRestricted = false)
        {
            if (direction != Vector2.zero)
            {
                if (isRestricted)
                {
                    RestrictMovement(rigidbody.transform);
                }
                
                float stepValue = moveSpeed * deltaTime;
                rigidbody.MovePosition(rigidbody.position + direction * stepValue);
            }
        }

        public void Rotate(Transform characterTransform, float horizontalDirectionValue)
        {
            var yAxisValue = characterTransform.eulerAngles.y;
            
            if (yAxisValue == 0 && horizontalDirectionValue < 0)
            {
                characterTransform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(yAxisValue >= 180 && horizontalDirectionValue > 0)
            {
                characterTransform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
        public void Rotate(Transform characterTransform, Vector3 enemyPosition)
        {
            var yAxisValue = characterTransform.eulerAngles.y;
            var characterPosition = characterTransform.position;
            
            if (yAxisValue == 0 && enemyPosition.x < characterPosition.x)
            {
                characterTransform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(yAxisValue >= 180 && enemyPosition.x > characterPosition.x)
            {
                characterTransform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
        private void RestrictMovement(Transform restrictedTransform)
        {
            Vector2 clampedPosition = restrictedTransform.position;
            
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_map.HorizontalLimit, _map.HorizontalLimit);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -_map.VerticalLimit, _map.VerticalLimit);

            restrictedTransform.position = clampedPosition;
        }
    }
}