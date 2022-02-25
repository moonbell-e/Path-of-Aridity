using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UIPresenter
{
    [ExecuteInEditMode()]
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerField;

        [SerializeField] private TextMeshProUGUI _contentField;

        [SerializeField] private LayoutElement _layoutElement;

        [SerializeField] private int _characterWrapLimit;

        private void Update()
        {
            Vector2 mousePosition = Input.mousePosition;
            transform.position = mousePosition;
        }

        public void SetText(string content, string header = "")
        {
            if(string.IsNullOrEmpty(header))
            {
                _headerField.gameObject.SetActive(false);
            }
            else
            {
                _headerField.gameObject.SetActive(true);
                _headerField.text = header;
            }

            _contentField.text = content;

            int headerLength = _headerField.text.Length;
            int contentLength = _contentField.text.Length;

            _layoutElement.enabled = (headerLength > _characterWrapLimit || contentLength > _characterWrapLimit);
        }

    }
}


