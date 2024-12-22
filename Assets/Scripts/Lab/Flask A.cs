using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flask : MonoBehaviour
{
    public static Flask instance;
    public Animator _anim;
    private MeshRenderer _meshrenderer;
    public Material _newMaterial1; 
    public Material _newMaterial2;
    


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        _anim = gameObject.GetComponent<Animator>();   
        _meshrenderer = transform.Find("Conical_flask_mid_A (1)").GetComponentInChildren<MeshRenderer>();
       
    }

    public void Update()
    {
        if(Input.GetMouseButton(0) && gameObject.CompareTag("FlaskA"))
        {
            MoveFlaskA();
        }

        if (Input.touchCount > 0 && gameObject.CompareTag("FlaskA"))
        {
            MoveFlaskA();
        }
       
    }

    public void MoveFlaskA()
    {
        if (Input.GetMouseButton(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Mousehit;
            if (Physics.Raycast(ray, out Mousehit) && Mousehit.transform == transform)
            {
                _anim.SetTrigger("MoveFlask");
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
                    _anim.SetTrigger("MoveFlask");
                }
            }
        }


        
    }

    public void ChangeColor()
    {
       
        if(_meshrenderer != null)
        {
           
            Material[] oldmaterial = _meshrenderer.materials;

            if(oldmaterial.Length >= 2)
            {
                oldmaterial[0] = _newMaterial1;
                oldmaterial[1] = _newMaterial2;
            }

            _meshrenderer.materials = oldmaterial;
        }

    }

     public void Shake()
    {
        _anim.SetTrigger("Shaking");

        Invoke("ChangeColor", 1.0f);
    }
}
