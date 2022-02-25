using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TooltipTrigger : MonoBehaviour
{

    [SerializeField] private string _headerText;

    [Multiline()]
    [SerializeField] private string _contentText;


    public void OnMouseEnter()
    {
        TooltipHandler.ShowTooltip(_contentText, _headerText);
    }

    public void OnMouseExit()
    {
        TooltipHandler.HideTooltip();
    }
}
