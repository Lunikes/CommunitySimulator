using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine.UI;
using UnityEngine;

public class ChatMannger : ChatManngerBehavior
{
    public Transform chatContent;
    public GameObject chatMessage;

    private string username;

  
    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (networkObject.IsServer)
        {
            username = "Server";
        }
        else
        {
            username = "User";
        }
    }


    public void WriteMessage(InputField input)
    {
        if (!string.IsNullOrEmpty(input.text) && input.text.Trim().Length > 0)
        {
            input.text = input.text.Replace("\r", string.Empty).Replace("\n", string.Empty);
            networkObject.SendRpc(RPC_TRANSMIT_MESSAGE, Receivers.All, "User", input.text.Trim());
            input.text = string.Empty;
            input.ActivateInputField();
        }
    }

    public override void TransmitMessage(RpcArgs args) 
    {
        string username = args.GetNext<string>();
        string message = args.GetNext<string>();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(message))
        {
            return;
        }
        GameObject newMessage = Instantiate(chatMessage, chatContent);
        Text content = newMessage.GetComponent<Text>();

        content.text = string.Format(content.text, username, message);
    }
}
