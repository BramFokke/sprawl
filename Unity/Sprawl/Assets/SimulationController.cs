using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sprawl.Base;
using Sprawl.Common.Time;
using UnityEngine.UI;

public class SimulationController : MonoBehaviour
{


    private BaseGame game;
    private INowService nowService;

    public Text Text; 

	// Use this for initialization
	void Awake ()
	{
        game = new BaseGame();
	    nowService = game.Extensions.Get<INowService>();
	    //Text.text = "Started";
	}


    void OnGUI()
    {
        Text.text = nowService.Now.ToString();
    }
}
