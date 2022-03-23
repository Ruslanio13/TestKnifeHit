using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _speedThrowing;
    [SerializeField] private float _finalPositionY;
    [SerializeField] private Knife _nextKnife;
    [SerializeField] private Player _player;
    [SerializeField] private Balance _balance;
    [SerializeField] private BackGround _backGround;
    [SerializeField] private Log _log;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private VibrationExample _vibrate;
    [SerializeField] private BoxCollider2D _collider;

    public static bool _isFinish = false;
    public Button ThrowButton;
    private bool _isGameOver = false;
    private bool _isInLog = false;
    IEnumerator enumerator;
    UnityAction _throwAction;

    private void Start()
    {
        _isFinish = false;
    }

    private void FixedUpdate()
    {
        if (_isFinish == true || (_speedThrowing == 0 && !_isInLog) || !_collider.enabled)
        {
            StartScatter();
        }
    }

    public void GetAction()
    {
        _throwAction += StartThrow;
        ThrowButton.onClick.AddListener(_throwAction);
    }

    public void StartThrow()
    {
        enumerator = Throwing();
        StartCoroutine(enumerator);
        ThrowButton.onClick.RemoveListener(_throwAction);

    }

    private void StartScatter()
    {
        transform.parent = Camera.main.transform.parent;
        _rigidbody.gravityScale = UnityEngine.Random.Range(3f, 5f);
    }

    IEnumerator Throwing()
    {
        while (true)
        {
            gameObject.transform.position += new Vector3(0, Time.fixedDeltaTime * _speedThrowing);
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isFinish == false)
        {
            if (collision.tag == "emptyKnife")
            {
                if (_player.GetAmountOfPlayersKnives() > 0)
                {
                    _nextKnife.transform.localPosition = new Vector3(0, 0, 0);
                    if (_player.GetAmountOfPlayersKnives() > 1)
                    {
                        _player.knife = _nextKnife;
                        _nextKnife._player = _player;
                        _nextKnife.GetAction();
                    }
                    _player.SubstructKnife();
                    _balance.ChangeKnifeBalanceTxt();
                }
            }
            if (collision.tag == "knife")
            {
                if (!_isInLog)
                    _collider.enabled = false;
                _speedThrowing = 0;
                _backGround.GameOver();
                ThrowButton.onClick.RemoveAllListeners();
                _isGameOver = true;
                PlayerPrefs.SetInt("Level", 0);
                _vibrate.TapVibrateCustom();

            }
            if (collision.tag == "log")
            {
                StopCoroutine(enumerator);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, _finalPositionY);
                gameObject.transform.parent = collision.transform;
                _vibrate.TapPopVibrate();
                if (!_isGameOver)
                    _isInLog = true;
                if (_player.GetAmountOfPlayersKnives() == 0 && _isGameOver == false)
                {
                    _backGround.Finish();
                    _log._currentLevel.StartDesctruct();
                    _log.DisablePick();
                    _isFinish = true;
                    _vibrate.TapVibrate();
                    _log.UpdateLevel();

                }
            }
            if (collision.tag == "apple")
            {
                _balance.ChangeAppleBalance();
                _balance.ChangeAppleBalanceTxt();
                collision.gameObject.SetActive(false);
            }
        }
    }
}
