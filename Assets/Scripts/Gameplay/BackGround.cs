using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float _speedApperaring;
    [SerializeField] private SpriteRenderer _backGroundImg;
    [SerializeField] private Text _text;
    [SerializeField] private Text _textButton;
    [SerializeField] private GameObject _buttons;

    public void GameOver()
    {
        StartCoroutine(SmoothAppearing(true));
    }

    public void Finish()
    {
        StartCoroutine(SmoothAppearing(false));
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator SmoothAppearing(bool _isGameOver)
    {
        while (_backGroundImg.color.a < 180 / 255f)
        {
            _backGroundImg.color += new Color(0, 0, 0, _speedApperaring * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
            if (_isGameOver == true)
            {
                _text.text = "Game Over!";
                _textButton.text = "Try again";
            }
            if (_backGroundImg.color.a > 120 / 255f)
            {
                if (_isGameOver != true)
                {
                    _text.text = "Level Completed!";
                    _textButton.text = "Next Level";
                }
                _buttons.gameObject.SetActive(true);
            }
        }
    }
}
