using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _knifeBalance;
    [SerializeField] private GameObject _knifePrefab;
    [SerializeField] private Button _throwButton;
    [SerializeField] private Log _log;
    [SerializeField] private Balance _balance;
    private int _amountOfKnives;
    private int _startAmountOfKnives;

    public Knife knife;

    private void Start()
    {
        knife.ThrowButton = _throwButton;
        knife.GetAction();
        StartCoroutine(WaitLog());
    }

    private IEnumerator WaitLog()
    {
        while (_log._currentLevel == null)
        {
            yield return new WaitForEndOfFrame();
        }
        _startAmountOfKnives = _log.GetAmountOfPlayersKnives();
        _amountOfKnives = _startAmountOfKnives;
        _balance.ChangeKnifeBalanceTxt();
    }

    public void SubstructKnife() => _amountOfKnives -= 1;
    public int GetAmountOfPlayersKnives() => _amountOfKnives;
    public int GetStartAmountOfOPlayersKnives() => _startAmountOfKnives;
}
