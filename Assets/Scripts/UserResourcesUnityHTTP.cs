using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserResourcesUnityHTTP : MonoBehaviour {

    public string url;

    // Use this for initialization
    void Start () {
        UnityHTTP.Request getRequest = new UnityHTTP.Request("get", url);
        getRequest.Send((request) => {
            // parse some JSON, for example:
            // JSONObject thing = new JSONObject(request.response.Text);
            Debug.Log(request.response.Text);
            // JSON.JsonDecode(request.response.Text);
        });

        WWWForm form = new WWWForm();
        form.AddField("user[name]", "Alexandre Tavares");
        form.AddField("user[email]", "xptavares@gmail.com");

        UnityHTTP.Request postRequest = new UnityHTTP.Request("post", url, form);
        postRequest.Send((request) => {
            // parse some JSON, for example:
            bool result = false;
            Hashtable thing = (Hashtable)JSON.JsonDecode(request.response.Text, ref result);
            if (!result)
            {
                Debug.LogWarning("Could not parse JSON response!");
                return;
            } else
            {
                Debug.Log(request.response.Text);
            }
        });


        WWWForm formForUpdate = new WWWForm();
        formForUpdate.AddField("user[name]", "Alexandre Tavares" + (UnityEngine.Random.value * 100));
        formForUpdate.AddField("user[email]", "xptavares@gmail.com" + (UnityEngine.Random.value * 100));
        int id = 1;
        UnityHTTP.Request putRequest = new UnityHTTP.Request("put", url + "/" + id, formForUpdate);
        putRequest.Send((request) => {
            // parse some JSON, for example:
            bool result = false;
            Hashtable thing = (Hashtable)JSON.JsonDecode(request.response.Text, ref result);
            if (!result)
            {
                Debug.LogWarning("Could not parse JSON response!");
                return;
            }
            else
            {
                Debug.Log(request.response.Text);
            }
        });

        id = 2;
        UnityHTTP.Request deleteRequest = new UnityHTTP.Request("delete", url + "/" + id);
        deleteRequest.Send((request) => {
            // parse some JSON, for example:
            if (request.response.status != 204)
            {
                Debug.LogWarning("Could not delete!");
                return;
            }
            else
            {
                Debug.Log("Deleted!");
            }
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
