//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FightClub
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enemy
    {
        public int EnemyId { get; set; }
        public string Name { get; set; }
        public string AC { get; set; }
        public string Dex { get; set; }
        public string Description { get; set; }
        public string EnemyImage { get; set; }
        public Nullable<int> Weapon_WeaponId { get; set; }
        public Nullable<int> Spell_SpellId { get; set; }
    
        public virtual Spell Spell { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
