using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tambahan
using UnityEngine.Networking;
using Assets.Scripts;

public class PlayerController : NetworkBehaviour {

    int initialsatate = 0;
    [SyncVar]
    public int globalinAja;
    public float nilaiLocal = 0; //local

    // kamera setiap player on/off
    void Start () {

        if (!isLocalPlayer)
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
        }

        else
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
        }
        
    }

    //tampilan nilai local dan global
    private void OnGUI()
    {
       if (isLocalPlayer)
        {
            GUI.Button(new Rect(10, 10, 150, 100), nilaiLocal.ToString());
            GUI.Button(new Rect(200, 10, 150, 100), globalinAja.ToString());
        }
       
    }

    // Update is called once per frame
    void Update ()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        /*testing dari client
        if (isClient && Input.GetKeyDown(KeyCode.C))
        {
            CmdSendInitialValue(initialsatate += 1);
        }
        //testing dari server
        if (isServer && Input.GetKeyDown(KeyCode.C))
        {
            RpcSendInitialValue(initialsatate += 1);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            nilaiLocal += 1;
        }
        */

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 8.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0,z);
	}

    [Command]
    void CmdSendInitialValue(int value)
    {

        globalinAja = value;
    }

    [ClientRpc]
    void RpcSendInitialValue(int value)
    {
        globalinAja = value;
    }

    //identifikasi palyer akan selalu bewarna cyan
    public override void OnStartLocalPlayer()
    {
       GetComponent<MeshRenderer>().material.color = Color.cyan; 
        
    }
}
