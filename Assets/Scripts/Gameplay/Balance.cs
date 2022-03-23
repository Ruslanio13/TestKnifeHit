using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    [SerializeField] private Text _knifeBalanceTxt;
    [SerializeField] private Text _appleBalanceTxt;
    [SerializeField] private Player _player;
    private int _appleBalance;

    private void Start()
    {
        _appleBalance = PlayerPrefs.GetInt("AmountOfApples");
        Debug.Log(_appleBalance);
        ChangeKnifeBalanceTxt();
        ChangeAppleBalanceTxt();
    }

    public void ChangeAppleBalance()
    {
        _appleBalance += 1;
        PlayerPrefs.SetInt("AmountOfApples", _appleBalance);
    }
    public void ChangeKnifeBalanceTxt() => _knifeBalanceTxt.text = _player.GetAmountOfPlayersKnives().ToString() + "/" + _player.GetStartAmountOfOPlayersKnives();
    public void ChangeAppleBalanceTxt() => _appleBalanceTxt.text = _appleBalance.ToString();
}