using UnityEngine;
using System.Collections;
using UnityEngine.UI;

abstract public class FallingObjects : MonoBehaviour
{
    protected Animator animator;
    private SpriteRenderer spriteRenderer;
    private Button button;

    [SerializeField]
    protected ParticleSystem particles;
    public void ShowParticles()
    {
        if(PlayerData.Instance.GetVFX())
        {
            particles.Play();
        }
    }
    protected void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
        ToggleButtonInteraction();
        //ScaleAssets(); 
    }
    private void OnEnable()
    {
        button.onClick.AddListener(Clicked);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(Clicked);
    }
    private void ScaleAssets()
    {
        Vector3 scale = transform.localScale;
        float dimension = Screen.width / 4 - 100;
        float scalePercentage = dimension / 500;
        Debug.Log(dimension);
        scale.Set(scalePercentage, scalePercentage, 1);
        gameObject.transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("fallen", true);
        GameManager.Instance.levelManager.AddToOrder(this);
        
    }
    abstract public void Animate();
    abstract public void Clicked();
    abstract public GameObject getFalling();

    public void SetGravity(float gravity)
    {
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    public void ToggleButtonInteraction()
    {
        button.interactable = !button.interactable;
    }
}
