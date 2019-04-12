using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatInput : MonoBehaviour
{
    public ChatMannger chatManager;
    private InputField input;

    private void Start()
    {
        input = GetComponent<InputField>();
    }
    public void ValueChanged() {
        if (input.text.Contains("\n")) {
            chatManager.WriteMessage(input);
        }
    }
}
