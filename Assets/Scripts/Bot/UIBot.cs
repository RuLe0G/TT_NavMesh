using TMPro;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Класс UI параметров объекта 
/// </summary>
public class UIBot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text hpText;
    [SerializeField]
    private TMP_Text scoreText;

    private BotData data;
    /// <summary>
    /// Событие изменение ХП
    /// </summary>
    public UnityEvent onHpChange;
    /// <summary>
    /// Событие изменения счета
    /// </summary>
    public UnityEvent onScoreChange;

    private void Start()
    {
        if (onHpChange == null)
            onHpChange = new UnityEvent();
        onHpChange.AddListener(ChangeHP);

        if (onScoreChange == null)
            onScoreChange = new UnityEvent();
        onScoreChange.AddListener(ChangeScore);

        data = GetComponent<BotData>();
        ChangeHP();
        ChangeScore();
    }

    void ChangeHP()
    {
        hpText.text = "HP - " + data.health.ToString();
    }

    void ChangeScore()
    {
        scoreText.text = "Score -" + data.score.ToString();
    }

}
