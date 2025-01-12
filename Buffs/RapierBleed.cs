using Terraria;
using Terraria.ModLoader;
namespace Specializations.Buffs
{
	public class RapierBleed : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<SpecPlayer>().rapierDebuff = true;
		}
		
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<SpecGlobalNPC>().rapierDebuff = true;
		}
	}
}
