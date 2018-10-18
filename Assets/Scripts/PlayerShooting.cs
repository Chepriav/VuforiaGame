using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{

    public Rigidbody m_Stone;                   
    public Transform m_FireTransform;           
    public Slider m_AimSlider;                  
    public float m_MinLaunchForce = 5f;        
    public float m_MaxLaunchForce = 25f;        
    public float m_MaxChargeTime = 0.75f;       


    private string m_FireButton;                
    private float m_CurrentLaunchForce;         
    private float m_ChargeSpeed;                
    private bool m_Fired;                       


    private void OnEnable()
    {
        
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
       
        m_FireButton = "Fire1";

        
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        
        m_AimSlider.value = m_MinLaunchForce;

        
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }
        
        else if (Input.GetButtonDown(m_FireButton))
        {
            
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

        }
       
        else if (Input.GetButton(m_FireButton) && !m_Fired)
        {
           
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;
        }
        
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
           
            Fire();
        }
    }


    private void Fire()
    {
        
        m_Fired = true;

       
        Rigidbody shellInstance =
            Instantiate(m_Stone, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

       
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;

       
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}