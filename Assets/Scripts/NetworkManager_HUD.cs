using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class NetworkManager_HUD : NetworkManager {
    private float refreshAgain;

    public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch("Testing Match room1", 6, true, "", "", "", 0, 0, MacthCreated);
    }

    //start match tapi pake macthmaker setup
    private void MacthCreated(bool success, string extendedInfo, MatchInfo responseData)
    {
        base.StartHost(responseData);
        RefreshMatch();
    }

    private void Update()
    {
        if(Time.time >= refreshAgain)
        { 
            RefreshMatch();
        }
    }

    private void RefreshMatch()
    {
        refreshAgain = Time.time + 3f; 
        if (matchMaker == null)
        {
            StartMatchMaker();
        }  

        matchMaker.ListMatches(0,10,"",true,0,0,HandleListMatch);
    }

    internal void StartJoin(MatchInfoSnapshot match)
    {
        if (matchMaker == null)
            StartMatchMaker();

        matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, HandleJoinMatch);
    }

    private void HandleJoinMatch(bool success, string extendedInfo, MatchInfo responseData)
    {
        StartClient(responseData); 
    }

    private void HandleListMatch(bool success, string extendedInfo, List<MatchInfoSnapshot> responsedata)
    {
        AvaMatchesList.HandleNewMatchList(responsedata);
    }
}
