using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlaskB : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audio;
    public ParticleSystem _particleSystem;
    void Start()
    {
        _animator = GetComponent<Animator>();   
        _audio = GetComponent<AudioSource>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && gameObject.CompareTag("FlaskB"))
        {
            MoveFlaskB();
        }


        if (Input.touchCount > 0 && gameObject.CompareTag("FlaskB"))
        {
            MoveFlaskB();
        }
    }

    public void MoveFlaskB()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit MouseHitB;
            if (Physics.Raycast(ray, out MouseHitB) && MouseHitB.transform == transform)
            {
                _animator.SetTrigger("Move");
                StartCoroutine(ShakeDelay());
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray touchray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit touchhit;
                if (Physics.Raycast(touchray, out touchhit) && touchhit.transform == transform)
                {
                    _animator.SetTrigger("Move");
                    StartCoroutine(ShakeDelay());
                }
            }
        }
    }

    IEnumerator ShakeDelay()
    {
        
        yield return new WaitForSeconds(3.0f);
        _animator.SetTrigger("Shaking");  
        yield return new WaitForSeconds(2.0f);  

        // Play particle system and audio
        if (_particleSystem != null)
        {
            _particleSystem.Play();
        }
        if (_audio != null)
        {
            _audio.Play();
        }
        yield return new WaitForSeconds(1.0f);

        
        if (_particleSystem != null && _particleSystem.isPlaying)
        {
            _particleSystem.Stop();
        }
        if(_audio != null)
        {
            _audio.Stop();
        }
        yield return new WaitForSeconds(1.0f);
        PlayerBehaviour.instance.Irritated();
       
    }
}

