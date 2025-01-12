using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
    public class CobaltShuriken : ModItem
	{
        bool foundShurikenGunMod = ModLoader.HasMod("ShurikenGun");

		public override void SetDefaults()
		{
			Item.shootSpeed = 10f;
			Item.damage = 24;
			Item.knockBack = 0;
			Item.useStyle = 1;
			Item.useAnimation = 10;
			Item.useTime = 14;
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;
			Item.rare = 4;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Throwing;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
			Item.shoot = ModContent.ProjectileType<CobaltShurikenProjectile>();

            if (foundShurikenGunMod)
            {
                Item.ammo = AmmoID.Bullet;
            }
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.CobaltBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}