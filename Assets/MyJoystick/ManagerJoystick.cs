using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerJoystick : MonoBehaviour, IDragHandler
{
    private Image imgJoystickBg;
    private Image imgJoystick;
    private Vector2 posInput;

    // Start is called before the first frame update
    void Start()
    {
        imgJoystickBg = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();

    }

   public void OnDrag(PointerEventData pointerEventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoystickBg.rectTransform,
            pointerEventData.position,
            pointerEventData.pressEventCamera,
            out posInput))
        {
            posInput.x = posInput.x/(imgJoystickBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y/(imgJoystickBg.rectTransform.sizeDelta.y);
            Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());
        }
    }
}
