using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Networking.Match;

namespace Assets.Scripts
{
    public static class AvaMatchesList
    {
        public static event Action<List<MatchInfoSnapshot>> AvailableMatchChanges = delegate { };

        private static List<MatchInfoSnapshot> MatchListReady= new List<MatchInfoSnapshot>();
        public static void HandleNewMatchList(List<MatchInfoSnapshot> MatchList)
        {
            MatchListReady = MatchList;
            AvailableMatchChanges(MatchListReady);
        }
    }
}
