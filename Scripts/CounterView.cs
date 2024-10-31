using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro), typeof(Counter))]

public class CounterView : MonoBehaviour
{
    private Counter _counter;
    private TextMeshPro _text;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
        _text = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
        => _counter.OnCountUp += OnCountUp;

    private void OnDisable()
        => _counter.OnCountUp -= OnCountUp;

    private void OnCountUp(int counter)
        => _text.text = counter.ToString();
}