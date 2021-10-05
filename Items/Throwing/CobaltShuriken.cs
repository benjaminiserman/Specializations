using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
	public class CobaltShuriken : ModItem
	{
        Mod shurikenGunMod = ModLoader.GetMod("ShurikenGun");

		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.damage = 22;
			item.knockBack = 0;
			item.useStyle = 1;
			item.useAnimation = 14;
			item.useTime = 14;
			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 4;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = 150;
			item.shoot = mod.ProjectileType("CobaltShuriken");

            if (shurikenGunMod != null)
            {
                item.ammo = AmmoID.Bullet;
            }
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}