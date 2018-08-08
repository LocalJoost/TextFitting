using System.Collections;
using HoloToolkitExtensions.Utilities;
using UnityEngine;

public class DialogLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject _dialog;

    [SerializeField]
    private string _text;

    private void Start()
    {
        _dialog.GetComponent<SimpleTextDialogController>().ShowDialog(_text);
    }
}
