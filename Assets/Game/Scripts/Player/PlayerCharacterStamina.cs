using UnityEngine;

public class PlayerCharacterStamina : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterMovement _characterMovement;

    [SerializeField]
    private float _maxStamina = 100;
    [SerializeField]
    private float _sprintStaminaCost = 20;
    [SerializeField]
    private float _staminaRegenValue = 20;

    private float _currentStamina;    


    private void Awake()
    {
        _currentStamina = _maxStamina;
    }

    private void Update()
    {
        CalculateStamina();
    }

    private void CalculateStamina()
    {
        if (_characterMovement.IsSprint)
        {
            if(_currentStamina > 0)
            {
                _currentStamina = _currentStamina - _sprintStaminaCost * Time.deltaTime;
            }
            else
            {
                _characterMovement.SetSprint(false);
            }
        }
        else
        {
            _currentStamina = _currentStamina + _staminaRegenValue * Time.deltaTime;
        }
        _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxStamina);
    }


}
