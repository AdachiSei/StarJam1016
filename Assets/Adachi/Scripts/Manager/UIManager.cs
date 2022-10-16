using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("タイマー")]
    Text _timerText;

    [SerializeField]
    [Header("クリア時間")]
    Text _clearTimeText;

    [SerializeField]
    [Header("ダルマテキスト")]
    Text _darumaText;

    [SerializeField]
    [Header("リザルトパネル")]
    Image _resultPanel;

    [SerializeField]
    [Header("ゲームオーバーパネル")]
    Image _gameOverPanel;

    string _messege = "だるまさんがころんだ";

    protected override void Awake()
    {
        base.Awake();
        _darumaText.text = "";
    }

    void Update()
    {
        _timerText.text = TimeManager.Instance.Timer.ToString("F0");
    }

    public async void ChangeMessege(int coolTime)
    {
        _darumaText.text = "";
        for (var i = 0; i < _messege.Length; i++)
        {
            await Task.Delay(coolTime / _messege.Length);
            _darumaText.text += _messege[i];
        }
    }

    public void ResetMessege()
    {
        _darumaText.text = "";
    }

    public void ClearTime()
    {
        _resultPanel.gameObject.SetActive(true);
        _clearTimeText.text += TimeManager.Instance.Timer.ToString("F0");
    }

    public void GameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
}
