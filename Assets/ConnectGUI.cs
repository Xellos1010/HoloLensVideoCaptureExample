using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ConnectGUI : MonoBehaviour
{
    public enum ConnectionState
    {
        NotConnected,
        AttemptingConnect,
        Connected
    }

    public TCPClient client;
    public TCPServer server;
    
    // Use this for initialization
    void Start()
    {
        client.connectState = ConnectionState.NotConnected;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, Screen.width - 20, 20), client.connectState.ToString());
        if (client.connectState == ConnectionState.NotConnected)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 40, 400, 80), "Connect"))
            {
                //server.StartServer();
                //System.Threading.Thread.Sleep(10);
                client.StartConnect();
            }
        }
        else if (client.connectState == ConnectionState.Connected)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 40, 400, 80), "Send Test Data"))
            {
                //server.StartServer();
                //System.Threading.Thread.Sleep(10);
                //client.SendString("Send Text Test");
                client.SendPhoto();
            }
        }
        else
        {
            GUI.Label(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 80, 400, 80), "Attempting to Connect");
        }
    }

    internal void SendPhoto()
    {
        client.SendPhoto();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ConnectGUI))]
public class ConnectGUIEditor : Editor
{
    ConnectGUI cache;
    //SerializedProperty displayTexture;

    void OnEnable()
    {
        cache = (ConnectGUI)target;
        //displayTexture = serializedObject.FindProperty("");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        /*serializedObject.Update();
        EditorGUILayout.PropertyField(displayTexture);
        serializedObject.ApplyModifiedProperties();
        */
        if (GUILayout.Button("Load Image"))
        {
            cache.SendPhoto();
        }
        if (GUILayout.Button("Close Connection"))
        {
            cache.client.CloseConnection();
        }
    }
}
#endif