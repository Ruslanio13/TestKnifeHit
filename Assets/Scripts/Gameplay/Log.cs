using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    [SerializeField] private List<LogSO> _levelNumbers = new List<LogSO>();
    [SerializeField] private List<GameObject> _apples = new List<GameObject>();
    [SerializeField] private List<GameObject> _knives = new List<GameObject>();
    [SerializeField] private SpriteRenderer _logPick;
    [SerializeField] private Text _leveltxt;
    public LogSO _currentLevel;
    private int _currentNumberLevel;
    private int _chanceOfGenerate;

    private void Start()
    {
        _currentNumberLevel = PlayerPrefs.GetInt("Level");
        _leveltxt.text = "Level: " + (_currentNumberLevel + 1).ToString();
        _currentLevel = _levelNumbers[_currentNumberLevel % _levelNumbers.Count];
        if (_currentLevel.GetAmountBotKnives() > 0)
            _knives[_currentLevel.GetAmountBotKnives() - 1].SetActive(true);
        _chanceOfGenerate = UnityEngine.Random.Range(0, 12);
        if (_chanceOfGenerate < 3)
            _apples[_chanceOfGenerate].SetActive(true);
        if (_currentNumberLevel > 4)
            StartCoroutine(_currentLevel.ChangeRotateSpeed());
    }

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, Time.fixedDeltaTime * _currentLevel.GetRotateSpeed());
    }

    public void DisablePick()
    {
        _logPick.enabled = false;
    }

    public void UpdateLevel()
    {
        PlayerPrefs.SetInt("Level", _currentNumberLevel + 1);
        if (PlayerPrefs.GetInt("MaxLevel") < _currentNumberLevel + 1)
            PlayerPrefs.SetInt("MaxLevel", _currentNumberLevel + 1);
    }

    public int GetAmountOfPlayersKnives() => _currentLevel.GetAmountPlayersKnives();
}