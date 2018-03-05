using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class HallowedRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Has the combined effects of the Adamantite and Titanium rapiers");
		}

		public override void SetDefaults()
		{
			item.damage = 55;          
			item.melee = true;         
			item.width = 60;           
			item.height = 60;         
			item.useTime = 16;          
			item.useAnimation = 16;         
			item.useStyle = 3;         
			item.knockBack = 4;        
			item.value = 153333;         
			item.rare = 4;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RedLaser");
			item.shootSpeed = 0;			
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{	
			
			speedX = 10 * player.direction;
			speedY = 0;
			
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY+1)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			
			Main.PlaySound(SoundID.Item91);
			return true;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{

			target.AddBuff(mod.BuffType("RapierBleed"), 300);
			player.AddBuff(BuffID.Ironskin, 180);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
