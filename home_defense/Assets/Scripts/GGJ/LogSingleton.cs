﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogSingleton : MonoBehaviour {
  private static LogSingleton m_Instance;
  private TextMeshPro text; 

  public static LogSingleton Instance { get { return m_Instance; } }

void Start () {
		if (null==text) {
			GameObject debugText = GameObject.Find("debug_text");
			if (debugText) {
				text = debugText.GetComponent<TextMeshPro>();
			}
		}
		if (null==m_Instance) {
			m_Instance = this;
		}
	}
	
void Awake()
  {
    m_Instance = this;
  }

  void OnDestroy()
  {
    m_Instance = null;
  }

  void Update()
  {
		
  }


  

  void OnGui()
  {
    // common GUI code goes here
  }

  // Call this to log messages on the big text thing
  public void Log(string msg) {
		Debug.Log(msg);
		if (text != null ) {
			text.SetText(msg);
		} else {
			if (null==GameObject.Find("debug_text")) {
				//Debug.Log("no debug_text to write to :(");
				return;
			} else {
				text = GameObject.Find("debug_text").GetComponent<TextMeshPro>();
				Debug.Log("debug_text found, but its TextMeshProUGUI component is null: " + (null==text));
			}
		}
	}

}