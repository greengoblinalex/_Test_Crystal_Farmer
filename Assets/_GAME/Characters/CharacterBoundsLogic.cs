using UnityEngine;

namespace _GAME.Characters
{
    public class CharacterBoundsLogic: MonoBehaviour
    {
        private CharactersFeature _charactersFeature;

        private Vector3 _screenBounds;
        private float _objectWidth;
        private float _objectHeight;
        
        private void Awake()
        {
            _charactersFeature = FindObjectOfType<CharactersFeature>();
        }

        void Start()
        {
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            // _objectWidth = _charactersFeature.characterPrefab.meshRenderer.bounds.size.x;
            _objectHeight = _charactersFeature.characterPrefab.meshRenderer.bounds.extents.y;
        }

        void LateUpdate()
        {
            Vector3 viewPos = _charactersFeature.characterPrefab.rigidbody.transform.position;
            // viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x + _objectWidth, _screenBounds.x * -1 - _objectWidth);
            viewPos.z = Mathf.Clamp(viewPos.z, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);
            _charactersFeature.characterPrefab.rigidbody.transform.position = viewPos;
        }
    }
}