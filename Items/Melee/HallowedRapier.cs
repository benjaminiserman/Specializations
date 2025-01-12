using Microsoft.Xna.Framework;
using Specializations.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class HallowedRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Has the combined effects of the Adamantite and Titanium rapiers");
		}

		public override void SetDefaults()
		{
			Item.damage = 55;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 60;           
			Item.height = 60;         
			Item.useTime = 16;          
			Item.useAnimation = 16;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 4;        
			Item.value = 153333;         
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RedLaser>();
			Item.shootSpeed = 0;			
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			SoundEngine.PlaySound(SoundID.Item91);
			return true;
		}
		
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 300);
			player.AddBuff(BuffID.Ironskin, 180);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
