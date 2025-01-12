using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Guns
{
    public class TitaniumBlaster : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 85;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 10;
			Item.value = 112000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet) 
			{
				type = ProjectileID.ExplosiveBullet;
			}
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(3, 2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
