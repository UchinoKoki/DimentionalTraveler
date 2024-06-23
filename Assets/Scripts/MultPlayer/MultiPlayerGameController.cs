using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerGameController : MonoBehaviour
{
    [SerializeField]InputField _jsonInputField;
    [SerializeField]GameObject _myCharacter;

    RealTimeServerConnectionManager _rtClient;
    Dictionary<int, GameObject> _playerGameObjects = new Dictionary<int, GameObject>();
    private int _updateRate = 0;
    

    void Start()
    {
        UnityEngine.Debug.Log("InitGame ");
    }

    void FixedUpdate()
    {
        // Avoid sending messages until this client connect to GameLift RealTimeServer.
        if (_rtClient == null) 
            return;
        if (_rtClient.isConnected == false) 
            return;

        
        DoReceivedMessage();

        _updateRate++;
        if (_updateRate % 10 == 0)
        {
            if (_rtClient.playerSeverId == -1)
            {
                _rtClient.SendMessageToAll(2, _rtClient.playerSessionId);
            }
            else
            {
                SendMyCharacterPosition();
            }
        }
    }

    // Pull queue messages and process messages based on OpCode defined GameLift
    public void DoReceivedMessage()
    {
        while (_rtClient.receivedMessageQueue.Count > 0)
        {
            var item = _rtClient.receivedMessageQueue.Dequeue();
            UnityEngine.Debug.Log("[RTMessage] OnDataReceived" + $" OpCode = {item.Item1}, senderid = {item.Item2} : {item.Item3}");

            if (item.Item1 == 2 && item.Item3 == _rtClient.playerSessionId)
                _rtClient.playerSeverId = item.Item2;
            if (item.Item1 == 1)
                UpdateCharacterPosition(item.Item2, item.Item3);
        }
    }

    // Connect to GameLift RealTimeServer based on the text of InputField.
    public void Conect()
    {
        _rtClient = new RealTimeServerConnectionManager();
        _rtClient.ConnectToRemoteServer(_jsonInputField.text);
    }

    // Update position and create other character's GameObject when it is not created yet.
    public void UpdateCharacterPosition(int playerid, string message)
    {
        if (_rtClient.playerSeverId == playerid) 
            return;
        
        if (_playerGameObjects.ContainsKey(playerid))
        {
            _playerGameObjects[playerid].transform.position = StringToVector3(message);
            return;
        }

        Debug.Log($"Clone. {playerid} : {message}");
        var clone = Instantiate(_myCharacter) as GameObject;
        clone.transform.parent = _myCharacter.transform.parent;
        clone.GetComponent<PlayerMove>().isOwner = false;
        // clone.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Another";
        clone.transform.position = StringToVector3(message);

        _playerGameObjects.Add (playerid, clone);
    }

    private void SendMyCharacterPosition()
    {
        _rtClient.SendMessageToAll(1, _myCharacter.transform.position.ToString());
    }

    public static Vector3 StringToVector3(string message)
    {
        if (message.StartsWith("(") && message.EndsWith(")"))
            message = message.Substring(1, message.Length - 2);

        string[] items = message.Split(',');
        Vector3 result =
            new Vector3(
                float.Parse(items[0]),
                float.Parse(items[1]),
                float.Parse(items[2]));
        return result;
    }
}
