using System;
using UnityEngine;
using IEnumerator = System.Collections.IEnumerator;

public class Counter : MonoBehaviour
{
    private WaitForSeconds _wait;
    private Coroutine _coroutine;
    private float _delay = .5f;
    private int _counter = 0;

    public event Action<int> OnCountUp;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(CounterUp());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator CounterUp()
    {
        while (true)
        {
            _counter++;
            OnCountUp?.Invoke(_counter);
            yield return _wait;
        }
    }
}