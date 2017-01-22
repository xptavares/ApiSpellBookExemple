using Restifizer;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UserResourcesRestifizer : MonoBehaviour {

    public RestifizerManager restifizerManager;

    // Use this for initialization
    void Start()
    {


        Hashtable parameters = new Hashtable();
        Hashtable parametersForm = new Hashtable();
        parametersForm.Add("name", "Alexandre Tavares");
        parametersForm.Add("email", "xptavares@gmail.com");
        parameters.Add("user", parametersForm);

        restifizerManager.ResourceAt("users").Post(parameters, (response) => {
            // response.Resource - at this point you can use the result 
            Debug.Log(response.Request.response.Text);
        });

        restifizerManager.ResourceAt("users").
        Get((response) => {
            // response.ResourceList - at this point you can use the result
            Debug.Log(response.Request.response.Text);
        });

        Hashtable parametersForUpdate = new Hashtable();
        Hashtable parametersFormForUpdate = new Hashtable();
        parametersFormForUpdate.Add("name", "Alexandre Tavares" + (UnityEngine.Random.value * 100));
        parametersFormForUpdate.Add("email", "xptavares@gmail.com" + (UnityEngine.Random.value * 100));
        parametersForUpdate.Add("user", parametersFormForUpdate);

        restifizerManager.ResourceAt("users").One("3").Put(parametersForUpdate, (response) => {
            // response.Resource - at this point you can use the result 
            Debug.Log(response.Request.response.Text);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}


