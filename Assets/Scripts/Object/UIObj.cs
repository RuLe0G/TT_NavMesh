using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIObj : MonoBehaviour
{
    [SerializeField]
    private TMP_Text hpText;

    private ObjData data;

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
