using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pethalyse.Env
{
    public class DescriptionObject : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;

        public void ChangeText(string newTxt)
        {
            tmp.color = Color.black;
            tmp.text = newTxt;
        }

        public void Active() => gameObject.SetActive(true);
        public void Inactive() => gameObject.SetActive(false);
        public void ChangePositionToMouse() => transform.position = Mouse.current.position.value + new Vector2(50,0);
        public void ChangePosition(Vector2 pos) => transform.position = pos;
    }
}