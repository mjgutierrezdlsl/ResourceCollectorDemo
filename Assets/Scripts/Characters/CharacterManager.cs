using System;
using System.Collections;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private CharacterHandler[] _characters;
        private InputSystem_Actions _inputActions;
        private int _activeCharacterIndex;
        private CharacterHandler ActiveCharacter => _characters[ActiveCharacterIndex];

        public int ActiveCharacterIndex
        {
            get => _activeCharacterIndex;
            private set
            {
                _activeCharacterIndex = value;
                OnCharacterChanged?.Invoke(_characters[_activeCharacterIndex]);
            }
        }

        public event Action<CharacterHandler> OnCharacterChanged;

        private void Reset()
        {
            _characters = GetComponentsInChildren<CharacterHandler>();
        }

        private void Awake()
        {
            _inputActions = new();
        }

        private void OnEnable()
        {
            _inputActions.Player.Enable();

            _inputActions.Player.Swap.started += (ctx) =>
            {
                ToggleCharacters();
            };

            _inputActions.Player.Attack.started += (ctx) =>
            {
                StartCoroutine(PlayAttackAnimation());
            };
        }

        private void FixedUpdate()
        {
            ActiveCharacter.MoveCharacter(_inputActions.Player.Move.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _inputActions.Player.Disable();
        }

        public void ToggleCharacters()
        {
            if (ActiveCharacterIndex < _characters.Length - 1)
            {
                ActiveCharacterIndex++;
            }
            else
            {
                ActiveCharacterIndex = 0;
            }

            for (int i = 0; i < _characters.Length - 1; i++)
            {
                _characters[i].gameObject.SetActive(i == ActiveCharacterIndex);
            }

            print($"Active Character is: {_characters[ActiveCharacterIndex]}");
        }

        private IEnumerator PlayAttackAnimation()
        {
            _inputActions.Player.Move.Disable();
            ActiveCharacter.Attack();
            yield return new WaitForSeconds(0.6f);
            _inputActions.Player.Move.Enable();
        }
    }
}
