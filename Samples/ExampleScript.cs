using Chidwi.MinMaxSliderAttribute;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField]
    [MinMaxSliderAttribute(0f, 2f)]
    private Vector2 value = new Vector2(1.1f, 1.3f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
