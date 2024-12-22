using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestTube : MonoBehaviour
{
    public static TestTube instance;
    private MeshRenderer _meshrenderer;
    private bool isPouring = false;
  [SerializeField]  private Animator _animator;
    public float _CurrentFillAmount;
    private AudioSource _audioSource;
    private AudioSource _audioSource2;
    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _meshrenderer = transform.Find("TestTube (2)"). GetComponentInChildren<MeshRenderer>();
        _animator = gameObject.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource2 = GetComponent<AudioSource>();
        

      
    }

    public void Update()
    {
        if (Input.GetMouseButton(0) && gameObject.CompareTag("TestTube"))
        {
            Startpour();
        }
      
        if (Input.touchCount > 0)
        {
            Touch screentouch  = Input.GetTouch(0);

            if(screentouch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(screentouch.position);
                RaycastHit hit; 
                if (Physics.Raycast(ray, out hit) && hit.transform == transform && !isPouring )
                {
                    StartCoroutine("Pour");
                }

            }
        }
    }

    public void Startpour()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            Debug.Log("Tag of hit object: " + hit.transform.tag);
            StartCoroutine("Pour");
           
        }
    }
    
    public IEnumerator Pour()
    {
        
        
            _animator.SetTrigger("Pour");
            _audioSource.Play();
            yield return new WaitForSeconds(1.5f);
            _audioSource.Stop();

            _meshrenderer.material.SetFloat("_FillAmount", 0.52f);
            yield return new WaitForSeconds(1.0f);
            _animator.SetTrigger("TurnOffPouring");
            yield return new WaitForSeconds(2.0f);
           

            Flask.instance.Shake();

            yield return new WaitForSeconds(1.0f);
            _audioSource2.Stop();
            PlayerBehaviour.instance.Excited();
            yield return new WaitForSeconds(4.0f);
            Flask.instance._anim.SetTrigger("Reverse");
        
      
       
    }

    


}
