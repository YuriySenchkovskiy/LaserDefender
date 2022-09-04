using UnityEngine;

namespace UI
{
    public class ThanksScreen : MonoBehaviour
    {
        [SerializeField] private Observer.Event _menuClicked;
        [SerializeField] private Observer.Event _clicked;
        
        public void GoToMenu()
        {
            _menuClicked.Occured();
            _clicked.Occured();
        }
    }
}