using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text _record;
    [SerializeField] private Text _applesBalance;

    private void Start()
    {
        _record.text = "Max Level: " + PlayerPrefs.GetInt("MaxLevel").ToString();
        _applesBalance.text = PlayerPrefs.GetInt("AmountOfApples").ToString();
    }

    public void GoPlay() => SceneManager.LoadScene(1);
}
