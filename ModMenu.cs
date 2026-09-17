using MelonLoader;
using UnityEngine;
using System.Reflection;

[assembly: MelonInfo(typeof(SkydlimitMod.ModMenu), "skydlimit", "1.2.0", "skydlimit282")]
[assembly: MelonGame("DefaultCompany", "Animal Company")]

namespace SkydlimitMod
{
    public class ModMenu : MelonMod
    {
        private bool isMenuOpen = false;
        private GameObject menuInstance;

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("skydlimit v1.2.0 successfully initialized!");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 2"))
            {
                isMenuOpen = !isMenuOpen;
                ToggleMenuState(isMenuOpen);
            }
        }

        private void ToggleMenuState(bool open)
        {
            if (open)
            {
                MelonLogger.Msg("Opening skydlimit Mod Menu Interface...");

                // Core UI Object Spawning
                menuInstance = GameObject.CreatePrimitive(PrimitiveType.Cube);
                menuInstance.name = "Skydlimits_3DBoard";

                // Match position 1.2 meters in front of the main VR camera
                if (Camera.main != null)
                {
                    menuInstance.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * 1.2f);
                    menuInstance.transform.rotation = Camera.main.transform.rotation;
                }
                else
                {
                    menuInstance.transform.position = new Vector3(0, 1.5f, 1f);
                }

                menuInstance.transform.localScale = new Vector3(0.6f, 0.5f, 0.1f);
                menuInstance.GetComponent<Renderer>().material.color = Color.black;
            }
            else
            {
                if (menuInstance != null)
                {
                    Object.Destroy(menuInstance);
                }
            }
        }
    }
}
