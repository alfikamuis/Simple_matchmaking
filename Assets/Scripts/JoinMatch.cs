using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinMatch : MonoBehaviour {

    private Text ButtonText;
    private MatchInfoSnapshot match;

    private void Awake()
    {
        ButtonText = GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(JoinNow);
	}
	
	// menentukan posisi dan tampilan button bro
	public void Initialize (MatchInfoSnapshot match, Transform positionOnPanel)
    {
        this.match = match;

        ButtonText.text = match.name;
        transform.SetParent(positionOnPanel);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
	}

    //fungsi masuk ke match host
    private void JoinNow()
    {
        FindObjectOfType<NetworkManager_HUD>().StartJoin(match);
    }
}
