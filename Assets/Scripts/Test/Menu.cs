using G;
using UnityEditor;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public class MenuItems
    {
        [MenuItem("Zahodim/Vot_Suda/Nema")]
        private static void MenuOption()
        {
        }

        [MenuItem("Zahodim/Mojet_Suda/An_Net")]
        private static void NewMenuOption()
        {
        }

        [MenuItem("Zahodim/Ny_Tochno_Suda/Opa")]
        private static void NewNestedOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "G");
        }
    }
}
