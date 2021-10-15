using Sandbox;

[Library( "weapon_q3railgun", Title = "railgun", Spawnable = true )]
partial class Railgun : Weapon
{
	public override string ViewModelPath => "models/q3/railgun.vmdl";

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "weapons/rust_pistol/rust_pistol.vmdl" );
	}

	public override void AttackPrimary()
	{
		// TODO: make gun wait 5 seconds or more before it shoots again
		// also, maybe an alt fire that launches you up

		TimeSincePrimaryAttack = 0;
		TimeSinceSecondaryAttack = 0;

		(Owner as AnimEntity)?.SetAnimBool( "b_attack", true );

		ShootEffects();
		PlaySound( "rust_pistol.shoot" );
		ShootBullet( 0f, 5f, 200f, 1.0f );
	}



}
