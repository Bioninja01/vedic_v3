using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine;

public class TextFieldController : MonoBehaviour, IPointerClickHandler {

    public KeyboardText kt;
    public Text text;

    public void OnPointerClick(PointerEventData eventData) {
        kt.t = text;
    }

}
