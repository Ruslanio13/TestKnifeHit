using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New log", menuName = "LogSo")]

public class LogSO : ScriptableObject
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private GameObject _destructLog;
    [SerializeField] private GameObject _log;
    [SerializeField] private int _amountOfBotKnives;
    [SerializeField] private int _amountOfPlayersKnives;
    private bool _isIncreasing = true;

    public IEnumerator ChangeRotateSpeed()
    {
        while (true)
        {
            float _maxSpeed = 200 + _levelNumber * 3;
            while (_rotateSpeed > -_maxSpeed && _isIncreasing)
            {
                _rotateSpeed -= Time.deltaTime * _levelNumber * 10;
                yield return new WaitForEndOfFrame();
            }
            _isIncreasing = false;
            while (_rotateSpeed < _maxSpeed && !_isIncreasing)
            {
                _rotateSpeed += Time.deltaTime * _levelNumber * 10;
                yield return new WaitForEndOfFrame();
            }
            _isIncreasing = true;
            yield return new WaitForSeconds(_levelNumber % 5);
        }
    }

    public void StartDesctruct() => Instantiate(_destructLog).transform.position = new Vector2(0, 0);
    public float GetRotateSpeed() => _rotateSpeed;
    public int GetAmountBotKnives() => _amountOfBotKnives;
    public int GetAmountPlayersKnives() => _amountOfPlayersKnives;
}
