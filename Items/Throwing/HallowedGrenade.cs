using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
    public class HallowedGrenade : ModItem
	{
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Three shall be the number of which you count, after pulling the holy pin");
        }

        public override void SetDefaults()
		{
			Item.shootSpeed = 6f;
			Item.damage = 200;
			Item.knockBack = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.width = 16;
			Item.height = 20;
			Item.maxStack = 999;
			Item.rare = 4;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;

			Item.UseSound = SoundID.Item1;
			Item.value = 150;
			Item.shoot = ModContent.ProjectileType<HallowedGrenadeProjectile>();
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}