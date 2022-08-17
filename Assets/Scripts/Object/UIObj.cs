using TMPro;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Класс UI параметров объекта 
/// </summary>
public class UIObj : MonoBehaviour
{
    [SerializeField]
    private TMP_Text hpText;

    private ObjData data;
    /// <summary>
    /// Событие изменения ХП
    /// </summary>
    public UnityEvent onHpChange;

    private void Start()
    {
        if (onHpChange == null)
            onHpChange = new UnityEvent();

        onHpChange.AddListener(ChangeHP);

        data = GetComponent<ObjData>();
        ChangeHP();
    }

    void ChangeHP()
    {
        hpText.text = "HP - " + data.health.ToString();
    }

}
