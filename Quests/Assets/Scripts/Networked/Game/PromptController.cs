using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PromptController : NetworkBehaviour {

    #region Singleton

    public static PromptController instance;

    #endregion


    // Prompty things
    [SerializeField]
    Text promptHeader;
    [SerializeField]
    Text promptBody;
    [SerializeField]
    GameObject prompt;

    void Start()
    {
        instance = this;
    }


    // -- PLAYER PROMPTS -- //

    public void promptLocalUser(string header, string body)
    {
        promptHeader.text = header;
        promptBody.text = body;
        prompt.SetActive(true);
    }

    public void promptAllUsers(string header, string body)
    {
        Cmd_PromptUsers(header, body);
    }

    [Command]
    void Cmd_PromptUsers(string header, string body)
    {
        Rpc_promptUsers(header, body);
    }

    [ClientRpc]
    void Rpc_promptUsers(string header, string body)
    {
        promptLocalUser(header, body);
    }
}
