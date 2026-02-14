using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth{get;private set;}

    private Animator anim;

    [Header ("iframes")]
    [SerializeField] private float iframeDuration;
    [SerializeField] private int numofFlashes;
    private SpriteRenderer spriteRenderer;
        private void Awake()
    {
        currentHealth=startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        
    }

    public void AddHealth(float healthvalue)
    {
        currentHealth=Mathf.Clamp(currentHealth+healthvalue,0,startingHealth);
    }
    public void TakeDamage(float damage)
    {
        currentHealth=Mathf.Clamp(currentHealth-damage,0,startingHealth);
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            anim.SetTrigger("dead");
            GetComponent<PlayerMovement>().enabled = false;
            
        }
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < numofFlashes; i++)
        {
            spriteRenderer.color=new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iframeDuration/numofFlashes*2);
            spriteRenderer.color=Color.white;
            yield return new WaitForSeconds(iframeDuration/numofFlashes*2);
        }
        Physics2D.IgnoreLayerCollision(6,7,false);

    }
    
    


}
