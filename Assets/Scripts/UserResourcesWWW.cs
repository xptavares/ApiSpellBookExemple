using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserResourcesWWW : MonoBehaviour
{

    public string url;

    // Use this for initialization
    void Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("user[name]", "Alexandre Tavares");
        form.AddField("user[email]", "xptavares@gmail.com");

        get(url, (response) => {
            Debug.Log("response get: " + response.text);
        });

        post(url, form, (response) => {
            Debug.Log("response post: " + response.text);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void get(string url, Action<ResourcesResponse> callback = null)
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www, callback));
    }

    private void post(string url, WWWForm form, Action<ResourcesResponse> callback = null)
    {
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www, callback));
    }

    private IEnumerator WaitForRequest(WWW www, Action<ResourcesResponse> callback = null)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            callback(new ResourcesResponse(false, www.text));
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            callback(new ResourcesResponse(true, www.error));
        }
    }
}

public class ResourcesResponse
{
    public bool error;
    public string text;

    public ResourcesResponse(bool error, string text)
    {
        this.error = error;
        this.text = text;
    }
}