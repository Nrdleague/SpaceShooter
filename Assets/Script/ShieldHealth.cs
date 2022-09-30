using UnityEngine;

public class ShieldHealth : MonoBehaviour
{

    [SerializeField]
    private int _shieldHealth = 3;
    private int _maxResistance;
    private SpriteRenderer _shieldRenderer;
    private Color _shield1, _shieldDmge2, _shieldDmge3;





    // Start is called before the first frame update
    void Start()
    {
        _maxResistance = _shieldHealth;
        _shieldRenderer = GetComponent<SpriteRenderer>();
        _shield1 = _shieldRenderer.color;
        _shieldDmge2 = new Color(255, 191, 255, 195);
        _shieldDmge3 = new Color(234, 48, 123, 195);


        if(_shieldRenderer == null)
        {
            Debug.LogError("Shield renderer is NULL");
        }



    }

    // starting Update
    // Update is called once per frame
    void Update()
    {

        


    }

    void ShieldColor()
    {
        switch (_shieldHealth)
        {
            case 1:
                _shieldRenderer.color = _shieldDmge3;
                break;
            case 2:
                _shieldRenderer.color = _shieldDmge2;
                break;
            default:
                _shieldRenderer.color = _shield1;
                break;




        }
    }



    public bool DamageShield()
    {

        _shieldHealth--;
        ShieldColor();

        switch (_shieldHealth)
        {
            case 1: case 2:
                return true;
            default:
                _shieldHealth = _maxResistance;
                return false;



        }


    }

    public void RestoreShield()
    {
        _shieldHealth = _maxResistance;
        ShieldColor();
    }

}
