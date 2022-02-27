using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIPresenter;

public class TooltipHandler : MonoBehaviour
{
    private static TooltipHandler instance;
    public static int Counter;

    [SerializeField] private Tooltip _tooltip;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Two!");
            Destroy(this);
            return;
        }
        instance = this;
    }

    public static void ShowTooltip(string content, string header = "")
    {
        instance._tooltip.SetText(content, header);
        instance._tooltip.gameObject.SetActive(true);
    }

    public static void HideTooltip()
    {
        instance._tooltip.gameObject.SetActive(false);
    }
}
