using UnityEngine;

namespace _GAME.Characters
{
    public class CharacterMoveLogic : MonoBehaviour
    {
        private CharactersFeature _charactersFeature;
        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
        }

        private void Update()
        {
            float horizontalInput = _charactersFeature.characterPrefab.joystick.Horizontal;
            float verticalInput = _charactersFeature.characterPrefab.joystick.Vertical;

            Vector3 movementDirection = new Vector3(
                horizontalInput * _charactersFeature.settings.playerSpeed * Time.deltaTime,
                _charactersFeature.characterPrefab.rigidbody.velocity.y,
                verticalInput * _charactersFeature.settings.playerSpeed * Time.deltaTime);
            movementDirection.Normalize();
            
            _charactersFeature.characterPrefab.rigidbody.velocity = movementDirection;

            if (movementDirection != Vector3.zero)
            {
                _charactersFeature.characterPrefab.rigidbody.transform.forward = movementDirection;
                _charactersFeature.characterPrefab.animator.SetBool(IsRunning, true);
            }
            else
            {
                _charactersFeature.characterPrefab.animator.SetBool(IsRunning, false);
            }
        }
    }
}