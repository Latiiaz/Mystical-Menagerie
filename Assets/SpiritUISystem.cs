using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritUISystem : MonoBehaviour
{
    public SpiritStatsSystem spiritStatsSystem;
    public void PlayButton()
    {
        spiritStatsSystem.Play(20000);
    }

    public void FeedButton()
    {
        spiritStatsSystem.Feed(50000);
    }
}
