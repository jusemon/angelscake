﻿/* Copyright (C) 2018 Francesco Sapio - All Rights Reserved
* The license use of this code and/or any portion is subject to
* the condition that this copyright notice shall remain.
*  
* Distribution, reproduction or sale of this 
* code for purposes outside of the license agreement is 
* strictly forbidden.
* 
* NOTICE:  All information, intellectual and technical
* concepts contained herein are, and remain, the property of Francesco Sapio.
*
* Attribution is required.
* Please write to: contact@francescosapio.com
*/


//Usage: Attach this script to any sprite that needs to adjust
//		 its BoxCollider2D when the sprite has been sliced.
//		 The script will automatically remove itself once the
//		 BoxCollider2D has been adjusted.

using UnityEngine;

[ExecuteInEditMode]
public class FixBoxCollider2DSize : MonoBehaviour {

	void Start () {
		
		//Check if the gameObject has a BoxCollider2D
		if(GetComponentsInChildren<BoxCollider2D>().Length == 0){
			Debug.LogWarning(gameObject.name + " does not have a BoxCollider2D", gameObject);
			DestroyImmediate(this);
			return;
		}
		
		//Check if the gameObject has a SpriteRenderer
		if(GetComponentsInChildren<SpriteRenderer>().Length == 0){
			Debug.LogWarning(gameObject.name + " does not have a SpriteRenderer", gameObject);
			DestroyImmediate(this);
			return;
		}

        var colliders = GetComponentsInChildren<BoxCollider2D>();
        var renderers = GetComponentsInChildren<SpriteRenderer>();
        if (colliders.Length != renderers.Length)
        {
            Debug.LogWarning(gameObject.name + " does not have the same quantity of SpriteRenderer and BoxCollider2D", gameObject);
            DestroyImmediate(this);
            return;
        }

        //Adjust the BoxCollider2D size according to the SpriteRenderer
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].size = renderers[i].size;
        }

		//Remove the script from the gameObject
        DestroyImmediate(this);
	}
	
}
