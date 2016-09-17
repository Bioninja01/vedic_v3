﻿using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine;

public class TextFieldController : MonoBehaviour, IPointerClickHandler {

    public KeyboardController kc;
    public InputField inputField;

    public void OnPointerClick(PointerEventData eventData) {
        kc.clearText();
        kc.setInputField(inputField);
    }

}
