using System.Collections;
using HoloToolkitExtensions.Utilities;
using UnityEngine;

public class SimpleTextDialogController : MonoBehaviour
{
    private TextMesh _textMesh;

    [SerializeField]
    public GameObject _backPlate;

    [SerializeField]
    public float _margin = 0.05f;

    void Start()
    {
        _textMesh = GetComponentInChildren<TextMesh>();
        gameObject.SetActive(false);
    }

    public void ShowDialog(string text)
    {
        gameObject.SetActive(true);
        StartCoroutine(SetTextDelayed(text));
    }

    private IEnumerator SetTextDelayed(string msg)
    {
        yield return new WaitForSeconds(0.05f);
        _textMesh.text = msg;
        var sizeBackplate = _backPlate.GetRenderedSize();
        var textWidth = sizeBackplate.x - _margin * 2f;
        _textMesh.WordWrap(textWidth);
        _textMesh.GetComponent<Transform>().position -= new Vector3(textWidth/2f, 0,0);
    }
}
