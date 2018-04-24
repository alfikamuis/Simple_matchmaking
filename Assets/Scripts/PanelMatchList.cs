using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class PanelMatchList : MonoBehaviour {

    [SerializeField] private JoinMatch joinButtonPrefabs;

	// Use this for initialization
	private void Awake ()
    {
        AvaMatchesList.AvailableMatchChanges += AvaMatchesList_AvailableMatchChanges;
	}

    private void AvaMatchesList_AvailableMatchChanges(List<MatchInfoSnapshot> matches)
    {
        ClearButton();
        CreateNewJoinButton(matches);    
    }

    //bikin2 button 
    private void CreateNewJoinButton(List<MatchInfoSnapshot> matches)
    {
        foreach(var match in matches)
        {
            var button = Instantiate(joinButtonPrefabs);
            //calling join buttonya bro
            button.Initialize(match,transform);
        }
    }

    //bersih2 button di panel
    private void ClearButton()
    {
        var buttons = GetComponentsInChildren<JoinMatch>();
        foreach(var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }


}
