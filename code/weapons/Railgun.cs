using Sandbox;
using Sandbox.Component;
using System.Linq;

[Library( "weapon_q3railgun", Title = "railgun", Spawnable = true )]
partial class Railgun : Weapon
{
	public override string ViewModelPath => "models/q3/v_railgun.vmdl";
	protected virtual float Force => 128;
	protected virtual float MaxDistance => 512;
	public override float PrimaryRate => 0.5f;

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/q3/railgun.vmdl" );
	}

	public override void AttackPrimary()
	{

		var owner = Owner;
		var MaxTargetDistance = 10000.0f;
		var startPos = owner.EyePos;
		var dir = owner.EyeRot.Forward;

		var tr = Trace.Ray( startPos, startPos + dir * MaxTargetDistance )
		.UseHitboxes()
		.Ignore( owner )
		.HitLayer( CollisionLayer.Debris )
		.Run();

		//Particles rail = Particles.Create( "particles/q3railgunshoot.vpcf", tr.StartPos);
		//rail.SetEntityAttachment(1, EffectEntity, "barrel", true);

		TimeSincePrimaryAttack = 0;
		TimeSinceSecondaryAttack = 0;

		(Owner as AnimEntity)?.SetAnimBool( "b_attack", true );
		ShootEffects();

		PlaySound( "q3railgunshoot" );
		ShootBullet( 0f, 5f, 200f, 1.0f );
	}

	public override void Reload()
	{
		return;
	}
}
