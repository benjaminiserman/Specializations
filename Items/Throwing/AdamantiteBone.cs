using Specializations.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Throwing
{
    public class AdamantiteBone : ModItem
	{
		public override void SetDefaults()
		{
			Item.shootSpeed = 9f;
			Item.damage = 58;
			Item.knockBack = 6f;
			Item.useStyle = 1;
			Item.useAnimation = 11;
			Item.useTime = 11;
			Item.width = 20;
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
			Item.shoot = ModContent.ProjectileType<AdamantiteBoneProjectile>();
            Item.ammo = ItemID.Bone;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.AdamantiteBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}