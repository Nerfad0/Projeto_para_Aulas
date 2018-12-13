﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelCompleteCtrl : MonoBehaviour {

	public Button btnNext;
	public Sprite goldenStar;
	public Image Star1;
	public Image Star2;
	public Image Star3;
	public Text txtScore;
	public int score;
	public int scoreForOneStar;
	public int scoreForTwoStar;
	public int scoreForThreeStar;
	public int scoreForNextLevel;

	public float animStartDelay;
	public float animDelay;
	// Use this for initialization
	void Start () {
		txtScore.text = score.ToString();

		Invoke("MostrarEstrelas", animStartDelay);
	}
	


	IEnumerator MostrarEstrelas(){
		if (score >= scoreForOneStar){
			ExecutarAnimacao(Star1);
			yield return new WaitForSeconds(animDelay);
				if (score >= scoreForTwoStar){
					ExecutarAnimacao(Star2);
					yield return new WaitForSeconds(animDelay);
						if (score >= scoreForThreeStar){
							ExecutarAnimacao(Star3);
							yield return new WaitForSeconds(animDelay);
				}
			}
		}

		if (score >= scoreForNextLevel) {
			btnNext.interactable = true;
			Plim(btnNext.gameObject);
		}
	}

	void ExecutarAnimacao(Image starImg) {
		//Aumentar o tamanho da estrela
		starImg.rectTransform.sizeDelta = new Vector2 (150f, 150f);

		//Mostrar a estrela dourada
		starImg.sprite = goldenStar;

		//Reduzir o tamanho da estrela
		RectTransform t = starImg.rectTransform;
		t.DOSizeDelta(new Vector2(100f, 100f), 0.5f, false);

		Plim(starImg.gameObject);
	}

	void Plim(GameObject obj){
		SFXManager.instance.ShowStarParticles(obj);
		AudioManager.instance.PlayStarSound(obj);
	}
}