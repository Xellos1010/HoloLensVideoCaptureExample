using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SendSocketData : MonoBehaviour {

    public string filePath = "LinkedinAppLogo.jpg";

    private void Start()
    {
        SetupServer();
    }

    private void SetupServer()
    {
        AsynchronousClient.Main(new String[1] {"Test String"});
    }

    internal void SendPhoto()
    {
        //SendData(LoadPhoto());
    }

    internal void SendString()
    {
        Debug.Log("String Sent");
        //SendData(System.Text.Encoding.UTF8.GetBytes("ping"));
    }

    internal void RecieveString()
    {

    }

    private byte[] LoadPhoto()
    {
        return File.ReadAllBytes(Application.dataPath +  '/' + filePath);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SendSocketData))]
public class SendSocketDataEditor:Editor
{
    SendSocketData cache;

    private void OnEnable()
    {
        cache = (SendSocketData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Send Data Test"))
        {
            //cache.SendPhoto();
            cache.SendString();
        }
    }
}
#endif