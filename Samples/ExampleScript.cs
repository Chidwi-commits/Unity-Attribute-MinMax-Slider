using Chidwi.MinMaxSliderAttribute;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField]
    [MinMaxSliderAttribute(0f, 2f)]
    private Vector2 value = new Vector2(1.1f, 1.3f);

    void Start()
    {
        Debug.Log($"Min:{value.x} ~ Max:{value.y}");
    }

    void Update()
    {
        Debug.Log($"Min:{value.x} ~ Max:{value.y}");
    }
}
