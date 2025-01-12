using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class OrichalcumRapier : ModItem
	{
		bool shoot = false;
		
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Randomly fires a petal that can go through walls");
		}

		public override void SetDefaults()
		{
			Item.damage = 43;          
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 20;          
			Item.useAnimation = 20;         
			Item.useStyle = 3;         
			Item.knockBack = 5;        
			Item.value = 84333;
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;  
			Item.shoot = ProjectileID.FlowerPetal;
			Item.shootSpeed = 0;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity.X = 10 * player.direction;
			velocity.Y = 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			shoot = Main.rand.NextBool(2);
			
			if (shoot)
			{
				SoundEngine.PlaySound(SoundID.Item71);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.OrichalcumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
