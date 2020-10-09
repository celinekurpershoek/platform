using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class JumpButton : MonoBehaviour, IPointerDownHandler
    {
        private PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            playerMovement.Jump();
        }
    }
}
