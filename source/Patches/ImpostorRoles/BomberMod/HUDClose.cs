using HarmonyLib;
using TownOfUs.Roles;
using Object = UnityEngine.Object;

namespace TownOfUs.ImpostorRoles.BomberMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Bomber))
            {
                var role = Role.GetRole<Bomber>(PlayerControl.LocalPlayer);
                role.PlantButton.graphic.sprite = TownOfUs.PlantSprite;
                role.Bomb.ClearBomb();
            }
        }
    }
}