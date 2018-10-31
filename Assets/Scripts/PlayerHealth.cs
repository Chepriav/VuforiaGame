using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	
	public float MaxHeatlh;
	public Image DamagedImage;
	public AudioClip hurtClip;
	public Slider sliderHealth;
    public float health;

    private Sequence hurtImageSequence;

	

	private void Start()
	{
        MaxHeatlh = 100f;
        sliderHealth.value = 1;
        health = MaxHeatlh;
		DamagedImage.DOFade(0.0f,0.01f);
	}



    public void DecreaseHealth(float amount)
	{

        health -= amount;
        sliderHealth.value = health / MaxHeatlh;
        hurtImageSequence = DOTween.Sequence();
		hurtImageSequence.Append(DamagedImage.DOFade(1.0f,0.1f));
		hurtImageSequence.Append(DamagedImage.DOFade(0.0f,0.7f));
		hurtImageSequence.Play();
		GetComponent<AudioSource>().PlayOneShot(hurtClip);
		
		if(health <= 0)
			SceneManager.LoadScene("Menu");
	}
}
